namespace P02_Albums_Info.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        public string? Pseudonym { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}