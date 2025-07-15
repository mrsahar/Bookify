using Bookify.Models.Entity;

namespace Bookify.Repos.interfaces
{
    public interface IAuthor
    {
        bool Add(Author author);
        bool Update(Author author);
        bool Delete(int id);
        Author GetById(int id);
        IEnumerable<Author> GetAll();
    }
}
