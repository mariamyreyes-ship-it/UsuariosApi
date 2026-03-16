using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data;
using UsuariosApi.DTOs;
using UsuariosApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IAuthService _authService;

    public AuthController(AppDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var result = await _authService.Login(login);
        if (result == null) return Unauthorized("Credenciales incorrectas");

        return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] string refreshToken)
    {
        var result = await _authService.RefreshToken(refreshToken);
        if (result == null) return BadRequest("Token inválido o expirado");

        return Ok(result);
    }
}