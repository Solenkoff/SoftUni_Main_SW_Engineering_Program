﻿namespace P02_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P02_FootballBetting.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FootballBettingContext : DbContext
    {

        //private const string ConnectionString = "";   //  !!!   Insert Connection String   !!!
            

        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString);

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
               .HasKey(ps => new { ps.PlayerId, ps.GameId});

        }
    }
}
