using CourseOn.Domain.Dto;
using CourseOn.Domain.Enum;
using CourseOn.Domain.Interfaces;
using CourseOn.Domain.Model;
using CourseOn.Domain.Services;
using CourseOn.Test.Builders;
using CourseOn.Test.Util;
using Moq;

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

            Assert.Throws<ArgumentException>(() => _courseStoreService.Store(_courseDto)).WithMessage("Course already saved.");
        }
    }
}
