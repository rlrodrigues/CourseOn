using CourseOn.Domain.Enum;
using CourseOn.Domain.Model;
using CourseOn.Test.Builders;
using CourseOn.Test.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOn.Test.ServicesTest
{
    public class CourseStoreServiceTest
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly CourseStoreService _courseStoreService;
        private CourseDto _courseDto;

        public CourseStoreServiceTest()
        {
            var courseDto = new CourseDto
            {
                Name = "Ruan",
                Workload = 10,
                Price = 100.00,
                TargetAudience = TargetAudience.Entrepreneur
            };

            _courseDto = courseDto;
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _courseStoreService = new CourseStoreService(_courseRepositoryMock.Object);
        }

        [Fact]
        public void MustAddCourse()
        {
            _courseStoreService.Store(_courseDto);

            _courseRepositoryMock.Verify(r => r.Add(It.Is<Course>(c => c.Name == _courseDto.Name && c.Price == _courseDto.Price)));
        }

        [Fact]
        public void MustNotAddCourseAlreadySavedWithSameName()
        {
            var courseAlreadySaved = CourseBuilder.New().WithName(_courseDto.Name).Builder();

            _courseRepositoryMock.Setup(c => c.GetByName(_courseDto.Name)).Returns(courseAlreadySaved);

            Assert.Throws<ArgumentException>(() => _courseStoreService.Store(_courseDto)).WithMessage("Course Already Saved.");
            
        }
    }

    public class CourseStoreService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseStoreService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Store(CourseDto courseDto)
        {
            var courseAlreadySaved = _courseRepository.GetByName(courseDto.Name);

            if (courseAlreadySaved != null)
                throw new ArgumentException("Course Already Saved.");

            var course = new Course(courseDto.Name, courseDto.Workload, (TargetAudience)courseDto.TargetAudience, courseDto.Price);

            _courseRepository.Add(course);
        }
    }

    public class CourseDto
    {
        public string Name { get; set; }
        public int Workload { get; set; }
        public double Price { get; set; }
        public TargetAudience TargetAudience { get; set; }
    }

    public interface ICourseRepository
    {
        void Add(Course course);
        void Update(Course course);
        Course GetByName(string name);
    }
}
