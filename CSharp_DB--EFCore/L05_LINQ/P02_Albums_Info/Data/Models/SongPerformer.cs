namespace P02_Albums_Info.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SongPerformer
    {
        [Required]
        public int SongId { get; set; }
        [Required]
        [ForeignKey(nameof(SongId))]
        public virtual Song Song { get; set; } = null!;

        [Required]
        public int PerformerId { get; set; }
        [Required]
        [ForeignKey(nameof(PerformerId))]
        public virtual Performer Performer { get; set; } = null!;
    }
}