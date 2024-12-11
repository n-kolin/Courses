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
    public class CourseService:ICourseService
    {
        readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> GetAll()
        {

            var dataCourses = _courseRepository.GetAll();
            if (dataCourses == null)
                return null;
            return dataCourses.ToList();
        }
        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }
        public Course Add(Course course)
        {

            if (course == null)
                return null;       
            return _courseRepository.Add(course);
        }
        public bool Update(int id, Course course)
        {
         
            if (course == null)
                return false;
            return _courseRepository.Update(id, course);
        }

        public bool Delete(int id)
        {
            return _courseRepository.Delete(id);
        }
    }
}
