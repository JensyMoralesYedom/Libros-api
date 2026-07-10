using librosApi.Domain;

namespace librosApi.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthors();
        Task<Author> GetAuthorById(int id);
        Task<Author> InsertAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        Task DeleteAuthor(int id);
    }
}
