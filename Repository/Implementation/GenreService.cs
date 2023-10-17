using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
	public class GenreService : IGenreService
	{
		private readonly DatabaseContext _dbContext;

		public GenreService(DatabaseContext dbContext)
        {
			_dbContext = dbContext;
		}
        public bool Add(Genre model)
		{
			try
			{
				_dbContext.Genres.Add(model);
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
				if(data == null) 
					return false;
				_dbContext.Genres.Remove(data);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}

		public Genre FindById(int id)
		{
			return _dbContext.Genres.Find(id);
		}

		public IEnumerable<Genre> GetAll()
		{
		 return _dbContext.Genres.ToList();
		}

		public bool Update(Genre model)
		{
			try{
				_dbContext.Genres.Update(model);
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
