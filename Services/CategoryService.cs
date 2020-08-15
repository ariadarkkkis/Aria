using System.Collections.Generic;
using System.Threading.Tasks;
using Aria.Contracts;
using Aria.DTOs;
using AutoMapper;
using Aria.Context;
using Aria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aria.Services 
{
    public class CategoryService : ICategoryService 
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CategoryService> _logger;
        private readonly IMapper _mapper;
        public CategoryService (AppDbContext context,
            ILogger<CategoryService> logger,
            IMapper mapper) 
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
        }
        public async Task<bool> Add(CategoryCreationDTO categoryCreationDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryCreationDTO);
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Movie with ID {category.Id} was added.");
                return true;
            }
            catch (DbUpdateConcurrencyException e)
            {
                _logger.LogWarning($"There was an exception while adding movie with ID {categoryCreationDTO.Id}. Exception:{e}");
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                _logger.LogWarning($"Movie with ID {id} was not found.");
                return false;
            }
            else
            {
                try
                {
                    _context.Remove(category);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Movie with ID {category.Id} was deleted.");
                    return true;
                }
                catch (DbUpdateConcurrencyException e)
                {
                    _logger.LogWarning($"There was an exception while deleting movie with ID {category.Id}. Exception:{e}");
                    return false;
                }
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            _logger.LogInformation($"GetAll has been called.");

            var categories = await _context.Categories.ToListAsync();
            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return categoriesDTO;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            _logger.LogInformation($"GetById on ID {id} has been called.");
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id); // Needs to check if the ID exists
            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return categoryDTO;
        }

        public async Task<bool> Update(CategoryCreationDTO categoryCreationDTO)
        {
            var categoryEntity = await _context.Categories.SingleOrDefaultAsync(m => m.Id == categoryCreationDTO.Id);
            if (categoryEntity == null) return false;
            _mapper.Map<CategoryCreationDTO, Category>(categoryCreationDTO, categoryEntity);
            
            return ((await _context.SaveChangesAsync()) > 0);
        }
    }
}