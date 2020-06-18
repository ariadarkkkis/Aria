
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Contracts;
using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MovieService> logger;

        public MovieService(AppDbContext context, ILogger<MovieService> logger)
        {
            this.logger = logger;
            this._context = context;
        }

        // Add
        public async Task<bool> Add(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                logger.LogInformation($"Movie with ID {movie.Id} was added.");
                return true;
            }
            catch (DbUpdateConcurrencyException e)
            {
                logger.LogWarning($"There was an exception while adding movie with ID {movie.Id}. Exception:{e}");
                return false;
            }
        }

        // Delete
        public async Task<bool> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                logger.LogWarning($"Movie with ID {id} was not found.");
                return false;
            }
            else
            {
                try
                {
                    _context.Remove(movie);
                    await _context.SaveChangesAsync();
                    logger.LogInformation($"Movie with ID {movie.Id} was deleted.");
                    return true;
                }
                catch (DbUpdateConcurrencyException e)
                {
                    logger.LogWarning($"There was an exception while deleting movie with ID {movie.Id}. Exception:{e}");
                    return false;
                }
            }
        }

        // Get by ID
        public async Task<Movie> GetById(int id)
        {
            logger.LogInformation($"GetById on ID {id} has been called.");
            return await _context.Movies.FindAsync(id);
        }

        // Get All
        public async Task<IEnumerable<Movie>> GetAll()
        {
            logger.LogInformation($"GetAll has been called.");
            return await _context.Movies.ToListAsync();
        }

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

                logger.LogInformation($"Movie with ID {movie.Id} has been updated.");
                return true;
            }
            else
            {
                logger.LogWarning($"Movie with ID {movie.Id} was not found.");
                return false;
            }
        }

    }
}
