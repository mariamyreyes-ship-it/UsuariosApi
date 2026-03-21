using System.Text.Json;
using UsuariosApi.Services.Interfaces;

namespace UsuariosApi.Services
{
    public class LogService : ILogService
    {
        private readonly string _filePath = "logs_usuarios.txt";

        public async Task RegistrarLog(object data)
        {
            // Creamos el objeto con timestamp
            var logEntry = new
            {
                Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Evento = "Registro de Usuario",
                Datos = data
            };

            // Serializamos a una sola línea para que cada log sea independiente
            string jsonLog = JsonSerializer.Serialize(logEntry) + Environment.NewLine;

            // AppendAllTextAsync crea el archivo si no existe
            await File.AppendAllTextAsync(_filePath, jsonLog);
        }

        public async Task<string> ObtenerLogs()
        {
            if (!File.Exists(_filePath)) return "[]";

            var lineas = await File.ReadAllLinesAsync(_filePath);
            // Convertimos las líneas en un array JSON válido
            return "[" + string.Join(",", lineas) + "]";
        }
    }
}