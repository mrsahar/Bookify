using Bookify.Data;
using Bookify.Models.Entity;
using Bookify.Repos.interfaces;

namespace Bookify.Repos.Services
{
    public class PublisherService : IPublisher
    {
        private readonly BookifyDbContex dbContex;

        public PublisherService(BookifyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }
        public bool Add(Publisher publisher)
        {
            try
            {
                dbContex.Add(publisher);
                dbContex.SaveChanges();
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
                var record = GetPublisherById(id);
                if (record is not null)
                {
                    dbContex.Remove(record);
                    dbContex.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public Publisher GetPublisherById(int id)
        {
            return dbContex.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return dbContex.Publishers.ToList();
        }

        public bool Update(Publisher publisher)
        {
            try
            {
                var record = dbContex.Publishers.Update(publisher);
                dbContex.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
