
using Courses.Entities;
using Microsoft.Extensions.Logging;

namespace Courses.Servers
{
    public class StudentServer
    {

        public List<Student> GetStudents()
        {
            return DataContextManager.DataContext.StudentsList;
        }
        public Student GetStudentById(int id)
        {
            
            return DataContextManager.DataContext.StudentsList.Find(s => s.Id == id);
        }
        public bool AddStudent(Student student)
        {

            ErrorType errorType;

            bool isValid = new IsValidPhone().IsValid(student.Phone, out errorType);
            if (isValid)
            {
                DataContextManager.DataContext.StudentsList.Add(student);
                return true;
            }         
            return false;
            

        }
        public bool UpdateStudent(int id, Student student)
        {
            ErrorType errorType;
            bool isValid = new IsValidPhone().IsValid(student.Phone, out errorType);
            
            if (!isValid)            
                return false;
            

            int index = DataContextManager.DataContext.StudentsList.FindIndex(s => s.Id == id);
            if (index != -1)
            {

                DataContextManager.DataContext.StudentsList[index] = student;
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            Student del = GetStudentById(id);
            if (del != null)
            {
                DataContextManager.DataContext.StudentsList.Remove(del);
                return true;
            }
            return false;
        }


    }
}
