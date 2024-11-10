using Courses.Entities;
using Courses.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        static readonly CourseServer courseServer = new CourseServer();

        // GET: api/<CoursesController>
        [HttpGet]
        public ActionResult<List<Course>> Get()
        {

            List<Course> res = courseServer.GetCourses();
            return res;
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            Course res = courseServer.GetCourseById(id);
            if(res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Course course)
        {

            courseServer.AddCourse(course);
            return true;
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Course course)
        {
            if (id <= 0)
                return BadRequest();
            
            bool flag = courseServer.UpdateCourse(id, course);
            if (flag)
                return true;

            return NotFound();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = courseServer.DeleteCourse(id);
            if (flag)
                return true;

            return NotFound();
        }
    }
}
