
using Courses.Entities;
using Microsoft.Extensions.Logging;

namespace Courses.Servers
{
    public class StudentServer
    {
        public List<Student> students = new List<Student>() { };

        public List<Student> GetStudents()
        {
            return students;
        }
        public Student GetStudentById(int id)
        {          
            return students.Find(s => s.Id == id);
        }
        public bool PostStudent(Student student)
        {
            students.Add(student);
            return true;
        }
        public bool PutStudent(int id, Student student)
        {
            int index = students.FindIndex(s=>s.Id == id);
            if(index != -1)
            {

                students[index] = student;
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            Student del = students.Find(s => s.Id == id);
            if(del != null)
            {
                students.Remove(del);
                return true;
            }
            return false;
        }
    }
}
