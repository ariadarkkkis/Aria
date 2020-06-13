using System.Collections.Generic;
using System.Threading.Tasks;
using Entites;

namespace Contracts
{
    public interface IMovieService
    {
        Task<bool> Add(Movie movie);
        Task<bool> Update(Movie movie);
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task<bool> Delete(int id);
    }
}
