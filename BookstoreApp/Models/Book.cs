using System.ComponentModel.DataAnnotations;
namespace BookstoreApp.Models;

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

    /// <summary>
    /// The 13 digits ISBN number of the book.
    /// No dashes or spaces are allowed in the ISBN number.
    /// Digits only, 13 characters long.
    /// </summary>
    public string ISBN { get; set; }

    /// <summary>
    /// The optional user facing description of the book.
    /// </summary>
    public string? description { get; set; }

    /// <summary>
    /// Returns a string representation of the book, including its title and price.
    /// </summary>
    /// <returns>
    /// A string representation of the book.
    /// </returns>
    public override string ToString() => $"{Title} - {Price:c2}";
}

