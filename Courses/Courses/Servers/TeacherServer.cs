using Courses.Entities;

namespace Courses.Servers
{
    public class TeacherServer
    {
        public List<Teacher> GetTeachers()
        {
            return DataContextManager.DataContext.TeachersList;
        }
        public Teacher GetTeacherById(int id)
        {
            return DataContextManager.DataContext.TeachersList.Find(t => t.Id == id);
        }
        public bool AddTeacher(Teacher teacher)
        {
            ErrorType errorType;

            bool isValid = new IsValidPhone().IsValid(teacher.Phone, out errorType);
            if (isValid)
            {
                DataContextManager.DataContext.TeachersList.Add(teacher);
                return true;
            }
            return false;
        }

        public bool UpdateTeacher(int id, Teacher teacher)
        {
            ErrorType errorType;
            bool isValid = new IsValidPhone().IsValid(teacher.Phone, out errorType);

            if (!isValid)
                return false;


            int index = DataContextManager.DataContext.TeachersList.FindIndex(t => t.Id == id);
            if (index != -1)
            {
                DataContextManager.DataContext.TeachersList[index] = teacher;
                return true;
            }
            return false;
        }
        public bool DeleteTeacher(int id)
        {
            Teacher del = GetTeacherById(id);
            if (del != null)
            {
                DataContextManager.DataContext.TeachersList.Remove(del);
                return true;
            }
            return false;
        }
    }
}
