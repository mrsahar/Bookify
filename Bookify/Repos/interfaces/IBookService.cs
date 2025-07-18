using Bookify.Models.Entity;

namespace Bookify.Repos.interfaces
{
    public interface IBookService
    {
        bool Add(Book book);
        bool Update(Book book);
        bool Delete(int id);
        Book findById(int id);
        IEnumerable<Book> GetBooks();


    }
}
