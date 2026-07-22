using System.ComponentModel.DataAnnotations;
namespace BookstoreApp;

/// <summary>
/// Represents a book in the bookstore.
/// </summary>
public class Book
{
    /// <summary>
    /// The primary key for the book.
    /// </summary>
    [Key]
    public int BookId { get; set; }

    /// <summary>
    /// The title of the book.
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string Title { get; set; }

    /// <summary>
    /// The sales price of the book.
    /// </summary>
    public decimal Price { get; set; }
}

