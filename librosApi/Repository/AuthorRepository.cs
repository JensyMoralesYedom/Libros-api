using librosApi.Domain;
using librosApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace librosApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DbcontextBooks _context;

        public AuthorRepository(DbcontextBooks context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }


        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task<Author> InsertAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task DeleteAuthor(int id)
        {
            Author author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
