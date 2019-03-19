using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiAuth.Models
{
    public partial class usersContext : DbContext
    {
        public usersContext()
        {
        }

        public usersContext(DbContextOptions<usersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=users;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Organisation)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('User')");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
