using Courses.Core.Entities;
using Courses.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data.Repositories
{
    public class StudentInCourseRepository:IStudentInCourseRepository
    {
        readonly DataContext _dataContext;
        public StudentInCourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<StudentInCourse> GetAll()
        {
            return _dataContext.StudentInCourseList.ToList();
        }
        public StudentInCourse GetById(int id)
        {
            return _dataContext.StudentInCourseList.Where(s => s.Id == id).FirstOrDefault();
        }
        public StudentInCourse Add(StudentInCourse studentInCourse)
        {
            try
            {
                _dataContext.StudentInCourseList.Add(studentInCourse);
                _dataContext.SaveChanges();
                return studentInCourse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, StudentInCourse studentInCourse)
        {
            var sInCToUpdate = _dataContext.StudentInCourseList.Find(id);
            if (sInCToUpdate == null)
                return false;

            //update the changes

            sInCToUpdate.Mark = studentInCourse.Mark > 0 ? studentInCourse.Mark : sInCToUpdate.Mark;
            sInCToUpdate.Payment = studentInCourse.Payment > 0 ? studentInCourse.Payment : sInCToUpdate.Payment;

            _dataContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var sInCToDel = GetById(id);

            if (sInCToDel == null)
                return false;

            _dataContext.StudentInCourseList.Remove(sInCToDel);
            _dataContext.SaveChanges();
            return true;

        }

    }
}
