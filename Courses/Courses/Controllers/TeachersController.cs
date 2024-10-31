using Courses.Entities;
using Courses.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        static readonly TeacherServer teacherServer = new TeacherServer();


        // GET: api/<TeachersController>
        [HttpGet]
        public ActionResult<List<Teacher>> Get()
        {
            List<Teacher> res = teacherServer.GetTeachers();
            return Ok(res);
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher res = teacherServer.GetTeacherById(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // POST api/<TeachersController>
        [HttpPost]
        public ActionResult Post([FromBody] Teacher teacher)
        {
            teacherServer.PostTeacher(teacher);
            return Ok();
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Teacher teacher)
        {
            bool flag = teacherServer.PutTeacher(id, teacher);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool flag = teacherServer.DeleteTeacher(id);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
