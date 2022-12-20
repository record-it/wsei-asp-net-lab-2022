using System.Data.Entity;
using lab_9.Test;

namespace lab_9.Models;

public class TestAppDbContext : DbContext
{
    public TestDbSet<Book> Books { get; set; }
    
    public TestDbSet<Author> Authors { get; set; }

}