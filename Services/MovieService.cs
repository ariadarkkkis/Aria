
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Contracts;
using Entites;
using Microsoft.EntityFrameworkCore;
using System;

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
            var movie = await _context.Movies.FindAsync(id);
            
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
        public async Task<Movie> GetById(int id)
            => await _context.Movies.FindAsync(id);
        
        // Get All
        public async Task<IEnumerable<Movie>> GetAll()
            => await _context.Movies.ToListAsync();

        // Update
        public async Task<bool> Update(Movie movie) 
        {
            var movieEntity = await _context.Movies.SingleOrDefaultAsync(m => m.Id == movie.Id);
            if (movieEntity != null)
            {
                movieEntity.Name = movie.Name;
                movieEntity.Imdb = movie.Imdb;
                movieEntity.Year = movie.Year;
                movieEntity.ReleaseDate = movie.ReleaseDate;
                movieEntity.Description = movie.Description;
                movieEntity.MovieCategories = movie.MovieCategories;

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
            
    }
}
