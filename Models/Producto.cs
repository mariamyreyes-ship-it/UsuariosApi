using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuariosApi.Models;

public class Producto
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public int IdCategoria { get; set; }
    [ForeignKey("IdCategoria")]
    public Categoria? Categoria { get; set; }

    public int IdProveedor { get; set; }
    [ForeignKey("IdProveedor")]
    public Proveedor? Proveedor { get; set; }
}