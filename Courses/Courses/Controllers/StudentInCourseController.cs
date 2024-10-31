using Courses.Entities;
using Courses.Servers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInCourseController : ControllerBase
    {

        static readonly StudentInCourseServer studentInCourseServer = new StudentInCourseServer();

        // GET: api/<StudentInCourseController>
        [HttpGet]
        public ActionResult<List<StudentInCourse>> Get()
        {
            List < StudentInCourse > res = studentInCourseServer.GetStudentInCourses();
            return Ok(res);
        }

        // GET api/<StudentInCourseController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentInCourse> Get(int id)
        {
            StudentInCourse res = studentInCourseServer.GetStudentInCourseById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // POST api/<StudentInCourseController>
        [HttpPost]
        public ActionResult Post([FromBody] StudentInCourse studentInCourse)
        {
            studentInCourseServer.PostStudentInCourse(studentInCourse);
            return Ok();
        }

        // PUT api/<StudentInCourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentInCourse studentInCourse)
        {
            bool flag = studentInCourseServer.PutStudentInCourse(id, studentInCourse);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<StudentInCourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool flag = studentInCourseServer.DeleteCourse(id);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
