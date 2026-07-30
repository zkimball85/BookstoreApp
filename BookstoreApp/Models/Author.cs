using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookstoreApp.Models;

/// <summary>
/// Represents an individual author of a book.
/// </summary>
public class Author
{
    [Key]

    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the author.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the list of books by this author.
    /// </summary>
    public List<Book> Books { get; set; } = [];
}



