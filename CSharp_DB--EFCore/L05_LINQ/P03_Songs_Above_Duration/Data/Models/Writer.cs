namespace P03_Songs_Above_Duration.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();
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