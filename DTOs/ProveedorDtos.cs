namespace UsuariosApi.DTOs;

public record ProveedorCreateDto(string Nombre, string Contacto);
public record ProveedorReadDto(int Id, string Nombre, string Contacto);