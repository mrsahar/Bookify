using Bookify.Models.Entity;

namespace Bookify.Repos
{
    public interface IGenresService
    {
        bool Add(Genre genre);
        bool Update(Genre genre);
        bool Delete(int id);
        Genre GetById(int id);
        IEnumerable<Genre> GetAll();
    }
}
