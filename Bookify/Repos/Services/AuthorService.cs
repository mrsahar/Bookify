using Bookify.Data;
using Bookify.Models.Entity;
using Bookify.Repos.interfaces;

namespace Bookify.Repos.Services
{
    public class AuthorService : IAuthor
    {
        private readonly BookifyDbContex contex;

        public AuthorService(BookifyDbContex contex)
        {
            this.contex = contex;
        }
        public bool Add(Author author)
        {
            try
            {
                contex.Add(author);
                contex.SaveChanges();
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
                var data = GetById(id);
                if (data is null)
                {
                    return false;
                }
                contex.Remove(data);
                contex.SaveChanges(); return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<Author> GetAll()
        {
            return contex.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return contex.Authors.Find(id);
        }

        public bool Update(Author author)
        {
            try
            {
                contex.Update(author);
                contex.SaveChanges(); return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
