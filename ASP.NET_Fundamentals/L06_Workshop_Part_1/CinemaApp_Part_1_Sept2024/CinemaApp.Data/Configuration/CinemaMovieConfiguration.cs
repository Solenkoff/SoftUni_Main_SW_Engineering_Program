﻿namespace CinemaApp.Data.Configuration
{
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            builder.HasKey(cm => new { cm.CinemaId, cm.MovieId });

            builder
                .Property(cm => cm.IsDeleted)
                .HasDefaultValue(false);

            builder
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.MovieCinemas)
                .HasForeignKey(cm => cm.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemaMovies)
                .HasForeignKey(cm => cm.CinemaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateCinemaMovies());

        }


        private IEnumerable<CinemaMovie> GenerateCinemaMovies()
        {
            IEnumerable<CinemaMovie> cinemaMovies = new List<CinemaMovie>()
            {
                new CinemaMovie()
                {
                    
                }


            };

            return cinemaMovies;

        }
    }
}
