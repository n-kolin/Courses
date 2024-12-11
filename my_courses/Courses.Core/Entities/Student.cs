using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities
{
    [Table("Students")]

    public class Student
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        [MaxLength(50)]
        public string FName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LName { get; set; }
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        //public DateOnly SubscriptionDate { get; set; }

    }
}
