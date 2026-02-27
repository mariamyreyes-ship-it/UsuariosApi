using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Correo { get; set; } = string.Empty;

        public DateTime FechaDeNacimiento { get; set; }
    }
}