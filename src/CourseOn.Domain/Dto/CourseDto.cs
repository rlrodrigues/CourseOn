using CourseOn.Domain.Enum;

namespace CourseOn.Domain.Dto
{
    public class CourseDto
    {
        public string Name { get; set; }
        public int Workload { get; set; }
        public double Price { get; set; }
        public TargetAudience TargetAudience { get; set; }
    }
}
