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
            return Ok(res);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            Course res = courseServer.GetCourseById(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public ActionResult Post([FromBody] Course course)
        {
            courseServer.PostCourse(course);
            return Ok();
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course course)
        {
            bool flag = courseServer.PutCourse(id, course);
            if(flag)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool flag = courseServer.DeleteCourse(id);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
