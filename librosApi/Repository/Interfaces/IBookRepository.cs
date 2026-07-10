using librosApi.Domain;

namespace librosApi.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<Book> InsertBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
