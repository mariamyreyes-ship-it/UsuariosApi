namespace UsuariosApi.DTOs;

public record ProductoStatsDto(
    string ProductoMasCaro,
    string ProductoMasBarato,
    decimal SumaTotalPrecios,
    decimal PrecioPromedio
);
