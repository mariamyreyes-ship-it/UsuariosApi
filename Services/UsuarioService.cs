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

        public UsuarioService(AppDbContext context)
        {
            _context = context;
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
            if (await _context.Usuarios.AnyAsync(u => u.Correo == dto.Correo))
                throw new Exception("El correo ya está en uso");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                FechaDeNacimiento = dto.FechaDeNacimiento,
                PasswordHash = "TemporalHash" 
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioReadDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                FechaDeNacimiento = usuario.FechaDeNacimiento
            };
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