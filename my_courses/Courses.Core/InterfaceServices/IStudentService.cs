using Courses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.InterfaceServices
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        Student Add(Student student);
        bool Update(int id, Student student);
        bool Delete(int id);
    }
}
