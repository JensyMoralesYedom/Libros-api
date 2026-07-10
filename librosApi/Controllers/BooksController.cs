using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using librosApi.Repository.Interfaces;
using librosApi.Domain;

namespace librosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetBooks();
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            var createdBook = await _bookRepository.InsertBook(book);
            return CreatedAtAction(nameof(GetByID), new { id = createdBook.Id }, createdBook);
        }
        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Book book)
        {
            if (book == null || id != book.Id)
            {
                return BadRequest();
            }

            var updatedBook = await _bookRepository.UpdateBook(book);

            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBook(id);

            return Ok(book);
        }


    }
}
