using Courses.Entities;

namespace Courses
{
    public interface IDataContext
    {

        public List<Student> LoadData();
        public bool SaveData(List<Student> student);

    }
}
