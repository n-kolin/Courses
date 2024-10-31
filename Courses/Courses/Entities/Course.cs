namespace Courses.Entities
{
    public enum Satisfaction { Low, Medium, High }
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public string Syllabus { get; set; }
        public double Price { get; set; }
        public int NumOfLessons { get; set; }
    }
}
