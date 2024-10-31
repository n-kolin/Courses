using Courses.Entities;

namespace Courses.Servers
{
    public class StudentInCourseServer
    {
        public List<StudentInCourse> studentInCourses = new List<StudentInCourse>();

        public List<StudentInCourse> GetStudentInCourses() 
        { 
            return studentInCourses;
        }
        public StudentInCourse GetStudentInCourseById(int id)
        {
            return studentInCourses.Find(s => s.Id == id);
        }

        public bool PostStudentInCourse(StudentInCourse studentInCourse)
        {
            studentInCourses.Add(studentInCourse);
            return true;
        }
        public bool PutStudentInCourse(int id, StudentInCourse studentInCourse)
        {
            int index = studentInCourses.FindIndex(s => s.Id == id);
            if (index != -1)
            {
                studentInCourses[index] = studentInCourse;
                return true;
            }
            return false;
        }
        public bool DeleteCourse(int id)
        {
            StudentInCourse del = studentInCourses.Find(s => s.Id == id);
            if (del != null)
            {
                studentInCourses.Remove(del);
                return true;
            }
            return false;
        }
    }
}
