using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiCurriculum.Models
{
    public partial class cvdbContext : DbContext
    {
        public cvdbContext()
        {
        }

        public cvdbContext(DbContextOptions<cvdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Chapters> Chapters { get; set; }
        public virtual DbSet<Conferences> Conferences { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=cvdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.Property(e => e.Authors).IsRequired();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Doi).HasColumnName("DOI");

                entity.Property(e => e.Issn).HasColumnName("ISSN");

                entity.Property(e => e.Issue).HasMaxLength(4);

                entity.Property(e => e.Journal).IsRequired();

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Volume).HasMaxLength(4);

                entity.Property(e => e.Year).HasMaxLength(4);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.Authors).IsRequired();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Doi).HasColumnName("DOI");

                entity.Property(e => e.Issn).HasColumnName("ISSN");

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Year).HasMaxLength(4);
            });

            modelBuilder.Entity<Chapters>(entity =>
            {
                entity.HasKey(e => e.ChapterId);

                entity.Property(e => e.Authors).IsRequired();

                entity.Property(e => e.Book).IsRequired();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Doi).HasColumnName("DOI");

                entity.Property(e => e.Issn).HasColumnName("ISSN");

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Year).HasMaxLength(4);
            });

            modelBuilder.Entity<Conferences>(entity =>
            {
                entity.HasKey(e => e.ConferenceId);

                entity.Property(e => e.Authors).IsRequired();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Conference).IsRequired();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Doi).HasColumnName("DOI");

                entity.Property(e => e.Issn).HasColumnName("ISSN");

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Volume).HasMaxLength(4);

                entity.Property(e => e.Year).HasMaxLength(4);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.University).IsRequired();
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Company).IsRequired();

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.About).HasMaxLength(100);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Facebook).HasMaxLength(255);

                entity.Property(e => e.Firstname).HasMaxLength(100);

                entity.Property(e => e.Github).HasMaxLength(255);

                entity.Property(e => e.Lastname).HasMaxLength(100);

                entity.Property(e => e.LinkedIn).HasMaxLength(255);

                entity.Property(e => e.Middlename).HasMaxLength(100);

                entity.Property(e => e.Phone1).HasMaxLength(100);

                entity.Property(e => e.Phone2).HasMaxLength(100);

                entity.Property(e => e.Skype).HasMaxLength(100);

                entity.Property(e => e.Twitter).HasMaxLength(255);
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Skill)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
