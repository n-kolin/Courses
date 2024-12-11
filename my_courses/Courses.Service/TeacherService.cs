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
    public class TeacherService:ITeacherService
    {
        readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public List<Teacher> GetAll()
        {

            var dataTeacher = _teacherRepository.GetAll();
            if (dataTeacher == null)
                return null;
            return dataTeacher.ToList();
        }
        public Teacher GetById(int id)
        {
            return _teacherRepository.GetById(id);
        }
        public Teacher Add(Teacher teacher)
        {       

            if (teacher == null)
                return null;
            ErrorType errorType;

            bool isValid = new IsValidPhone().IsValid(teacher.Phone, out errorType);
            if (isValid)
                return _teacherRepository.Add(teacher);

            return null;
        }
        public bool Update(int id, Teacher teacher)
        {
            if (teacher == null)
                return false;

            ErrorType errorType;
            bool isValid = new IsValidPhone().IsValid(teacher.Phone, out errorType);

            if (!isValid && !String.IsNullOrEmpty(teacher.Phone))
                return false;

            return _teacherRepository.Update(id, teacher);
        }
        public bool Delete(int id)
        {
            return _teacherRepository.Delete(id);
        }
    }
}
