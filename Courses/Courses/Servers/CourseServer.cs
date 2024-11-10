using Courses.Entities;

namespace Courses.Servers
{
    public class CourseServer
    {
        

        public List<Course> GetCourses()
        {
           
            return DataContextManager.DataContext.CoursesList;
        }
        public Course GetCourseById(int id)
        {
            return DataContextManager.DataContext.CoursesList.Find(c => c.Id == id);
        }

        public bool AddCourse(Course course)
        {
            DataContextManager.DataContext.CoursesList.Add(course);
            return true;

        }

        public bool UpdateCourse(int id, Course course)
        {
            int index = DataContextManager.DataContext.CoursesList.FindIndex(c=>c.Id==id);
            if(index != -1)
            {
                DataContextManager.DataContext.CoursesList[index] = course;
                return true;
            }
            return false;
        }

        public bool DeleteCourse(int id)
        {
            Course del = GetCourseById(id);
            if (del != null)
            {
                DataContextManager.DataContext.CoursesList.Remove(del);
                return true;
            }
            return false;

        }


        
        

    }
}
