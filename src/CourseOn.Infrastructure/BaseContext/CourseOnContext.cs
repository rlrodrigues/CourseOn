using CourseOn.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseOn.Infrastructure.BaseContext
{
    public class CourseOnContext : DbContext
    {
        public CourseOnContext(DbContextOptions<CourseOnContext> options) : base(options) { }   
        
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>();
        }
    }
}
