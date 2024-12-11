using Courses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.InterfaceRepositories
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        Course Add(Course course);
        bool Update(int id, Course course);
        bool Delete(int id);
    }
}
