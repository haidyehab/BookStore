using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly DatabaseContext _dbContext;

        public AuthorService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Author model)
        {
            try
            {
                _dbContext.Authors.Add(model);
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
                _dbContext.Authors.Remove(data);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Author FindById(int id)
        {
            return _dbContext.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbContext.Authors.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                _dbContext.Authors.Update(model);
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
