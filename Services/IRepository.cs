using BooksAPI.Entitites;

namespace BooksAPI.Services
{
    public interface IRepository
    {
        void addBook(Book book);
        Task<List<Book>> GetAllBooks();
        Book GetBookById(int id);
    }
}
