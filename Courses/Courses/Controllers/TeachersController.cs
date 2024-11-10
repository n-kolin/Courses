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
            return res;
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Teacher res = teacherServer.GetTeacherById(id);
            if(res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<TeachersController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Teacher teacher)
        {
            if(teacherServer.AddTeacher(teacher))
                return true;
            return BadRequest();
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Teacher teacher)
        {
            if (id <= 0)
                return BadRequest();
            bool flag = teacherServer.UpdateTeacher(id, teacher);
            if (flag)
                return true;
            return NotFound();
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = teacherServer.DeleteTeacher(id);
            if (flag)
            {
                return true;
            }
            return NotFound();
        }
    }
}
