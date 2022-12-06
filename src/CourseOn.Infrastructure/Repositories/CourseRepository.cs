using CourseOn.Domain.Interfaces;
using CourseOn.Domain.Model;
using CourseOn.Infrastructure.BaseContext;

namespace CourseOn.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(CourseOnContext context) : base(context) { }
        
        public Course GetByName(string name)
        {
            var course = Context.Set<Course>().FirstOrDefault(course => course.Name == name);

            if (course is not null)
                return course;

            return null;
        }
    }
}
