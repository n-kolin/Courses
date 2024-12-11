using Courses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.InterfaceServices
{
    public interface ILessonService
    {
        List<Lesson> GetAll();
        Lesson GetById(int id);
        Lesson Add(Lesson lesson);
        bool Update(int id, Lesson lesson);
        bool Delete(int id);
    }
}
