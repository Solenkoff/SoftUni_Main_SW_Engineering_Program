namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {

        protected StudentSystemContext()
        {
        }
        public StudentSystemContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;


        //  Database Connection Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }


        //  FluentAPI  -->  Entities Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode();

                entity.Property(e => e.PhoneNumber).HasMaxLength(10).IsUnicode(false).IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name).HasMaxLength(80).IsUnicode();

                entity.Property(e => e.Description).IsUnicode().IsRequired(false);

            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode();

                entity.Property(e => e.Url).IsUnicode(false);

                entity.HasOne(r => r.Course)
                       .WithMany(c => c.Resources)
                       .HasForeignKey(r => r.CourseId);

            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity.Property(h => h.Content).IsUnicode(false);

                entity.HasOne(h => h.Student)
                       .WithMany(s => s.Homeworks)
                       .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                       .WithMany(s => s.Homeworks)
                       .HasForeignKey(h => h.CourseId);
            });


            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(sc => sc.Student)
                       .WithMany(s => s.StudentsCourses)
                       .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                       .WithMany(c => c.StudentsCourses)
                       .HasForeignKey(sc => sc.CourseId);
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
