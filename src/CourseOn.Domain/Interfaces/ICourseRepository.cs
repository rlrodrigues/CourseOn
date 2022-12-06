using CourseOn.Domain.Model;

namespace CourseOn.Domain.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course GetByName(string name);
    }
}
