
using System.Collections.Generic;
using System.Threading.Tasks;
using Context;
using Contracts;
using Entites;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            this._context = context;
        }

        public Task<bool> AddMovie()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteMovie(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetMovieById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMovies()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateMovie()
        {
            throw new System.NotImplementedException();
        }
    }
}
