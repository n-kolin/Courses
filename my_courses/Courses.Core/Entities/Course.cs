using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities
{
    public enum Satisfaction { Low=1, Medium=2, High=3 }
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        

        public int TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }
        public string? Syllabus { get; set; }

        [Column(TypeName ="decimal(18,4)")]
        public decimal Price { get; set; }
        public int NumOfLessons { get; set; }
    }
}
