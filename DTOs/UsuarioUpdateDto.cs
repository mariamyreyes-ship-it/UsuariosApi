using System;

namespace UsuariosApi.DTOs
{
    public class UsuarioUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime FechaDeNacimiento { get; set; }
    }
}