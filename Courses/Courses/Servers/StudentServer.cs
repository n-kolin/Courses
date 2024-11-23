
using Courses.Entities;
using Microsoft.Extensions.Logging;

namespace Courses.Servers
{
    public class StudentServer
    {
        readonly IDataContext _dataContext;

        public StudentServer(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public StudentServer()
        {
        }

        public List<Student> GetStudents()
        {

            var dataStudents = _dataContext.LoadData();
            if(dataStudents == null)
                return null;
            return dataStudents.ToList();
            
            //return DataContextManager.DataContext.StudentsList;
        }
        public Student GetStudentById(int id)
        {
            var dataStudents = _dataContext.LoadData();
            if (dataStudents == null)
                return null;
            return dataStudents.Where(s=>s.Id==id).FirstOrDefault();
            //return DataContextManager.DataContext.StudentsList.Find(s => s.Id == id);
        }
        public bool AddStudent(Student student)
        {

            ErrorType errorType;

            bool isValid = new IsValidPhone().IsValid(student.Phone, out errorType);
            if (isValid)
            {
                var dataStudents = _dataContext.LoadData();
                if (dataStudents == null)
                    return false;
                dataStudents.Add(student);
                return _dataContext.SaveData(dataStudents);
                //DataContextManager.DataContext.StudentsList.Add(student);
                //return true;
            }         
            return false;
            

        }
        public bool UpdateStudent(int id, Student student)
        {
            ErrorType errorType;
            bool isValid = new IsValidPhone().IsValid(student.Phone, out errorType);
            
            if (!isValid)            
                return false;

            var dataStudents = _dataContext.LoadData();
            if (dataStudents == null)
                return false;
            int index = dataStudents.FindIndex(s => s.Id == id);
            //int index = DataContextManager.DataContext.StudentsList.FindIndex(s => s.Id == id);
            if (index != -1)
            {
                dataStudents[index] = student;
                return _dataContext.SaveData(dataStudents);
                //DataContextManager.DataContext.StudentsList[index] = student;
                //return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            Student del = GetStudentById(id);
            if (del != null)
            {
                var dataStudents = _dataContext.LoadData();
                if (dataStudents == null)
                    return false;
                dataStudents.Remove(del);
                return _dataContext.SaveData(dataStudents);

                //DataContextManager.DataContext.StudentsList.Remove(del);
                //return true;
            }
            return false;
        }


    }
}
