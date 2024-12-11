using Courses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.InterfaceRepositories
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAll();
        Teacher GetById(int id);
        Teacher Add(Teacher teacher);
        bool Update(int id, Teacher teacher);
        bool Delete(int id);
    }
}
