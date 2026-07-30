using BookstoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Database
{
    public class BookStoreDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=BookStoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly configure many-to-many between Book and Genre to avoid design-time ambiguity.
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity(j => j.ToTable("BookGenre"));

            // Configure optional primary genre FK
            modelBuilder.Entity<Book>()
                .HasOne(b => b.PrimaryGenre)
                .WithMany()
                .HasForeignKey(b => b.PrimaryGenreId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        // Add entities to track in the database as DbSet below.
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}