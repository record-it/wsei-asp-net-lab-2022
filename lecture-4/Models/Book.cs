using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace lecture_4.Models;

public class Book
{
    public Book()
    {
        Authors = new HashSet<Author>();
    }

    [HiddenInput]
    public int Id { get; set; }
    [Required]
    [StringLength(200)]
    [Column(name:"title")]
    public string Title { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data wydania")]
    public DateTime ReleaseDate { get; set; }
    
    public DateTime Created { get; set; }
    [ForeignKey("Publisher")]
    public int PublisherId { get; set; }
    
    public Publisher Publisher { get; set; }
    public ISet<Author> Authors { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(ReleaseDate)}: {ReleaseDate}, {nameof(Created)}: {Created}, {nameof(PublisherId)}: {PublisherId}, {nameof(Publisher)}: {Publisher}, {nameof(Authors)}: {Authors}";
    }
}