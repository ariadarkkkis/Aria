using System.Collections.Generic;
using System.Threading.Tasks;
using Aria.DTOs;
using Entites;

namespace Aria.Contracts
{
    public interface ICategoryService
    {
        Task<bool> Add(CategoryCreationDTO categoryCreationDTO);
        Task<bool> Update(CategoryCreationDTO categoryCreationDTO);
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
    }
}