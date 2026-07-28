using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookstoreApp.Models;

/// <summary>
/// Represents a genre of books in the bookstore.
/// </summary>
public class Genre
{
    /// <summary>
    /// The primary key for the genre.
    /// </summary>
    [Key]
    public int GenreId { get; set; }

    /// <summary>
    /// The name of the genre.
    /// </summary>
    [Required]
    public required string Name { get; set; }
}

