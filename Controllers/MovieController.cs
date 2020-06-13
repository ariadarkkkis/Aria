using System.Threading.Tasks;
using Contracts;
using Entites;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("/api/[controller]")]
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
        [HttpGet("Id")]
        public async Task<IActionResult> GetMovieById([FromQuery]int id)
            => Ok(await _service.GetById(id));

        // Add
        [HttpPost("Add")]
        //[ModelValidator]
        [Produces(typeof(bool))]
        public async Task<IActionResult> AddMovie([FromBody]Movie movie)
            => Ok(await _service.Add(movie));

        // Update an entry
        [HttpPut("Update/{id:int}")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> UpdateMovie([FromQuery]int id, [FromBody]Movie movie)
            => Ok(await _service.Update(id, movie));

        // Delete an entry
        [HttpDelete("Delete/{id:int}")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> DeleteMovie([FromQuery]int id)
            => Ok(await _service.Delete(id));

        

    }
}
