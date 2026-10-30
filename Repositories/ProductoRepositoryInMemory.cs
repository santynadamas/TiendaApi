using TiendaApi.Models;

namespace TiendaApi.Repositories
{
    public class ProductoRepositoryInMemory : IProductoRepository
    {
        // static: como el repository se registra como Scoped (una instancia por request),
        // sin static la lista se reiniciaría en cada llamada y los datos no persistirían.
        private static readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Laptop Lenovo", Precio = 3500.00m, Categoria = "Tecnologia", Activo = true },
            new Producto { Id = 2, Nombre = "Mouse Logitech", Precio = 85.50m, Categoria = "Tecnologia", Activo = true },
            new Producto { Id = 3, Nombre = "Silla Gamer", Precio = 750.00m, Categoria = "Muebles", Activo = true },
            new Producto { Id = 4, Nombre = "Escritorio", Precio = 1200.00m, Categoria = "Muebles", Activo = false }
        };

        private static int _siguienteId = 5;

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public Producto Agregar(Producto producto)
        {
            producto.Id = _siguienteId++;
            _productos.Add(producto);
            return producto;
        }

        public bool Actualizar(Producto producto)
        {
            var existente = _productos.FirstOrDefault(p => p.Id == producto.Id);
            if (existente == null)
                return false;

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Categoria = producto.Categoria;
            existente.Activo = producto.Activo;
            return true;
        }

        public bool Eliminar(int id)
        {
            var existente = _productos.FirstOrDefault(p => p.Id == id);
            if (existente == null)
                return false;

            _productos.Remove(existente);
            return true;
        }
    }
}