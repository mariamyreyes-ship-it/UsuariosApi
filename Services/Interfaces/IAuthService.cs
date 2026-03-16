using UsuariosApi.DTOs;

namespace UsuariosApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponseDto?> Login(LoginDto dto);
        Task<TokenResponseDto?> RefreshToken(string refreshToken);
    }
}