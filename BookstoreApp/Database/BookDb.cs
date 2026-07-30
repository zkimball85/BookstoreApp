using BookstoreApp.Models;
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
        List<Book> books = await db.Books.OrderBy(static b => b.Title).ToListAsync();

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

        // Ensure genres are tracked entities from this context to avoid duplicate inserts.
        var genreIds = book.Genres?.Select(g => g.GenreId).ToList() ?? new List<int>();
        book.Genres = new List<Genre>();
        foreach (var id in genreIds)
        {
            var genre = await db.Genres.FindAsync(id);
            if (genre != null) book.Genres.Add(genre);
        }

        // If a primary genre id wasn't explicitly set but genres are present, set it from the first genre.
        if (!book.PrimaryGenreId.HasValue && book.Genres.Any())
        {
            book.PrimaryGenreId = book.Genres.First().GenreId;
        }

        if (book.BookAuthorId != 0)
        {
            var author = await db.Authors.FindAsync(book.BookAuthorId);
            if (author != null)
            {
                book.BookAuthor = author;
            }
        }

        db.Books.Add(book);

        // Must call SaveChangesAsync to persist the changes to the database.
        await db.SaveChangesAsync();
    }
    
    /// <summary>
    /// The get book by title method.
    /// Asynchronously retrieves a book from the database by its title.
    /// </summary>
    /// <param name="title">
    /// The title of the book to retrieve.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The result of the task is the book if found, or null if not found.
    /// </returns>
    public static async Task<Book?> GetBookByTitleAsync(string title)
    {
        using BookStoreDb db = new();

        // Find the book by its title. Can be null if the book does not exist.
        Book? book = await db.Books.Where(b => title == b.Title).FirstOrDefaultAsync();
        return book;
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

        // Load existing book with genres from the database
        var existing = await db.Books.Include(b => b.Genres).FirstOrDefaultAsync(b => b.BookId == book.BookId);
        if (existing == null)
        {
            // If not found, treat as add
            await AddAsync(book);
            return;
        }

        // Update scalar properties
        existing.Title = book.Title;
        existing.Price = book.Price;
        existing.ISBN = book.ISBN;
        existing.description = book.description;
        existing.BookAuthorId = book.BookAuthorId;

        // Replace genres with tracked instances matching the provided ids
        existing.Genres.Clear();
        var genreIds = book.Genres?.Select(g => g.GenreId).ToList() ?? new List<int>();
        foreach (var id in genreIds)
        {
            var genre = await db.Genres.FindAsync(id);
            if (genre != null) existing.Genres.Add(genre);
        }

        // Update primary genre id for quick lookup
        existing.PrimaryGenreId = book.PrimaryGenreId ?? existing.Genres.FirstOrDefault()?.GenreId;

        if (book.BookAuthorId != 0)
        {
            existing.BookAuthor = await db.Authors.FindAsync(book.BookAuthorId);
        }

        await db.SaveChangesAsync();
    }

    public static async Task<List<Genre>> GetGenresAsync()
    {
        using BookStoreDb db = new();
        return await db.Genres.OrderBy(g => g.Name).ToListAsync();
    }

    public static async Task<List<Author>> GetAuthorsAsync()
    {
        using BookStoreDb db = new();
        return await db.Authors.OrderBy(a => a.Name).ToListAsync();
    }

    public static async Task AddAuthorAsync(Author author)
    {
        using BookStoreDb db = new();
        db.Authors.Add(author);
        await db.SaveChangesAsync();
    }

    public static async Task UpdateAuthorAsync(Author author)
    {
        using BookStoreDb db = new();
        var existing = await db.Authors.FindAsync(author.Id);
        if (existing == null)
        {
            await AddAuthorAsync(author);
            return;
        }

        existing.Name = author.Name;
        await db.SaveChangesAsync();
    }

    public static async Task DeleteAuthorAsync(int authorId)
    {
        using BookStoreDb db = new();
        var author = await db.Authors.FindAsync(authorId);
        if (author != null)
        {
            db.Authors.Remove(author);
            await db.SaveChangesAsync();
        }
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
    /// <param name="book">
    /// The book to delete. Cannot be null.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public static async Task DeleteAsync(Book book)
    {
        using BookStoreDb db = new();
        db.Books.Remove(book);
        await db.SaveChangesAsync();
    }
}

