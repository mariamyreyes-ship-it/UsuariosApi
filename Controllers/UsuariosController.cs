using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.DTOs;
using UsuariosApi.Services.Interfaces;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly ILogService _logService; 

    public UsuariosController(IUsuarioService service, ILogService logService)
    {
        _service = service;
        _logService = logService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAll());

    [HttpPost]
    [AllowAnonymous] 
    public async Task<IActionResult> Create([FromBody] UsuarioCreateDto dto)
    {
        try
        {
            var result = await _service.Create(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("logs")]
    public async Task<IActionResult> GetLogs()
    {
        var logs = await _logService.ObtenerLogs();
        return Content(logs, "application/json");
    }
}