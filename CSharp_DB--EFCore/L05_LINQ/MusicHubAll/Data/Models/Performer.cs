﻿namespace Music_Hub_All.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }

    }
}