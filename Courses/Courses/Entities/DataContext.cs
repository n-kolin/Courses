namespace Courses.Entities
{
    public class DataContext
    {
        public List<Course> CoursesList { get; set; }
        public List<Lesson> LessonsList { get; set; }

        public List<Student> StudentsList { get; set; }

        public List<Teacher> TeachersList { get; set; }

        public List<StudentInCourse> StudentInCourseList { get; set; }

        public DataContext() 
        {

            CoursesList= new List<Course>();
            LessonsList= new List<Lesson>();
            StudentsList= new List<Student>();
            TeachersList= new List<Teacher>();
            StudentInCourseList = new List<StudentInCourse>();
        }

       
    }
}
