using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.DTOs;
using UsuariosApi.Models;
using UsuariosApi.Services.Interfaces;

namespace UsuariosApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly ILogService _logService;

        public UsuarioService(AppDbContext context, ILogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<IEnumerable<UsuarioReadDto>> GetAll()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioReadDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    FechaDeNacimiento = u.FechaDeNacimiento
                })
                .ToListAsync();
        }

        public async Task<UsuarioReadDto?> GetById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return null;

            return new UsuarioReadDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                FechaDeNacimiento = usuario.FechaDeNacimiento
            };
        }

        public async Task<UsuarioReadDto> Create(UsuarioCreateDto dto)
        {
            // 1. Validar si el correo ya existe en la BD
            if (await _context.Usuarios.AnyAsync(u => u.Correo == dto.Correo))
                throw new Exception("El correo ya está en uso");

            // 2. Mapear DTO a Modelo y Hashear password
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                FechaDeNacimiento = dto.FechaDeNacimiento,
                PasswordHash = SecurityHelper.HashPassword("Temporal123")
            };

            // 3. Guardar en Base de Datos
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // 4. Preparar el DTO de respuesta
            var result = new UsuarioReadDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                FechaDeNacimiento = usuario.FechaDeNacimiento
            };

            // 5. Registrar la operación en el Log de texto (JSON)
            // Se realiza después del SaveChanges para asegurar que el ID ya fue generado
            await _logService.RegistrarLog(result);

            return result;
        }

        public async Task<bool> Update(int id, UsuarioUpdateDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            usuario.Nombre = !string.IsNullOrEmpty(dto.Nombre) ? dto.Nombre : usuario.Nombre;
            usuario.Correo = !string.IsNullOrEmpty(dto.Correo) ? dto.Correo : usuario.Correo;
            usuario.FechaDeNacimiento = dto.FechaDeNacimiento;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}