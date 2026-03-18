using System.ComponentModel.DataAnnotations;
namespace UsuariosApi.Models;

public class Proveedor
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;
    public string Contacto { get; set; } = string.Empty;

    public List<Producto> Productos { get; set; } = new();
}
