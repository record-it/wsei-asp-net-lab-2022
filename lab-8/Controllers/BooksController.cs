using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab_8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab_8
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;
        // GET: api/Books
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.FindAll();
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(int id)
        {
            return _bookService.FindBy(id);
        }

        // POST: api/Books
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            _bookService.Save(book);
            return Created("", book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            book.Id = (int) id;
            if ( _bookService.Update(book))
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
