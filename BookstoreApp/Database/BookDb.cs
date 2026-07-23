using Microsoft.EntityFrameworkCore; // Add this using directive for Entity Framework Core

namespace BookstoreApp.Database;

/// <summary>
/// Provides methods for interacting with the Book database.
/// </summary>
public static class BookDb
{
    // Asynchronous method to retrieve a list of books from the database.
    public static async Task<List<Book>> GetBooksAsync()
    {
        using BookStoreDb db = new();

        // Retrieve the list of books from the database asynchronously.
        List<Book> books = await db.Books.OrderBy(b => b.Title).ToListAsync();

        return books;
    }
}

