using Courses.Entities;

namespace Courses.Servers
{
    public class TeacherServer
    {
        public List<Teacher> teachers = new List<Teacher>();
        public List<Teacher> GetTeachers()
        {
            return teachers;
        }
        public Teacher GetTeacherById(int id)
        {
            return teachers.Find(t => t.Id == id);
        }
        public bool PostTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
            return true;
        }

        public bool PutTeacher(int id, Teacher teacher)
        {
            int index = teachers.FindIndex(t => t.Id == id);
            if (index != -1)
            {
                teachers[index] = teacher;
                return true;
            }
            return false;
        }
        public bool DeleteTeacher(int id)
        {
            Teacher del = teachers.Find(t => t.Id == id);
            if (del != null)
            {
                teachers.Remove(del);
                return true;
            }
            return false;
        }
    }
}
