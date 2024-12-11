using Courses.Core.Entities;
using Courses.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        readonly DataContext _dataContext;
        public StudentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Student> GetAll()
        {
            return _dataContext.StudentList.ToList();
        }
        public Student GetById(int id)
        {
            //Get by StudentId
            return _dataContext.StudentList.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public Student Add(Student student)
        {
            //List<Student> dataStudent = _dataContext.StudentList.ToList();
            //dataStudent.Add(student);
            //return _dataContext.SaveData(dataStudent);
            try
            {
                _dataContext.StudentList.Add(student);
                _dataContext.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, Student student)
        {
            //List<Student> dataStudent = _dataContext.StudentList.ToList();

            //int index = dataStudent.FindIndex(s => s.StudentId == id);
            //if(index == -1)
            //    return false;
            ////update the changes

            //dataStudent[index].FName = !String.IsNullOrEmpty(student.FName) ? student.FName : dataStudent[index].FName;
            //dataStudent[index].LName = !String.IsNullOrEmpty(student.LName) ? student.LName : dataStudent[index].LName;
            //dataStudent[index].Phone = !String.IsNullOrEmpty(student.Phone) ? student.Phone : dataStudent[index].Phone;
            //dataStudent[index].Email = !String.IsNullOrEmpty(student.Email) ? student.Email : dataStudent[index].Email;
            //return _dataContext.SaveData(dataStudent);

            //Update by Primary Key
            var studentToUpdate = _dataContext.StudentList.Find(id);
            if (studentToUpdate == null)
                return false;

            studentToUpdate.FName = !String.IsNullOrEmpty(student.FName) ? student.FName : studentToUpdate.FName;
            studentToUpdate.LName = !String.IsNullOrEmpty(student.LName) ? student.LName : studentToUpdate.LName;
            studentToUpdate.Phone = !String.IsNullOrEmpty(student.Phone) ? student.Phone : studentToUpdate.Phone;
            studentToUpdate.Email = !String.IsNullOrEmpty(student.Email) ? student.Email : studentToUpdate.Email;

            _dataContext.SaveChanges();
            return true;

        }
        public bool Delete(int id)
        {
            //List<Student> dataStudent = _dataContext.StudentList.ToList();

            //Student del = GetById(id);
            //if(del==null)
            //    return false;
            //dataStudent.Remove(del);

            //return _dataContext.SaveData(dataStudent);


            //Delete By StudentId

            var studentToDel = GetById(id);

            if (studentToDel == null) 
                return false;

            _dataContext.StudentList.Remove(studentToDel);
            _dataContext.SaveChanges();
            return true;


        }
    }
}
