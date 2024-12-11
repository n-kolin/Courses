using Courses.Core.Entities;
using Courses.Core.InterfaceServices;
using Courses.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> Get()
        {
            return _teacherService.GetAll();
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Teacher res = _teacherService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Teacher teacher)
        {
            if (_teacherService.Add(teacher)!=null)
                return true;
            return BadRequest();
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Teacher teacher)
        {
            if (id <= 0)
                return BadRequest();

            bool flag = _teacherService.Update(id, teacher);

            if (flag)
                return true;

            return NotFound();
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = _teacherService.Delete(id);
            if (flag)
                return true;
            return NotFound();
        }
    }
}
