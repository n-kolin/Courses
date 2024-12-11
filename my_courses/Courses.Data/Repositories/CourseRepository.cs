using Courses.Core.Entities;
using Courses.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Data.Repositories
{
    public class CourseRepository:ICourseRepository
    {
        readonly DataContext _dataContext;
        public CourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Course> GetAll()
        {
            return _dataContext.CourseList.ToList();
        }
        public Course GetById(int id)
        {
            return _dataContext.CourseList.Where(c => c.CourseId == id).FirstOrDefault();
        }
        public Course Add(Course course)
        {
            try
            {
                _dataContext.CourseList.Add(course);
                _dataContext.SaveChanges();
                return course;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, Course course)
        {

            var courseToUpdate = _dataContext.CourseList.Find(id);
            if(courseToUpdate == null) 
                return false;

            //update the changes
            courseToUpdate.Name = !String.IsNullOrEmpty(course.Name)? course.Name : courseToUpdate.Name;
            courseToUpdate.TeacherId = course.TeacherId != 0 ? course.TeacherId : courseToUpdate.TeacherId;
            courseToUpdate.Syllabus = !String.IsNullOrEmpty(course.Syllabus) ? course.Syllabus : courseToUpdate.Syllabus;
            courseToUpdate.Price = course.Price > 0 ? course.Price : courseToUpdate.Price;
            courseToUpdate.NumOfLessons = course.NumOfLessons > 0 ? course.NumOfLessons : courseToUpdate.NumOfLessons;

            _dataContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var courseToDel = GetById(id);

            if(courseToDel == null)
                return false;

            _dataContext.CourseList.Remove(courseToDel);
            _dataContext.SaveChanges();
            return true;

        }
    }
}
