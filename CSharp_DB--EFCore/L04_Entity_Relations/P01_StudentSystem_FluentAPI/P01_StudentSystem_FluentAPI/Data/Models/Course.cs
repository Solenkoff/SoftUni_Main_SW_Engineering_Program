﻿namespace P01_StudentSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public Course()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.Resources = new HashSet<Resource>();   
            this.Homeworks = new HashSet<Homework>();   
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(Constants.CourseNameMaxLength)]
        [Unicode(true)]
        public string Name { get; set; } = null!;

        [Unicode(true)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }  
        public virtual ICollection<Resource> Resources { get; set; }  
        public virtual ICollection<Homework> Homeworks { get; set; }  


    }
}
