using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly DatabaseContext _dbContext;

        public PublisherService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Publisher model)
        {
            try
            {
                _dbContext.Publisher.Add(model);
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
                _dbContext.Publisher.Remove(data);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Publisher FindById(int id)
        {
            return _dbContext.Publisher.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _dbContext.Publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                _dbContext.Publisher.Update(model);
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
