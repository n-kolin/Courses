using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities
{
    [Table("Teachers")]

    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        
        public int TeacherId { get; set; }

        [MaxLength(50)]
        public string FName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LName { get; set; }
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }

    }
}
