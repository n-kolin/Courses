using Courses.Core.Entities;
using Courses.Core.InterfaceRepositories;
using Courses.Core.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Service
{
    public class StudentInCourseService:IStudentInCourseService
    {
        readonly IStudentInCourseRepository _studentInCourseRepository;

        public StudentInCourseService(IStudentInCourseRepository studentInCourseRepository)
        {
            _studentInCourseRepository = studentInCourseRepository;
        }

        public List<StudentInCourse> GetAll()
        {

            var dataStudentInCourse = _studentInCourseRepository.GetAll();
            if (dataStudentInCourse == null)
                return null;
            return dataStudentInCourse.ToList();
        }
        public StudentInCourse GetById(int id)
        {
            return _studentInCourseRepository.GetById(id);
        }
        public StudentInCourse Add(StudentInCourse studentInCourse)
        {

            if (studentInCourse == null)
                return null;
            return _studentInCourseRepository.Add(studentInCourse);
        }
        public bool Update(int id, StudentInCourse studentInCourse)
        {
            if (studentInCourse == null)
                return false;
            return _studentInCourseRepository.Update(id, studentInCourse);
        }
        public bool Delete(int id)
        {
            return _studentInCourseRepository.Delete(id);
        }
    }
}
