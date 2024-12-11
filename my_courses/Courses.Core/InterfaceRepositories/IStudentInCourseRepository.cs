﻿using Courses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.InterfaceRepositories
{
    public interface IStudentInCourseRepository
    {
        List<StudentInCourse> GetAll();
        StudentInCourse GetById(int id);
        StudentInCourse Add(StudentInCourse studentInCourse);
        bool Update(int id, StudentInCourse studentInCourse);
        bool Delete(int id);
    }
}
