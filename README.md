README.md
# UsuariosApi - Gestión de Usuarios con ASP.NET Core
Esta es una API REST desarrollada con **.NET 10** para la gestión de usuarios. Utiliza Entity Framework Core con SQLite como base de datos y sigue una arquitectura en capas (Controladores, Servicios, DTOs y Modelos).
## Características
- CRUD Completo: Crear, Leer, Actualizar y Eliminar usuarios.
- Validación de Datos: Validación de correo electrónico y campos obligatorios.
- Restricción de Unicidad: Evita registros duplicados de correos electrónicos a nivel de base de datos.
- Documentación Interactiva: Integración con Swagger UI.

## Tecnologías Utilizadas
- ASP.NET Core 10
- Entity Framework Core (SQLite)
- Swagger / OpenAPI

## Requisitos Previos
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2022/2026 o VS Code.

## Configuración y Ejecución
1.	Clonar el repositorio (o descargar el código):
   ```bash
   git clone [https://github.com/TU_USUARIO/UsuariosApi.git](https://github.com/TU_USUARIO/UsuariosApi.git)
   cd UsuariosApi

2.	Restaurar dependencias
dotnet restore

3.	Ejecutar migraciones (para crear la base de datos local):
dotnet ef database update

4.	Iniciar la aplicación:
dotnet run
## Cómo Probar la API
Opción 1: Swagger 
Una vez que la aplicación esté corriendo, abre tu navegador y dirígete a: https://localhost:7117/swagger/index.html (reemplaza 7XXX por el puerto que aparezca en tu terminal).
Desde la interfaz de Swagger puedes:
1.	Seleccionar un método (ej. POST).
2.	Hacer clic en "Try it out".
3.	Modificar el JSON y presionar "Execute".
 
Opción 2: Postman. 
Puedes importar los siguientes detalles para probar las rutas:
•	Listar Usuarios: GET https://localhost:7117/api/usuarios
•	Obtener por ID: GET https://localhost:7117/api/usuarios/{id}
 
 
•	Crear Usuario: POST https://localhost:7117/api/usuarios
o	Body (JSON):
{
  "nombre": "Juan Pérez",
  "correo": "juan.perez@example.com",
  "fechaDeNacimiento": "1995-10-15"
    }

 Probar la validación del correo único: POST

 

