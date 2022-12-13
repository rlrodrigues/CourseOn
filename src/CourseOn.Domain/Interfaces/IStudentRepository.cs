using CourseOn.Domain.Model;

namespace CourseOn.Domain.Interfaces
{
    public interface IStudentRepository
    {
        void UpdateName(int id, string name);
    }
}
