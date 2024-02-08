namespace P01_StudentSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        
        public Student()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(Constants.StudentNameMaxLength)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "char(10)")]
        [Unicode(false)]                                     // exactly 10 characters
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }  
        public DateTime? Birthday { get; set; }  
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
