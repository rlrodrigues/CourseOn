using Bogus;
using CourseOn.Domain.Enum;
using CourseOn.Domain.Model;
using CourseOn.Test.Builders;
using CourseOn.Test.Util;

namespace CourseOn.Test.CourseTest
{
    public class CourseTest : IDisposable
    {
        private readonly Faker _faker;

        public CourseTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void MostCreateACourse()
        {
            var name = _faker.Random.Word();
            var workload = _faker.Random.Number(2, 20);
            var targetAudience = TargetAudience.Student;
            var price = _faker.Random.Double(100, 1000);

            var course = new Course(name, workload, targetAudience, price);

            Assert.Equal(name, course.Name);
            Assert.Equal(workload, course.Workload);
            Assert.Equal(targetAudience, course.TargetAudience);
            Assert.Equal(price, course.Price);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NameDontMostBeInvalid(string invalidName)
        {

            Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithName(invalidName).Builder()).WithMessage("Invalid name."); ;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-200)]
        public void WorkloadDontMostBeLessThan1(int invalidWorkload)
        {
            Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithWorkload(invalidWorkload).Builder()).WithMessage("Invalid workload."); ;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-200)]
        public void PriceDontMostBeLessThan1(double invalidPrice)
        {
            Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithPrice(invalidPrice).Builder()).WithMessage("Invalid price.");
        }

        public void Dispose()
        {
            
        }
    } 
}
