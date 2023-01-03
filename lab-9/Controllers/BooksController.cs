using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab_9.Models;

namespace lab_9.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly AppDbContext _context;
        public BooksController(IBookService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }
        
        [HttpGet]
        [Route("{id}/authors")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetBookAuthors([FromRoute] int id)
        {
            if (_service.FindBy(id) is null)
            {
                return NotFound();
            }
            var authors = _service.AuthorsBookById(id);
            return new ActionResult<IEnumerable<AuthorDto>>(authors.Select(AuthorDto.from));
        }
        
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book?>>> GetBooks()
        {
            if (_service is null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<Book?>>(_service.FindAll());
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (_service == null)
            {
                return NotFound();
            }

            var book = _service.FindBy(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book? book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            book.Id = id;
            _service.Update(book);
            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDto book)
        {
            if (_service == null)
            {
                return Problem("Entity set 'AppDbContext.Books'  is null.");
            }

            if (ModelState.IsValid)
            {
                var saved = _service.Save(book.MapTo());
                return Created($"/api/books/{saved.Id}", saved);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_service == null)
            {
                return NotFound();
            }
            var book = _service.Delete(id);
            if (book == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}