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
            if (id <= 0)
                return BadRequest();
            StudentInCourse res = studentInCourseServer.GetStudentInCourseById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<StudentInCourseController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] StudentInCourse studentInCourse)
        {
            studentInCourseServer.AddStudentInCourse(studentInCourse);
            return true;
        }

        // PUT api/<StudentInCourseController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] StudentInCourse studentInCourse)
        {
            if (id <= 0)
                return BadRequest();
            bool flag = studentInCourseServer.UpdateStudentInCourse(id, studentInCourse);
            if (flag)
                return true;

            return NotFound();
        }

        // DELETE api/<StudentInCourseController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = studentInCourseServer.DeleteCourse(id);
            if (flag)
                return true;

            return NotFound();
        }
    }
}
