using Contracts;
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
    }
}
