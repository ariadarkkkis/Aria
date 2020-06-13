
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

        // Add
        public async Task<bool> Add(Movie movie)
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

        // Delete
        public async Task<bool> Delete(int id)
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

        // Get by ID
        public async Task<Movie> GetById(int id) =>
            await _context.Movies
                .SingleOrDefaultAsync(m => m.Id == id);
        
        // Get All
        public async Task<IEnumerable<Movie>> GetAll() =>
            await _context.Movies.ToListAsync();

        // Update
        public async Task<bool> Update(int id, Movie movie) 
        {
            if (id != movie.Id)
                return false;

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
