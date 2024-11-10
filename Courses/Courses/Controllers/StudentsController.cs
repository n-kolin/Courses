using Courses.Servers;
using Courses.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static readonly StudentServer studentServer = new StudentServer();


        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            List<Student> res = studentServer.GetStudents();
            return res;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Student res = studentServer.GetStudentById(id);
            if(res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Student student)
        {
            if (studentServer.AddStudent(student))
                return true;

            return BadRequest();
            
            
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Student student)
        {
            if (id <= 0)
                return BadRequest();

            bool flag = studentServer.UpdateStudent(id, student);

            if (flag)
                return true;

            return NotFound();
            
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = studentServer.DeleteStudent(id);
            if (flag)
                return true;
            return NotFound();
            
        }
    }
}
