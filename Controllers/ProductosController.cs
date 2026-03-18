using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.DTOs;

namespace UsuariosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductosController(AppDbContext context) => _context = context;

    // 1. Endpoint Único de Agregación
    [HttpGet("estadisticas")]
    public async Task<IActionResult> GetStats()
    {
        var productos = await _context.Productos.ToListAsync();
        if (!productos.Any()) return NotFound("No hay productos registrados");

        var stats = new ProductoStatsDto(
            ProductoMasCaro: productos.OrderByDescending(p => p.Precio).First().Nombre,
            ProductoMasBarato: productos.OrderBy(p => p.Precio).First().Nombre,
            SumaTotalPrecios: productos.Sum(p => p.Precio),
            PrecioPromedio: productos.Average(p => p.Precio)
        );

        return Ok(stats);
    }

    // 2. Cantidad total de productos
    [HttpGet("total-cantidad")]
    public async Task<IActionResult> GetTotalCount()
        => Ok(new { Total = await _context.Productos.CountAsync() });

    // 3. Productos por Categoría
    [HttpGet("categoria/{idCategoria}")]
    public async Task<IActionResult> GetByCategoria(int idCategoria)
    {
        return Ok(await _context.Productos
            .Where(p => p.IdCategoria == idCategoria)
            .ToListAsync());
    }

    // 4. Productos por Proveedor
    [HttpGet("proveedor/{idProveedor}")]
    public async Task<IActionResult> GetByProveedor(int idProveedor)
    {
        return Ok(await _context.Productos
            .Where(p => p.IdProveedor == idProveedor)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Producto producto)
    {
   
        var existeCat = await _context.Categorias.AnyAsync(c => c.Id == producto.IdCategoria);
        var existeProv = await _context.Proveedores.AnyAsync(p => p.Id == producto.IdProveedor);

        if (!existeCat || !existeProv)
            return BadRequest("Categoría o Proveedor no válidos.");

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return Ok(producto);
    }
}