using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace lab_9.Models;

[Table("Authors")]
public class Author
{
    [JsonIgnore]
    private ISet<Book> _books;

    public Author(){}
    private Author(ILazyLoader lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
    
    [JsonIgnore]
    private ILazyLoader LazyLoader { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("first_name")]
    [StringLength(30)]
    public string FirstName { get; set; }

    [Column("last_name")]
    [Required]
    [StringLength(20)]
    public string LastName { get; set; }

    [Column("pesel")] [StringLength(11)] public string PESEL { get; set; }
    
    public ISet<Book> Books
    {
        get
        {
            Console.WriteLine("Lazy Loading");
            return LazyLoader.Load(this, ref _books);
        }
        set => _books = value;
    }
}