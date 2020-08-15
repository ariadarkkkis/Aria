using System.Threading.Tasks;
using Aria.Contracts;
using Aria.DTOs;
using Entites;
using Microsoft.AspNetCore.Mvc;

namespace Aria.Controllers 
{
    [Route("/api/category")]
    public class CategoryController : ControllerBase 
    {
        private readonly ICategoryService _service;
        public CategoryController (ICategoryService service) 
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
            => Ok(await _service.GetAll());

        // Get entry by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
            => Ok(await _service.GetById(id));

        // Add
        [HttpPost("Add")]
        //[ModelValidator]
        [Produces(typeof(bool))]
        public async Task<IActionResult> AddCategory([FromBody] CategoryCreationDTO categoryCreationDTO)
            => Ok(await _service.Add(categoryCreationDTO));

        // Update an entry
        [HttpPut("Update")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryCreationDTO categoryCreationDTO)
            => Ok(await _service.Update(categoryCreationDTO));

        // Delete an entry
        [HttpDelete("Delete/{id:int}")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> DeleteCategory(int id)
            => Ok(await _service.Delete(id));
    }
}