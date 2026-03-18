using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.DTOs;

namespace UsuariosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProveedoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProveedoresController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProveedorReadDto>>> GetAll()
    {
        return await _context.Proveedores
            .Select(p => new ProveedorReadDto(p.Id, p.Nombre, p.Contacto))
            .ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProveedorCreateDto dto)
    {
        var proveedor = new Proveedor { Nombre = dto.Nombre, Contacto = dto.Contacto };
        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync();
        return Ok(new ProveedorReadDto(proveedor.Id, proveedor.Nombre, proveedor.Contacto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var prov = await _context.Proveedores.FindAsync(id);
        if (prov == null) return NotFound();
        _context.Proveedores.Remove(prov);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}