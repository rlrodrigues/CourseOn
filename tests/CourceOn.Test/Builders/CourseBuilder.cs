using CourseOn.Domain.Enum;
using CourseOn.Domain.Model;

namespace CourseOn.Test.Builders
{
    public class CourseBuilder
    {
        private string _name = "Curso Geopolitica";
        private int _workload = 80;
        private TargetAudience _targetAudience = TargetAudience.Student;
        private double _price = 1000;

        public static CourseBuilder New()
        {
            return new CourseBuilder();
        }

        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public CourseBuilder WithWorkload(int workload)
        {
            _workload = workload;
            return this;
        }

        public CourseBuilder WithPrice(double price)
        {
            _price = price;
            return this;
        }

        public CourseBuilder WithTargetAudience(TargetAudience targetAudience)
        {
            _targetAudience = targetAudience;
            return this;
        }

        public Course Builder()
        {
            return new Course(_name, _workload, _targetAudience, _price);
        }
    }
}
