# 💎 Joyería API — Backend

API RESTful desarrollada en **ASP.NET Core** para la gestión de una joyería. El proyecto sigue una arquitectura en capas que separa responsabilidades y facilita el mantenimiento y escalabilidad del sistema.

---

## 🏗️ Estructura del Proyecto

```
├── asp_servicios         # Capa de API: controladores, configuración y punto de entrada
├── lib_aplicaciones      # Capa de aplicación: servicios, validaciones y lógica de negocio
├── lib_entidades         # Capa de dominio: modelos y entidades del sistema
├── lib_repositorios      # Capa de datos: repositorios para la interacción con la base de datos
└── lib_utilidades        # Utilidades y helpers compartidos entre capas
```

---

## ⚙️ Tecnologías

- **C# / ASP.NET Core**
- **Entity Framework Core**
- **SQL Server / MySQL**

---

## 🚀 Instalación y ejecución

1. Clona el repositorio:
   ```bash
   git clone https://github.com/Carolinaubes/joyeria-api.git
   ```

2. Configura la cadena de conexión en `secrets.json`:
   ```json
  
   {
	"ConectionString": "tu-conexion"
    }
   ```

3. Ejecuta el proyecto:
   ```bash
   dotnet run --project asp_servicios
   ```

---

## 📁 Descripción de capas

- **asp_servicios** — Contiene los controladores de la API, la configuración de middlewares y el archivo de inicio (`Program.cs`, `Startup.cs`).
- **lib_aplicaciones** — Gestiona la lógica de negocio, validaciones y servicios que conectan la API con los repositorios.
- **lib_entidades** — Define los modelos y entidades que representan las tablas de la base de datos.
- **lib_repositorios** — Implementa el patrón repositorio para abstraer y centralizar el acceso a los datos.
- **lib_utilidades** — Contiene funciones y clases de apoyo reutilizables en todo el proyecto.
