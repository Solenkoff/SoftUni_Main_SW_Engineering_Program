namespace GameZone.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static GameZone.Constants.ModelConstants;

    public class Game
    {
        [Key]
        [Comment("Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        [Comment("Game title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        [Comment("Game description")]
        public string Description { get; set; } = null!;

        [Comment("The Url of the image")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("The game publisher")]
        public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [Comment("The release date of the game")]
        public DateTime ReleasedOn { get; set; }

        [Required]
        [Comment("The game genre")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]    
        public Genre Genre { get; set; } = null!;

        public virtual IList<GamerGame> GamersGames { get; set; } = new List<GamerGame>();

        [Comment("Shows whether the game is deleted or not")]
        public bool IsDeleted { get; set; }
    }
}


//•	Has Id – a unique integer, Primary Key
//•	Has Title – a string with min length 2 and max length 50 (required)
//•	Has Description – string with min length 10 and max length 500 (required)
//•	Has ImageUrl – nullable string
//•	Has PublisherId – string (required)
//•	Has Publisher – IdentityUser (required)
//•	Has ReleasedOn– DateTime with format " yyyy-MM-dd" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has GenreId – integer, foreign key (required)
//•	Has Genre – Genre (required)
//•	Has GamersGames – a collection of type GamerGame
//
//                                          [Comment("Shows whether the game is deleted or not")]
//    +  Prop for the Soft Delete   -->      public bool IsDeleted { get; set; } = false;