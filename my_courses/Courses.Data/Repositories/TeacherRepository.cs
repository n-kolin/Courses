using Courses.Core.Entities;
using Courses.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data.Repositories
{
    public class TeacherRepository:ITeacherRepository
    {
        readonly DataContext _dataContext;
        public TeacherRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Teacher> GetAll()
        {
            return _dataContext.TeacherList.ToList();
        }
        public Teacher GetById(int id)
        {
            return _dataContext.TeacherList.Where(t => t.TeacherId == id).FirstOrDefault();
        }
        public Teacher Add(Teacher teacher)
        {
            try
            {
                _dataContext.TeacherList.Add(teacher);
                _dataContext.SaveChanges();
                return teacher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, Teacher teacher)
        {
            var teacherToUpdate = _dataContext.TeacherList.Find(id);
            if (teacherToUpdate == null)
                return false;

            //update the changes

            teacherToUpdate.FName = !String.IsNullOrEmpty(teacher.FName) ? teacher.FName : teacherToUpdate.FName;
            teacherToUpdate.LName = !String.IsNullOrEmpty(teacher.LName) ? teacher.LName : teacherToUpdate.LName;
            teacherToUpdate.Phone = !String.IsNullOrEmpty(teacher.Phone) ? teacher.Phone : teacherToUpdate.Phone;
            teacherToUpdate.Email = !String.IsNullOrEmpty(teacher.Email) ? teacher.Email : teacherToUpdate.Email;
            teacherToUpdate.Address = !String.IsNullOrEmpty(teacher.Address) ? teacher.Address : teacherToUpdate.Address;
            teacherToUpdate.Salary = teacher.Salary > 0 ? teacher.Salary : teacherToUpdate.Salary;

            _dataContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {

            var teacherToDel = GetById(id);

            if (teacherToDel == null)
                return false;

            _dataContext.TeacherList.Remove(teacherToDel);
            _dataContext.SaveChanges();
            return true;

        }
    }
}
