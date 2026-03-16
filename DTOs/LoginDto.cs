namespace UsuariosApi.DTOs
{
    public record LoginDto(string Correo, string Password);
    public record TokenResponseDto(string Token, string RefreshToken);
}