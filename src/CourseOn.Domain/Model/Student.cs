using CourseOn.Domain.Entity;
using CourseOn.Domain.Enum;

namespace CourseOn.Domain.Model
{
    public class Student : Entitye
    {
        public Student(string name, string cpf, string email, TargetAudience targetAudience)
        {
            ValidateName(name);
            ValidateCpf(cpf);
            ValidateEmail(email);

            Name = name;
            Cpf = cpf;
            Email = email;
            TargetAudience = targetAudience;
        }

        public string Name { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public TargetAudience TargetAudience { get; private set; }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid name.");
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Invalid email.");
        }

        private void ValidateCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("Invalid cpf.");
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}
