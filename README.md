# TecnicosApi_CleanArchitecture

Este proyecto implementa una API para la gestión de técnicos utilizando el patrón Clean Architecture. La solución está organizada en varias capas, cada una con responsabilidades bien definidas para mantener la separación de preocupaciones y facilitar la escalabilidad y el mantenimiento.

## Estructura del Proyecto

- **RegistroTecnicos.Api/**: Proyecto principal de la API. Expone los endpoints HTTP y configura la aplicación.
- **Tecnicos.Abstractions/**: Contiene las interfaces y contratos que definen los servicios y dependencias del dominio.
- **Tecnicos.Domain/**: Incluye las entidades de dominio y los DTOs (Data Transfer Objects) que representan los datos centrales del negocio.
- **Tecnicos.Data/**: Implementa la capa de acceso a datos, modelos de base de datos y el contexto de Entity Framework Core.
- **Tecnicos.Services/**: Contiene la lógica de negocio y las implementaciones de los servicios definidos en la capa de abstracciones.

## Descripción de las Capas

### 1. API (`RegistroTecnicos.Api`)
- Expone los controladores (`Controllers/`) para interactuar con la aplicación mediante HTTP.
- Configura la inyección de dependencias y los servicios necesarios.
- Gestiona la configuración de la aplicación (archivos `appsettings.json`).

### 2. Abstracciones (`Tecnicos.Abstractions`)
- Define las interfaces de los servicios (por ejemplo, `IPrioridadesService`).
- Permite desacoplar la lógica de negocio de las implementaciones concretas.

### 3. Dominio (`Tecnicos.Domain`)
- Contiene las entidades principales del negocio y los DTOs.
- No tiene dependencias de otras capas.

### 4. Datos (`Tecnicos.Data`)
- Implementa el acceso a la base de datos usando Entity Framework Core.
- Define el contexto (`TecnicosContext`) y los modelos de datos.
- Incluye la configuración de la inyección de dependencias para el contexto de datos.

### 5. Servicios (`Tecnicos.Services`)
- Implementa la lógica de negocio y los servicios definidos en la capa de abstracciones.
- Se comunica con la capa de datos a través de las interfaces.

## Principios de Clean Architecture
- **Independencia de frameworks**: El núcleo del negocio no depende de frameworks externos.
- **Testabilidad**: Las dependencias se inyectan mediante interfaces, facilitando las pruebas unitarias.
- **Separación de responsabilidades**: Cada capa tiene una responsabilidad clara y definida.
- **Inversión de dependencias**: Las dependencias apuntan hacia el dominio, nunca al revés.

## Cómo ejecutar el proyecto
1. Restaura los paquetes NuGet: `dotnet restore`
2. Compila la solución: `dotnet build`
3. Ejecuta la API: `dotnet run --project RegistroTecnicos.Api`

## Contribuciones
Las contribuciones son bienvenidas. Por favor, sigue las buenas prácticas de Clean Architecture y asegúrate de mantener la separación de responsabilidades al agregar nuevas funcionalidades.

---

**Autor:** Enel Almonte
