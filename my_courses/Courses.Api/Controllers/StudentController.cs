using Courses.Core.Entities;
using Courses.Core.InterfaceServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _studentService.GetAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Student res = _studentService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Student student)
        {
            if (_studentService.Add(student)!=null)
                return true;

            return BadRequest();


        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Student student)
        {
            if (id <= 0)
                return BadRequest();

            bool flag = _studentService.Update(id, student);

            if (flag)
                return true;

            return NotFound();

        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = _studentService.Delete(id);
            if (flag)
                return true;
            return NotFound();

        }



    }
}
