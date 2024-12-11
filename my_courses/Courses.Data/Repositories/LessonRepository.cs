using Courses.Core.Entities;
using Courses.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data.Repositories
{
    public class LessonRepository:ILessonRepository
    {
        readonly DataContext _dataContext;
        public LessonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Lesson> GetAll()
        {
            return _dataContext.LessonList.ToList();
        }
        public Lesson GetById(int id)
        {
            return _dataContext.LessonList.Where(l => l.LessonId == id).FirstOrDefault();
        }
        public Lesson Add(Lesson lesson)
        {
            try
            {
                _dataContext.LessonList.Add(lesson);
                _dataContext.SaveChanges();
                return lesson;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, Lesson lesson)
        {
            var lessonToUpdate = _dataContext.LessonList.Find(id);
            if (lessonToUpdate == null)
                return false;

            //update the changes

            lessonToUpdate.Name = !String.IsNullOrEmpty(lesson.Name) ? lesson.Name : lessonToUpdate.Name;
            lessonToUpdate.Link = !String.IsNullOrEmpty(lesson.Link)? lesson.Link : lessonToUpdate.Link;
            lessonToUpdate.Summary = !String.IsNullOrEmpty(lesson.Summary)? lesson.Summary : lessonToUpdate.Summary;
            lessonToUpdate.HowLong = lesson.HowLong > 0 ? lesson.HowLong : lessonToUpdate.HowLong;
            lessonToUpdate.SerialNum = lesson.SerialNum > 0 ? lesson.SerialNum : lessonToUpdate.SerialNum;

            _dataContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var lessonToDel = GetById(id);

            if (lessonToDel == null)
                return false;

            _dataContext.LessonList.Remove(lessonToDel);
            _dataContext.SaveChanges();
            return true;

        }
    }
}
