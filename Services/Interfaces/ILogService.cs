namespace UsuariosApi.Services.Interfaces
{
    public interface ILogService
    {
        Task RegistrarLog(object data);
        Task<string> ObtenerLogs();
    }
}