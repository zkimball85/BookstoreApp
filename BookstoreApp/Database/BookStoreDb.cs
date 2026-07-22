using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreApp.Database;

public class BookStoreDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb\mssqllocaldb);Database=BookstoreDb; Trusted_Connection=True; TrustServerCertificate=True; ");
    }

    // Add entities to track in the database as DbSet below.
    public DbSet<Book> Books { get; set; }
}

