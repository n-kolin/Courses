using Courses.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Courses.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Student> StudentList { get; set; }
        public DbSet<Course> CourseList { get; set; }
        public DbSet<StudentInCourse> StudentInCourseList { get; set; }
        public DbSet<Teacher> TeacherList { get; set; }
        public DbSet<Lesson> LessonList { get; set; }

        //public DataContext()
        //{
        //    string path = "..\\Courses.Data\\Data\\data.json";
        //    //string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
        //    string jsonString = File.ReadAllText(path);
        //    StudentList = JsonSerializer.Deserialize<List<Student>>(jsonString);

        //}


        //public bool SaveData(List<Student> newData)
        //{
        //    string path = "..\\Courses.Data\\Data\\data.json";
        //   // string path = "C:\\Users\\user1\\Desktop\\Courses\\Courses.Data\\Data\\data.json";

        //    //string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
        //    string jsonString = JsonSerializer.Serialize(newData);

        //    File.WriteAllText(path, jsonString);
        //    return true;
        //}
    }
}
