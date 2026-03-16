using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UsuariosApi.DTOs;
using UsuariosApi.Services.Interfaces;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetById(id);
            return user == null ? NotFound() : Ok(user);
        }
    }
}