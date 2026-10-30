using TiendaApi.DTOs;
using TiendaApi.Models;
using TiendaApi.Repositories;

namespace TiendaApi.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public List<ProductoDto> ObtenerTodos()
        {
            return _repository.ObtenerTodos()
                .Select(ToDto)
                .ToList();
        }

        public ProductoDto? ObtenerPorId(int id)
        {
            var producto = _repository.ObtenerPorId(id);
            return producto == null ? null : ToDto(producto);
        }

        public ProductoDto Crear(CreateProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Categoria = dto.Categoria,
                Activo = true
            };

            var creado = _repository.Agregar(producto);
            return ToDto(creado);
        }

        public bool Actualizar(int id, CreateProductoDto dto)
        {
            var existente = _repository.ObtenerPorId(id);
            if (existente == null)
                return false;

            var actualizado = new Producto
            {
                Id = id,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Categoria = dto.Categoria,
                Activo = existente.Activo
            };

            return _repository.Actualizar(actualizado);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        // Entidad -> DTO
        private static ProductoDto ToDto(Producto p)
        {
            return new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Categoria = p.Categoria,
                Activo = p.Activo
            };
        }
    }
}