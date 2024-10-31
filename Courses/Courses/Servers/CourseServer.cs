using Courses.Entities;

namespace Courses.Servers
{
    public class CourseServer
    {
        public List<Course> courses = new List<Course>();

        public List<Course> GetCourses()
        {
            return courses;
        }
        public Course GetCourseById(int id)
        {
            return courses.Find(c => c.Id == id);
        }

        public bool PostCourse(Course course)
        {
            courses.Add(course);
            return true;
        }

        public bool PutCourse(int id, Course course)
        {
            int index = courses.FindIndex(c=>c.Id==id);
            if(index != -1)
            {
                courses[index] = course;
                return true;
            }
            return false;
        }
        public bool DeleteCourse(int id)
        {
            Course del = courses.Find(c=>c.Id==id);
            if (del != null)
            {
                courses.Remove(del);
                return true;
            }
            return false;
        }


        
        

    }
}
