using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities
{
    [Table("StudentInCourses")]

    public class StudentInCourse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public int Mark { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Payment { get; set; }
    }
}
