using CourseOn.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CourseOn.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        public CourseController() {}

        [HttpGet(Name = "GetCourse")]
        public async Task<IActionResult> Get()
        {
            var courses = new List<Course>();

            return Ok(courses);
        }
    }
}