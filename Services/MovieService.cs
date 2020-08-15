
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
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aria.DTOs;
using AutoMapper.QueryableExtensions;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MovieService> _logger;
        private readonly IMapper _mapper;

        public MovieService(AppDbContext context,
            ILogger<MovieService> logger,
            IMapper mapper)
        {
            this._logger = logger;
            this._context = context;
            this._mapper = mapper;
        }

        // Add
        public async Task<bool> Add(MovieCreationDTO movieCreationDTO)
        {
            try
            {
                var movie = _mapper.Map<Movie>(movieCreationDTO);
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Movie with ID {movie.Id} was added.");
                return true;
            }
            catch (DbUpdateConcurrencyException e)
            {
                _logger.LogWarning($"There was an exception while adding movie with ID {movieCreationDTO.Id}. Exception:{e}");
                return false;
            }
        }

        // Delete
        public async Task<bool> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                _logger.LogWarning($"Movie with ID {id} was not found.");
                return false;
            }
            else
            {
                try
                {
                    _context.Remove(movie);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Movie with ID {movie.Id} was deleted.");
                    return true;
                }
                catch (DbUpdateConcurrencyException e)
                {
                    _logger.LogWarning($"There was an exception while deleting movie with ID {movie.Id}. Exception:{e}");
                    return false;
                }
            }
        }

        // Get by ID
        public async Task<MovieDTO> GetById(int id)
        {
            _logger.LogInformation($"GetById on ID {id} has been called.");
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id); // Needs to check if the ID exists
            var movieDTO = _mapper.Map<MovieDTO>(movie);
            //var movieDTO = await _context.Movies.ProjectTo<MovieDTO>().AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
            return movieDTO;
        }

        // Get All
        public async Task<IEnumerable<MovieDTO>> GetAll()
        {
            _logger.LogInformation($"GetAll has been called.");

            var movies = await _context.Movies.ToListAsync();
            var moviesDTO = _mapper.Map<IEnumerable<MovieDTO>>(movies);

            return moviesDTO;
        }

        // Update
        public async Task<bool> Update(MovieCreationDTO movieCreationDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreationDTO);
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

                _logger.LogInformation($"Movie with ID {movieCreationDTO.Id} has been updated.");
                return true;
            }
            else
            {
                _logger.LogWarning($"Movie with ID {movieCreationDTO.Id} was not found.");
                return false;
            }
        }
    }
}
