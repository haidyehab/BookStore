using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext _dbContext;

        public BookService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Book model)
        {
            try
            {
                _dbContext.Books.Add(model);
                _dbContext.SaveChanges();
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
                var data = this.FindById(id);
                if (data == null)
                    return false;
                _dbContext.Books.Remove(data);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Book FindById(int id)
        {
            return _dbContext.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _dbContext.Books
                        join author in _dbContext.Authors
                       on book.AuthorId equals author.Id
                        join publisher in _dbContext.Publisher on book.PublisherId equals publisher.Id
                        join genre in _dbContext.Genres on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.GenreId,
                            Isbn = book.Isbn,
                            PublisherId = publisher.Id,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName
                        }).ToList();
            return data;
        }


        public bool Update(Book model)
        {
            try
            {
                _dbContext.Books.Update(model);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
