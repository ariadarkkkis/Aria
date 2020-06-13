
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

        public async Task<bool> AddMovie(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(m => m.Id == id);
            try
            {
                _context.Remove(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
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
            _context.Entry(movie).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Movies.Find(movie.Id) == null)
                {
                    return false;
                }
            }
            return false;
        }
            
    }
}
