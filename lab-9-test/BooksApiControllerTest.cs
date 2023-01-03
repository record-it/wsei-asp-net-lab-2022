using lab_9.Controllers;
using lab_9.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Assert = Xunit.Assert;


namespace lab_9_test;

public class Tests
{

    private IBookService service = new TestBookService();
    private BooksController controller;

    public Tests()
    {
        controller = new BooksController(service, null);
        service.Save(new Book() {Title = "Java", ReleaseDate = new DateTime(2000, 10, 10), Created = DateTime.Now});
        service.Save(new Book() {Title = "C#", ReleaseDate = new DateTime(2001, 10, 10), Created = DateTime.Now});
        service.Save(new Book() {Title = "JavaScript", ReleaseDate = new DateTime(2002, 10, 10), Created = DateTime.Now});
        service.Save(new Book() {Title = "Go", ReleaseDate = new DateTime(2003, 10, 10), Created = DateTime.Now});
    }

    //Test xUnit
    [Xunit.Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public async void TestBooksControllerGet(int id)
    {
        Book createdBook = new Book() {Title = "Nowa", ReleaseDate = new DateTime(2020, 10, 10)};
        var task =  await controller.GetBook(id);
        ActionResult<Book> actionResult = Assert.IsType<ActionResult<Book>>(task);
        Book book = Assert.IsType<Book>(actionResult.Value);
        Assert.Equal(book.Id, service.FindBy(book.Id).Id);
    }

    [Fact]
    public async void TestBooksControllerDelete()
    {
        Book createdBook = new Book() {Title = "Nowa", ReleaseDate = new DateTime(2020, 10, 10)};
        var task =  await controller.DeleteBook(1);
        NoContentResult noContentResult = Assert.IsType<NoContentResult>(task);
        var book = service.FindBy(1);
        Assert.Null(book);
    }
    
    [Fact]
    public async void TestBooksControllerGetAll()
    {
        var task =  await controller.GetBooks();
        ActionResult<IEnumerable<Book>> result = Assert.IsType<ActionResult<IEnumerable<Book>>>(task);
        IEnumerable<Book> books = Assert.IsAssignableFrom<IEnumerable<Book>>(result.Value);
        Assert.Equal(4, books.Count());
    }
    
    [Fact]
    public async void TestBooksControllerPost()
    {
        BookDto createdBook = new BookDto() {Id = 1, Title = "Nowa", ReleaseDate = new DateTime(2020, 10, 10)};
        var task =  await controller.PostBook(createdBook);
        var createdResult = Assert.IsType<ActionResult<Book>>(task);
        Assert.NotNull(service.FindBy(createdBook.Id));
    }
}