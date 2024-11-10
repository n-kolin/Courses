using Courses.Entities;

namespace Courses.Servers
{
    public class LessonServer
    {

        public List<Lesson> GetLessons()
        {
            return DataContextManager.DataContext.LessonsList;
        }
        public Lesson GetLessonById(int id)
        {
            return DataContextManager.DataContext.LessonsList.Find(l => l.Id == id);
        }

        public bool AddLesson(Lesson lesson)
        {
            DataContextManager.DataContext.LessonsList.Add(lesson);
            return true;
        }

        public bool UpdateLesson(int id, Lesson lesson)
        {
            int index = DataContextManager.DataContext.LessonsList.FindIndex(l => l.Id == id);
            if(index != -1)
            {
                DataContextManager.DataContext.LessonsList[index] = lesson;
                return true;
            }
            return false;
        }
        public bool DeleteLesson(int id)
        {
            Lesson del = GetLessonById(id);
            if(del != null)
            {
                DataContextManager.DataContext.LessonsList.Remove(del);
                return true;
            }
            return false;
        }


    }
}
