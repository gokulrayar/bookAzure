using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bookAs.models
{
    public partial class BookrayarContext : DbContext
    {
        public BookrayarContext()
        {
        }

        public BookrayarContext(DbContextOptions<BookrayarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookstore> Bookstores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:gokul8080.database.windows.net,1433;Initial Catalog=Bookrayar;Persist Security Info=False;User ID=gokulrayar7;Password=Vengambur7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookstore>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__bookstor__3DE0C2077AD00E4E");

                entity.ToTable("bookstore");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.AuthorId).HasMaxLength(50);

                entity.Property(e => e.BookCategory).HasMaxLength(50);

                entity.Property(e => e.BookName).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.PublisherName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
