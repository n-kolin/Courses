using Courses.Entities;

namespace Courses.Servers
{
    public class LessonServer
    {
        public List<Lesson> lessons = new List<Lesson>();

        public List<Lesson> GetLessons()
        {
            return lessons;
        }
        public Lesson GetLessonById(int id)
        {
            return lessons.Find(l => l.Id == id);
        }

        public bool PostLesson(Lesson lesson)
        {
            lessons.Add(lesson);
            return true;
        }

        public bool PutLesson(int id, Lesson lesson)
        {
            int index = lessons.FindIndex(l => l.Id == id);
            if(index != -1)
            {
                lessons[index] = lesson;
                return true;
            }
            return false;
        }
        public bool DeleteLesson(int id)
        {
            Lesson del = lessons.Find(l => l.Id == id);
            if(del != null)
            {
                lessons.Remove(del);
                return true;
            }
            return false;
        }


    }
}
