using Courses.Core.Entities;
using Courses.Core.InterfaceServices;
using Courses.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInCourseController : ControllerBase
    {
        readonly IStudentInCourseService _studentInCourseService;
        public StudentInCourseController(IStudentInCourseService studentInCourseService)
        {
            _studentInCourseService = studentInCourseService;
        }
        // GET: api/<StudentInCourseController>
        [HttpGet]
        public ActionResult<IEnumerable<StudentInCourse>> Get()
        {
            return _studentInCourseService.GetAll();
        }

        // GET api/<StudentInCourseController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentInCourse> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            StudentInCourse res = _studentInCourseService.GetById(id);
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
            if (_studentInCourseService.Add(studentInCourse) != null)
                return true;
            return BadRequest();

        }

        // PUT api/<StudentInCourseController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] StudentInCourse studentInCourse)
        {
            if (id <= 0)
                return BadRequest();

            bool flag = _studentInCourseService.Update(id, studentInCourse);

            if (flag)
                return true;

            return NotFound();
        }

        // DELETE api/<StudentInCourseController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = _studentInCourseService.Delete(id);
            if (flag)
                return true;
            return NotFound();
        }
    }
}
