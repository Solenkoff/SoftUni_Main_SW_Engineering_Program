namespace GameZone.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static GameZone.Constants.ModelConstants;

    public class Genre
    {

        [Key]
        [Comment("Genre Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("Genre name")]
        public string Name { get; set; } = null!;

        public virtual IList<Game> Games { get; set; } = new List<Game>();

    }
}


//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 3 and max length 25 (required)
//•	Has Games – a collection of type Game
