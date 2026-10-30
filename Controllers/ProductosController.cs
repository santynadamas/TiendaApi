using Microsoft.AspNetCore.Mvc;
using TiendaApi.DTOs;
using TiendaApi.Services;

namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        // GET /api/productos
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.ObtenerTodos());
        }

        // GET /api/productos/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var producto = _service.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST /api/productos
        [HttpPost]
        public IActionResult Create([FromBody] CreateProductoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = _service.Crear(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        // PUT /api/productos/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateProductoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _service.Actualizar(id, dto);
            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE /api/productos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _service.Eliminar(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}