using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lab_9.Models;

public class BookDto
{
    public BookDto()
    {
        Authors = new HashSet<AuthorDto>();
    }
    
    public int Id { get; set; }
   
    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Display(Name = "Data wydania")]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Autorzy")]
    virtual public ISet<AuthorDto> Authors { get; set; }

    public Book? MapTo()
    {
        HashSet<Author> authors = Authors
            .Select(a => new Author() {FirstName = a.FirstName, LastName = a.LastName, PESEL = a.PESEL, Id = a.Id})
            .ToHashSet();
        return new Book() {Title = this.Title, ReleaseDate = this.ReleaseDate, Authors = authors, Created = DateTime.Now};
    }
}