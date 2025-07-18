using Bookify.Data;
using Bookify.Models.Entity;
using Bookify.Repos.interfaces;

namespace Bookify.Repos.Services
{
    public class BookService : IBookService
    {
        private readonly BookifyDbContex context;

        public BookService(BookifyDbContex context)
        {
            this.context = context;
        }
        public bool Add(Book Book)
        {
            try
            {
                context.Add(Book);
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
                var data = findById(id);
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

        public IEnumerable<Book> GetBooks()
        {
            var data = (from book in context.Books
                        join author in context.Authors on book.AuthorId equals author.AuthorId
                        join genre in context.Genres on book.GenreID equals genre.GenreID
                        join publisher in context.Publishers on book.PublisherID equals publisher.PublisherId
                        select new Book
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Isbn = book.Isbn,
                            TotalPages = book.TotalPages,
                            GenreID = book.GenreID,
                            PublisherID = book.PublisherID,
                            AuthorId = book.AuthorId,
                            AuthorName = author.AuthorName,
                            GenreName = genre.Name,
                            PublisherName = publisher.PublisherName
                        }).ToList();
            return data;
        }

        public Book findById(int id)
        {
            return context.Books.Find(id);
        }

        public bool Update(Book Book)
        {
            try
            {
                context.Update(Book);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
