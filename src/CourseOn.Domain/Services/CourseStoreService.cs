using CourseOn.Domain.Dto;
using CourseOn.Domain.Enum;
using CourseOn.Domain.Interfaces;
using CourseOn.Domain.Model;

namespace CourseOn.Domain.Services
{
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
}
