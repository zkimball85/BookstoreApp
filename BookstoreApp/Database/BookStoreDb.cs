using BookstoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreApp.Database;

public class BookStoreDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=ZACHARYKIMB6482; Initial Catalog=BookStoreDb; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
    }

    // Add entities to track in the database as DbSet below.
    public DbSet<Book> Books { get; set; }

    public DbSet<Genre> Genres { get; set; }
}

