using System.Collections.Generic;
using System.Threading.Tasks;
using Aria.DTOs;
using Aria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Aria.Contracts
{
    public interface IMovieService
    {
        Task<bool> Add(MovieCreationDTO movieCreationDTO);
        Task<bool> Update(MovieCreationDTO movieCreationDTO);
        Task<IEnumerable<MovieDTO>> GetAll();
        Task<MovieDTO> GetById(int id);
        Task<bool> Delete(int id);
    }
}
