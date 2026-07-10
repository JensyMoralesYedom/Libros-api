using Microsoft.AspNetCore.Mvc;
using librosApi.Domain;
using librosApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace librosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAuthors();
            return Ok(authors);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var createdAuthor = await _authorRepository.InsertAuthor(author);
            return CreatedAtAction(nameof(Get), new { id = createdAuthor.Id }, createdAuthor);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Author author)
        {
            if (author == null || author.Id != id)
            {
                return BadRequest();
            }

            var existingAuthor = await _authorRepository.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            var updatedAuthor = await _authorRepository.UpdateAuthor(author);
            return Ok(updatedAuthor);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingAuthor = await _authorRepository.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            await _authorRepository.DeleteAuthor(id);
            return NoContent();
        }
    }
}
