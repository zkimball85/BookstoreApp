using Microsoft.EntityFrameworkCore; // Add this using directive for Entity Framework Core

namespace BookstoreApp.Database;

/// <summary>
/// Provides CRUD methods for interacting with the Book database.
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

    /// <summary>
    /// Add Method.
    /// Asynchronously adds a new book to the database.
    /// </summary>
    /// <param name="book">
    /// The book to add. Cannot be null.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public static async Task AddAsync(Book book)
    {
        using BookStoreDb db = new();

        db.Books.Add(book);

        // Must call SaveChangesAsync to persist the changes to the database.
        await db.SaveChangesAsync();
    }

    /// <summary>
    /// The update method.
    /// Asynchronously updates an existing book in the database.
    /// </summary>
    /// <param name="book">
    /// The book to update. Cannot be null.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public static async Task UpdateAsync(Book book)
    {
        using BookStoreDb db = new();

        db.Books.Update(book);
        await db.SaveChangesAsync();
    }
    
    /// <summary>
    /// The delete method.
    /// Asynchronously deletes an existing book from the database.
    /// </summary>
    /// <param name="bookId">
    /// The BookId of the book to delete.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public static async Task DeleteAsync(int bookId)
    {
        using BookStoreDb db = new();

        // Find the book by its ID. If found, remove it from the database.
        // Can be null if the book does not exist and nothing will happen.
        Book? bookToDelete = await db.Books.FindAsync(bookId);
        if (bookToDelete != null)
        {
            db.Books.Remove(bookToDelete);
            await db.SaveChangesAsync();
        }
    }

    /// <summary>
    /// The delete method.
    /// A slightly different overload that takes a Book object instead of an ID.
    /// </summary>
    /// <param name="b">
    /// The book to delete. Cannot be null.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public static async Task DeleteAsync(Book b)
    {
        using BookStoreDb db = new();
        db.Books.Remove(b);
        await db.SaveChangesAsync();
    }
}

