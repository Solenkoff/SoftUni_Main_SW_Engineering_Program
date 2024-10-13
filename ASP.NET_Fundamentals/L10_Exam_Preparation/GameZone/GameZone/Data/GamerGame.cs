﻿namespace GameZone.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    [PrimaryKey(nameof(GameId), nameof(GamerId))]
    public class GamerGame
    {
        [Comment("Identifier of the game")]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;


        [Comment("Identifier of the gamer")]
        public string GamerId { get; set; } = null!;

        [ForeignKey(nameof(GamerId))]
        public IdentityUser Gamer { get; set; } = null!;
    }
}

//•	Has GameId – integer, PrimaryKey, foreign key (required)
//•	Has Game – Game
//•	Has GamerId – string, PrimaryKey, foreign key (required)
//•	Has Gamer – IdentityUser
