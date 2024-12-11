using Courses.Core.Entities;
using Courses.Core.InterfaceServices;
using Courses.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return _courseService.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Course res = _courseService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Course course)
        {
            if (_courseService.Add(course) != null)
                return true;
            return BadRequest();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Course course)
        {
            if (id <= 0)
                return BadRequest();

            bool flag = _courseService.Update(id, course);

            if (flag)
                return true;

            return NotFound();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = _courseService.Delete(id);
            if (flag)
                return true;
            return NotFound();
        }
    }
}
