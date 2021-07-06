using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Painting
/// </summary>
public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
    public decimal Price { get; set; }
    public string Imagefile { get; set; }
    public string AuthorName
    {
        get { return Author.Name; }
    }
}