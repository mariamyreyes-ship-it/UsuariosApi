namespace UsuariosApi.DTOs;

public record CategoriaCreateDto(string Nombre);
public record CategoriaReadDto(int Id, string Nombre);