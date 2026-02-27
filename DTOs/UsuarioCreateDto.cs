using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.DTOs
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; } = string.Empty;

        public DateTime FechaDeNacimiento { get; set; }
    }
}
