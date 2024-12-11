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
    public class LessonService:ILessonService
    {
        readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public List<Lesson> GetAll()
        {

            var dataLessons = _lessonRepository.GetAll();
            if (dataLessons == null)
                return null;
            return dataLessons.ToList();
        }
        public Lesson GetById(int id)
        {
            return _lessonRepository.GetById(id);
        }
        public Lesson Add(Lesson lesson)
        {

            if (lesson == null)
                return null;
            return _lessonRepository.Add(lesson);
        }
        public bool Update(int id, Lesson lesson)
        {

            if (lesson == null)
                return false;
            return _lessonRepository.Update(id, lesson);
        }
        public bool Delete(int id)
        {
            return _lessonRepository.Delete(id);
        }
    }
}
