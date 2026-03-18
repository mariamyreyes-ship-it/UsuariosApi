using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.DTOs;

namespace UsuariosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaReadDto>>> GetAll()
    {
        return await _context.Categorias
            .Select(c => new CategoriaReadDto(c.Id, c.Nombre))
            .ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoriaCreateDto dto)
    {
        var categoria = new Categoria { Nombre = dto.Nombre };
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return Ok(new CategoriaReadDto(categoria.Id, categoria.Nombre));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cat = await _context.Categorias.FindAsync(id);
        if (cat == null) return NotFound();
        _context.Categorias.Remove(cat);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}