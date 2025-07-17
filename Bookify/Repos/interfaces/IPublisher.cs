using Bookify.Models.Entity;

namespace Bookify.Repos.interfaces
{
    public interface IPublisher
    {
        bool Add(Publisher publisher);
        bool Update(Publisher publisher);
        bool Delete(int id);
        Publisher GetPublisherById(int id);
        IEnumerable<Publisher> GetPublishers();
    }
}
