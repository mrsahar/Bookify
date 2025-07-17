using Bookify.Data;
using Bookify.Models.Entity;
using Bookify.Repos.interfaces;

namespace Bookify.Repos.Services
{
    public class AuthorService : IAuthor
    {
        private readonly BookifyDbContex context;

        public AuthorService(BookifyDbContex context)
        {
            this.context = context;
        }
        public bool Add(Author author)
        {
            try
            {
                context.Add(author);
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
                var data = GetById(id);
                if (data is null)
                {
                    return false;
                }
                context.Remove(data);
                context.SaveChanges(); return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<Author> GetAll()
        {
            return context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return context.Authors.Find(id);
        }

        public bool Update(Author author)
        {
            try
            {
                context.Update(author);
                context.SaveChanges(); return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
