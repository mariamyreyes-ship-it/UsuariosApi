using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsuariosApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuariosApi.DTOs.UsuarioReadDto>> GetAll();
        Task<UsuariosApi.DTOs.UsuarioReadDto?> GetById(int id);
        Task<UsuariosApi.DTOs.UsuarioReadDto> Create(UsuariosApi.DTOs.UsuarioCreateDto dto);
        Task<bool> Update(int id, UsuariosApi.DTOs.UsuarioUpdateDto dto);
        Task<bool> Delete(int id);
    }
}