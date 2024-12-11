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
    public class StudentService:IStudentService
    {
        readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<Student> GetAll()
        {

            var dataStudents = _studentRepository.GetAll();
            if (dataStudents == null)
                return null;
            return dataStudents.ToList();
        }
        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
        public Student Add(Student student)
        {
            if(student==null)
                return null;

            ErrorType errorType;

            bool isValid = new IsValidPhone().IsValid(student.Phone, out errorType);
            if (isValid)    
                return _studentRepository.Add(student);

            return null;
        }
        public bool Update(int id, Student student)
        {
            if (student == null)
                return false;

            ErrorType errorType;
            bool isValid = new IsValidPhone().IsValid(student.Phone, out errorType);

            if (!isValid && !String.IsNullOrEmpty(student.Phone))
                return false;
     
            return _studentRepository.Update(id, student);
        }
        public bool Delete(int id)
        {      
            
            return _studentRepository.Delete(id);
        }
    }
}
