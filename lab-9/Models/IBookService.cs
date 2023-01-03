using Microsoft.AspNetCore.Mvc;

namespace lab_9.Models;

public interface IBookService
{
    public Book? Save(Book? book);

    public Task<Book?> SaveAsync(Book? book);

    public bool Delete(int? id);

    public bool Update(Book? book);

    public Book? FindBy(int? id);

    public IEnumerable<Book?> FindAll();

    public ICollection<Book> FindByAuthor(Author author);

    public PagingList<Book> FindPage(int page, int size);
    
    public (string Error, int Age) BookAge(int? id);

    public ICollection<Author> AuthorsBookById(int id);
}