using CourseOn.Domain.Model;

namespace CourseOn.Domain.Interfaces
{
    public interface ICourseRepository
    {
        void Add(Course course);
        void Update(Course course);
        Course GetByName(string name);
    }
}
