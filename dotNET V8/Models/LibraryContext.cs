using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace dotNET_V8.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RDPWindows;Database=Library;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.ID).HasColumnType("int").HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");
                entity.Property(e => e.ShortDesc).HasColumnType("nvarchar(50)");
                entity.Property(e => e.ReleaseYear).HasColumnType("int");
                entity.Property(e => e.ManufactureCode).HasColumnType("int");
                entity.Property(e => e.AuthorCode).HasColumnType("int");
                entity.Property(e => e.StorageCode).HasColumnType("int");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
