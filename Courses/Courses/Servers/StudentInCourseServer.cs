using Courses.Entities;

namespace Courses.Servers
{
    public class StudentInCourseServer
    {
        public List<StudentInCourse> GetStudentInCourses() 
        { 
            return DataContextManager.DataContext.StudentInCourseList;
        }
        public StudentInCourse GetStudentInCourseById(int id)
        {
            return DataContextManager.DataContext.StudentInCourseList.Find(s => s.Id == id);
        }

        public bool AddStudentInCourse(StudentInCourse studentInCourse)
        {
            DataContextManager.DataContext.StudentInCourseList.Add(studentInCourse);
            return true;
        }
        public bool UpdateStudentInCourse(int id, StudentInCourse studentInCourse)
        {
            int index = DataContextManager.DataContext.StudentInCourseList.FindIndex(s => s.Id == id);
            if (index != -1)
            {
                DataContextManager.DataContext.StudentInCourseList[index] = studentInCourse;
                return true;
            }
            return false;
        }
        public bool DeleteCourse(int id)
        {
            StudentInCourse del = GetStudentInCourseById(id);
            if (del != null)
            {
                DataContextManager.DataContext.StudentInCourseList.Remove(del);
                return true;
            }
            return false;
        }
    }
}
