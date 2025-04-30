# 📚 Backend - API Proxy en .NET 8 (Oneom Architecture)

Este proyecto es una API REST desarrollada en **C# .NET 6** que actúa como un **proxy** entre el frontend y la API externa [FakeRestAPI](https://fakerestapi.azurewebsites.net/index.html). Está estructurada utilizando **Clean Architecture**, promoviendo una separación clara de responsabilidades y un código mantenible y escalable.

## 🚀 Características

- API REST construida con ASP.NET Core (.NET 6)
- Estructura basada en Clean Architecture
- Conexión a la API externa [FakeRestAPI](https://fakerestapi.azurewebsites.net/)
- Endpoints CRUD para **Books** y **Authors**
- Sin uso de base de datos local

---

## 📁 Estructura del Proyecto

📦 Backend.API ├── 📂 Application # Casos de uso y lógica de negocio ├── 📂 Domain # Entidades y contratos ├── 📂 Infrastructure # Comunicación con la API externa ├── 📂 WebAPI # Controladores y configuración de la API ├── 📄 Program.cs └── 📄 README.md

yaml
Copiar
Editar

---

## 🧰 Tecnologías Utilizadas

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [HttpClientFactory](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests)
- Clean Architecture

---

## ⚙️ Requisitos Previos

- [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/) o [Visual Studio Code](https://code.visualstudio.com/)
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

---

## 🛠️ Instalación y Ejecución

1. **Clonar el repositorio**

```bash
git clone https://github.com/tuusuario/backend-fakerestapi.git
cd backend-fakerestapi
Restaurar paquetes

bash
Copiar
Editar
dotnet restore
Construir la solución

bash
Copiar
Editar
dotnet build
Ejecutar el proyecto

bash
Copiar
Editar
dotnet run --project WebAPI
Por defecto, la API estará disponible en:

arduino
Copiar
Editar
https://localhost:5001
http://localhost:5000
📌 Endpoints Disponibles
📚 Books

Método	Endpoint	Descripción
GET	/api/books	Obtener todos los libros
GET	/api/books/{id}	Obtener un libro por ID
POST	/api/books	Crear un nuevo libro
PUT	/api/books/{id}	Actualizar un libro existente
DELETE	/api/books/{id}	Eliminar un libro
✍️ Authors

Método	Endpoint	Descripción
GET	/api/authors	Obtener todos los autores
GET	/api/authors/{id}	Obtener un autor por ID
POST	/api/authors	Crear un nuevo autor
PUT	/api/authors/{id}	Actualizar un autor existente
DELETE	/api/authors/{id}	Eliminar un autor
🧪 Pruebas
Puedes probar los endpoints utilizando:

Postman

Swagger (automáticamente habilitado en desarrollo)

cURL

🔧 Configuración Adicional
Puedes modificar los BaseUrl de la API externa en el archivo appsettings.json o usar IConfiguration para inyectarlos dinámicamente.

Se recomienda registrar servicios externos utilizando HttpClientFactory.

🧹 Pendientes/Futuro
Validación de modelos más robusta

Manejo de errores centralizado

Logger y pruebas unitarias

👨‍💻 Autor
Desarrollado por [Daniel Alexander de la Rosa]
