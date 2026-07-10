using librosApi.Domain;
using Microsoft.EntityFrameworkCore;
using librosApi.Repository.Interfaces;

namespace librosApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DbcontextBooks _context;

        public BookRepository(DbcontextBooks context)
        {
            _context = context;
        }


        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> InsertBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
