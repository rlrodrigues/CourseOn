using CourseOn.Domain.Entity;
using CourseOn.Domain.Enum;

namespace CourseOn.Domain.Model
{
    public class Course : Entitye
    {
        public Course(string name, int workload, TargetAudience targetAudience, double price)
        {
            ValidateName(name);
            ValidateWorkload(workload);
            ValidatePrice(price);

            Name = name;
            Workload = workload;
            TargetAudience = targetAudience;
            Price = price;
        }

        public string Name { get; private set; }
        public int Workload { get; private set; }
        public TargetAudience TargetAudience { get; private set; }
        public double Price { get; private set; }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid name.");
        }

        private void ValidateWorkload(int workload)
        {
            if (workload < 1)
                throw new ArgumentException("Invalid workload.");
        }

        private void ValidatePrice(double price)
        {
            if (price < 1)
                throw new ArgumentException("Invalid price.");
        }
    }
}
