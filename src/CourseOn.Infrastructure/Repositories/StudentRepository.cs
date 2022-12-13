using CourseOn.Domain.Interfaces;
using CourseOn.Domain.Model;
using CourseOn.Infrastructure.BaseContext;
using System.Data;

namespace CourseOn.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(CourseOnContext context) : base(context){}

        public void UpdateName(int id, string name)
        {
            var student = GetById(id);

            if (student is null)
                throw new NoNullAllowedException("Student is null");

            student.SetName(name);

            if (string.IsNullOrEmpty(name))
                Update(student);
        }
    }
}
