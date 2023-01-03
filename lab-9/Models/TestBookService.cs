using Microsoft.AspNetCore.Mvc;

namespace lab_9.Models;

public class TestBookService: IBookService
{
    private readonly Dictionary<int, Book?> repository = new Dictionary<int, Book?>();

    private int counter = 1;
    private int UniqId()
    {
        return counter++;
    }

    public Book? Save(Book? book)
    {
        book.Id = UniqId();
        repository.Add(book.Id, book);
        return book;
    }

    public async Task<Book> SaveAsync(Book book)
    {
        book.Id = UniqId();
        repository.Add(book.Id, book);
        return book;
    }

    public bool Delete(int? id)
    {
        if (id is null)
        {
            return false;
        }
        return repository.Remove(id??1);
    }

    public bool Update(Book? book)
    {
        if (repository.ContainsKey(book.Id))
        {
            repository[book.Id] = book;
            return true;
        }

        return false;
    }

    public Book? FindBy(int? id)
    {
        if (id is null)
        {
            return null;
        }
        return repository.TryGetValue(id??1, out var book) ? book : null;
    }

    public IEnumerable<Book?> FindAll()
    {
        return repository.Values;
    }

    public ICollection<Book> FindByAuthor(Author author)
    {
        return repository.Where(b => b.Value.Authors.Contains(author)).Select(b => b.Value).ToList();
    }

    public PagingList<Book> FindPage(int page, int size)
    {
        throw new NotImplementedException();
    }

    public (string Error, int Age) BookAge(int? id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Author> AuthorsBookById(int id)
    {
        throw new NotImplementedException();
    }
}