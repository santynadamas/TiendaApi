# 🛍️ TiendaApi – Gestión de Productos

Web API RESTful desarrollada con **ASP.NET Core y C#**, aplicando una arquitectura de tres capas para la gestión de productos, separación de responsabilidades, validaciones y respuestas HTTP estandarizadas.

## 📋 Descripción

Este proyecto consiste en el desarrollo de una API RESTful para administrar productos mediante operaciones CRUD (Crear, Consultar, Actualizar y Eliminar).

La solución implementa una arquitectura en tres capas (`Controller → Service → Repository`), utilizando DTOs para la transferencia de datos, Data Annotations para validar las entradas y un repositorio en memoria para gestionar la información.

## 🛠️ Tecnologías utilizadas

- **C#**
- **.NET 10**
- **ASP.NET Core Web API**
- **Swagger UI / Swashbuckle**
- **Data Annotations**
- **Inyección de dependencias**
- **Almacenamiento en memoria**

## 🏗️ Arquitectura del proyecto

El proyecto está organizado en tres capas principales:

```text
TiendaApi/
│
├── Controllers/
│   └── ProductosController.cs
│
├── DTOs/
│   ├── CreateProductoDto.cs
│   └── ProductoDto.cs
│
├── Models/
│   └── Producto.cs
│
├── Repositories/
│   ├── IProductoRepository.cs
│   └── ProductoRepositoryInMemory.cs
│
├── Services/
│   ├── IProductoService.cs
│   └── ProductoService.cs
│
├── Program.cs
```

### Responsabilidades de cada capa

| Capa | Responsabilidad |
|---|---|
| Controllers | Recibir solicitudes HTTP y devolver respuestas mediante `IActionResult`. |
| Services | Gestionar la lógica de negocio y transformar entidades en DTOs. |
| Repositories | Administrar los datos de productos almacenados en memoria. |

## 📦 Modelo de datos

### Producto

La entidad `Producto` contiene las siguientes propiedades:

- `Id`: identificador único.
- `Nombre`: nombre del producto.
- `Precio`: precio del producto.
- `Categoria`: categoría a la que pertenece.
- `Activo`: estado del producto.

### DTOs

**CreateProductoDto**

Se utiliza para recibir los datos al crear o editar un producto.

Validaciones implementadas:

- `Nombre`: obligatorio, entre 3 y 100 caracteres.
- `Precio`: obligatorio y mayor que 0.
- `Categoria`: obligatoria.

**ProductoDto**

Se utiliza para devolver la información de los productos sin exponer directamente las entidades del dominio.

## 🔗 Endpoints disponibles

Base URL:

```text
/api/productos
```

| Método | Endpoint | Descripción | Respuesta |
|---|---|---|---|
| GET | `/api/productos` | Obtener todos los productos. | 200 OK |
| GET | `/api/productos/{id}` | Obtener un producto por ID. | 200 / 404 |
| POST | `/api/productos` | Crear un producto. | 201 Created |
| PUT | `/api/productos/{id}` | Actualizar un producto. | 204 / 400 / 404 |
| DELETE | `/api/productos/{id}` | Eliminar un producto. | 204 / 404 |

## 🚀 Instalación y ejecución

### Requisitos previos

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- Visual Studio 2022 o Visual Studio Code.

### 1. Clonar el repositorio

```bash
git clone URL_DEL_REPOSITORIO
```

### 2. Acceder al proyecto

```bash
cd TiendaApi
```

### 3. Restaurar las dependencias

```bash
dotnet restore
```

### 4. Ejecutar la aplicación

```bash
dotnet run
```

### 5. Acceder a Swagger UI

Una vez iniciada la aplicación, abrir en el navegador la dirección:

```text
https://localhost:7272/swagger
```

Desde Swagger UI es posible visualizar, ejecutar y probar directamente todos los endpoints de la API.

> El puerto puede variar según la configuración de ejecución del proyecto.

## 🧪 Pruebas de la API

Todos los endpoints pueden ejecutarse y probarse directamente desde Swagger UI, sin necesidad de herramientas externas como Postman.

Se pueden verificar las operaciones CRUD, las validaciones de entrada y las respuestas HTTP correspondientes.

Autor
Santiago — @santynadamas

**Proyecto desarrollado como parte del Práctico del Bloque 2.**
