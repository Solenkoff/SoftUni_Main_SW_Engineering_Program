﻿namespace P02_Albums_Info.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string? Pseudonym { get; set; }   

        public virtual ICollection<Song> Songs { get; set; } 

    }
}