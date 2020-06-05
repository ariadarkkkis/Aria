
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Contracts;
using Entites;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            this._context = context;
        }

        

        public Task<bool> AddMovie(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(m => m.Id == id);
            try
            {
                _context.Remove(movie);
                return true;
            }
            catch (System.Exception )
            {
                return false;
            }
        }

        public async Task<Movie> GetMovieById(int id) =>
            await _context.Movies
                .SingleOrDefaultAsync(m => m.Id == id);
        

        public async Task<IEnumerable<Movie>> GetMovies() =>
            await _context.Movies.ToListAsync();

        public async Task<bool> UpdateMovie(Movie movie) 
        {
            var findMovie = await _context.Movies
                .SingleOrDefaultAsync(m => m.Id == movie.Id);
        }
            
    }
}
