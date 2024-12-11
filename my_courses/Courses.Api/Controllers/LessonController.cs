using Courses.Core.Entities;
using Courses.Core.InterfaceServices;
using Courses.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        // GET: api/<LessonController>
        [HttpGet]
        public ActionResult<IEnumerable<Lesson>> Get()
        {
            return _lessonService.GetAll();
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public ActionResult<Lesson> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Lesson res = _lessonService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<LessonController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Lesson lesson)
        {
            if (_lessonService.Add(lesson) != null)
                return true;
            return BadRequest();
        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Lesson lesson)
        {
            if (id <= 0)
                return BadRequest();

            bool flag = _lessonService.Update(id, lesson);

            if (flag)
                return true;

            return NotFound();
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = _lessonService.Delete(id);
            if (flag)
                return true;
            return NotFound();
        }
    }
}
