using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lab_9.Models;

public class BookRepositoryEF: IBookService
{
    private readonly AppDbContext _context;
    private readonly ILogger<BookRepositoryEF> _logger;

    public BookRepositoryEF(AppDbContext context, ILogger<BookRepositoryEF> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Book? Save(Book? book)
    {
        try
        {
            foreach (var bookAuthor in book.Authors)
            {
                _context.Attach(bookAuthor);
            }

            book.Created= DateTime.Now;
            var entityEntry = _context.Books.Add(book);
            _context.SaveChanges();
            return entityEntry.Entity;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    public async Task<Book?> SaveAsync(Book? book)
    {
        try
        {
            foreach (var bookAuthor in book.Authors)
            {
                _context.Attach(bookAuthor);
            }
            book.Created= DateTime.Now;
            var entityEntry = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    public bool Delete(int? id)
    {
        if (id is null)
        {
            return false;
        }
        var find = _context.Books.Find(id);
        if (find is not null)
        {
            _context.Books.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool Update(Book? book)
    {
        try
        {
            var find = _context.Books.Find(book.Id);
            if (find is not null)
            {
                find.Title = book.Title;
                find.ReleaseDate = book.ReleaseDate;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        catch(DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    public Book? FindBy(int? id)
    {
        return id is null ? null : _context.Books.Include(b => b.Authors).FirstOrDefault(b => b.Id == id);
    }

    public IEnumerable<Book?> FindAll()
    {
        return _context.Books.Include(book => book.Authors).ToList();
    }

    public ICollection<Book> FindByAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public PagingList<Book> FindPage(int page = 1, int size = 5)
    {
        int totalCount = _context.Books.Count();
        List<Book?> books = _context.Books.Skip((page - 1) * size).Take(size).ToList();
        return PagingList<Book>.Create(books, totalCount, page, size);
    }

    public (string Error, int Age) BookAge(int? id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Author> AuthorsBookById(int id)
    {
        return _context.Books.Include(b => b.Authors).First(b => b.Id == id).Authors;
    }

    public void SaveChanges()
    {
  
        _context.SaveChanges();
    }
}