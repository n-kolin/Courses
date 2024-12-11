using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities
{
    [Table("Lessons")]

    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        public int LessonId { get; set; }
        

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }
        public int HowLong { get; set; }
        public int SerialNum { get; set; }
        public string Link { get; set; }
        public string? Summary { get; set; }

    }
}
