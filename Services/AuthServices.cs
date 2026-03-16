using UsuariosApi.Data;
using UsuariosApi.DTOs;
using UsuariosApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<TokenResponseDto?> Login(LoginDto dto)
        {
            await Task.Yield();
            return null;
        }

        public async Task<TokenResponseDto?> RefreshToken(string refreshToken)
        {
            await Task.Yield();
            return null;
        }
    }
}