using Courses.Entities;
using Courses.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        static readonly LessonServer lessonServer = new LessonServer();

        // GET: api/<LessonsController>
        [HttpGet]
        public ActionResult<List<Lesson>> Get()
        {
            List<Lesson> res = lessonServer.GetLessons();
            return res;
        }

        // GET api/<LessonsController>/5
        [HttpGet("{id}")]
        public ActionResult<Lesson> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Lesson res = lessonServer.GetLessonById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST api/<LessonsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Lesson lesson)
        {
            lessonServer.AddLesson(lesson);
            return true;
        }

        // PUT api/<LessonsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Lesson lesson)
        {
            if (id <= 0)
                return BadRequest();
            bool flag = lessonServer.UpdateLesson(id, lesson);
            if (flag)
                return true;
            
            return NotFound();
        }

        // DELETE api/<LessonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag = lessonServer.DeleteLesson(id);
            if (flag)
                return true;

            return NotFound();
        }
    }
}
