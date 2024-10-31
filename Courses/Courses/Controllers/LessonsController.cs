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
            return Ok(res);
        }

        // GET api/<LessonsController>/5
        [HttpGet("{id}")]
        public ActionResult<Lesson> Get(int id)
        {
            Lesson res = lessonServer.GetLessonById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // POST api/<LessonsController>
        [HttpPost]
        public ActionResult Post([FromBody] Lesson lesson)
        {
            lessonServer.PostLesson(lesson);
            return Ok();
        }

        // PUT api/<LessonsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson lesson)
        {
            bool flag = lessonServer.PutLesson(id, lesson);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<LessonsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool flag = lessonServer.DeleteLesson(id);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
