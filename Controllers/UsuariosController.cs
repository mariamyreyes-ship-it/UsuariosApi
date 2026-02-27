using Microsoft.AspNetCore.Mvc;
using UsuariosApi.DTOs;
using UsuariosApi.Services.Interfaces;

namespace UsuariosApi.Controllers
{
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
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _service.GetById(id);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioCreateDto dto)
        {
            try
            {
                var usuario = await _service.Create(dto);
                return CreatedAtAction(nameof(Get),
                    new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuariosApi.DTOs.UsuarioUpdateDto dto)
        {
            var updated = await _service.Update(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
