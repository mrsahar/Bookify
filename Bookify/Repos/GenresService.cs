using Bookify.Data;
using Bookify.Models.Entity;

namespace Bookify.Repos
{
    public class GenresService : IGenresService
    {
        private readonly BookifyDbContex context;

        public GenresService(BookifyDbContex context)
        {
            this.context = context;
        }
        public bool Add(Genre book)
        {
            try
            {
                context.Add(book);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                context.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Genre GetById(int id)
        {
            return context.Genres.Find(id);
        }

        public bool Update(Genre genre)
        {
            try
            {
                context.Update(genre);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        IEnumerable<Genre> IGenresService.GetAll()
        {
            return context.Genres.ToList();
        }
    }
}
