namespace Courses.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HowLong { get; set; }
        public int SerialNum { get; set; }
        public string Link { get; set; }
        public int CourseId { get; set; }
        public string Summary { get; set; }
    }
}
