namespace P03_Songs_Above_Duration.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_Songs_Above_Duration.Data.Models;
    using System.Linq.Expressions;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }


        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Performer> Performers { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<Writer> Writers { get; set; } = null!;
        public virtual DbSet<SongPerformer> SongsPerformers { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>()
                .HasKey(sp => new { sp.SongId, sp.PerformerId });

            ////  -------------  With Fluent API  ---------------

            ////  Album
            //builder.Entity<Album>()
            //    .HasKey(a => a.Id);

            //builder.Entity<Album>()
            //    .Property(a => a.Name)
            //       .IsRequired(true)
            //       .HasMaxLength(40);

            //builder.Entity<Album>()
            //    .Property(a => a.ReleaseDate)
            //    .IsRequired(true);

            //builder.Entity<Album>()
            //    .HasOne(a => a.Producer)
            //       .WithMany(p => p.Albums)
            //       .HasForeignKey(a => a.ProducerId);

            //builder.Entity<Album>()
            //    .HasMany(a => a.Songs)
            //    .WithOne(s => s.Album);

            //// Producer
            //builder.Entity<Producer>()
            //    .HasKey(p => p.Id);

            //builder.Entity<Producer>()
            //    .HasMany(p => p.Albums)
            //       .WithOne(a => a.Producer)
            //       .HasForeignKey(p => p.ProducerId);

            //   ///   ... finish Producer and the rest of the Entities 

        }
    }
}
