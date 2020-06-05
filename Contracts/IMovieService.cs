using System.Collections.Generic;
using System.Threading.Tasks;
using Entites;

namespace Contracts
{
    public interface IMovieService
    {
        Task<bool> AddMovie(Movie movie);
        Task<bool> UpdateMovie(Movie movie);
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<bool> DeleteMovie(int id);
    }
}
