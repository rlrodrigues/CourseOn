using CourseOn.Domain.Enum;
using CourseOn.Domain.Model;
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

        public CourseStoreServiceTest()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
        }

        [Fact]
        public void MustAddCourse()
        {
            var courseDto = new CourseDto
            {
                Name = "Ruan",
                Workload = 10,
                Price = 100.00,
                TargetAudience = 1
            };

            var courseStoreService = new CourseStoreService(_courseRepositoryMock.Object);

            courseStoreService.Store(courseDto);

            _courseRepositoryMock.Verify(r => r.Add(It.Is<Course>(c => c.Name == courseDto.Name && c.Price == courseDto.Price)));
        }
    }

    public class CourseStoreService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseStoreService(ICourseRepository @object)
        {
            _courseRepository = @object;
        }

        public void Store(CourseDto courseDto)
        {
            var course = new Course(courseDto.Name, courseDto.Workload, (TargetAudience)courseDto.TargetAudience, courseDto.Price);

            _courseRepository.Add(course);
        }
    }

    public class CourseDto
    {
        public string Name { get; set; }
        public int Workload { get; set; }
        public double Price { get; set; }
        public int TargetAudience { get; set; }
    }

    public interface ICourseRepository
    {
        void Add(Course course);
        void Update(Course course);
    }
}
