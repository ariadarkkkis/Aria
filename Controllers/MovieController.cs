using System.Threading.Tasks;
using Aria.DTOs;
using Contracts;
using Entites;
using Microsoft.AspNetCore.Mvc;

namespace Aria.Controllers
{
    [Route("/api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            this._service = service;
        }

        // Get all entries
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
            => Ok(await _service.GetAll());

        // Get entry by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Add
        [HttpPost("Add")]
        //[ModelValidator]
        [Produces(typeof(bool))]
        public async Task<IActionResult> AddMovie([FromBody]MovieCreationDTO movieCreationDTO)
            => Ok(await _service.Add(movieCreationDTO));

        // Update an entry
        [HttpPut("Update")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> UpdateMovie([FromBody]MovieCreationDTO movieCreationDTO)
            => Ok(await _service.Update(movieCreationDTO));

        // Delete an entry
        [HttpDelete("Delete/{id:int}")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> DeleteMovie(int id)
            => Ok(await _service.Delete(id));
    }
}
