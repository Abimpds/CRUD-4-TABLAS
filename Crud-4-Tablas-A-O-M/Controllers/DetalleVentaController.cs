using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_4_Tablas_A_O_M.Models;
using Crud_4_Tablas_A_O_M.DTOs;
using Crud_4_Tablas_A_O_M.Data;


namespace Crud_4_Tablas_A_O_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetalleVentasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/detalleventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVentaReadDto>>> GetDetalleVentas()
        {
            var detalles = await _context.DetalleVentas
                .AsNoTracking()
                .Select(d => new DetalleVentaReadDto
                {
                    DetalleVentaId = d.DetalleVentaId,
                    VentaId = d.VentaId,
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    Subtotal = d.Subtotal
                })
                .ToListAsync();

            return Ok(detalles);
        }

        // GET: api/detalleventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVentaReadDto>> GetDetalleVenta(int id)
        {
            var detalle = await _context.DetalleVentas
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.DetalleVentaId == id);

            if (detalle == null)
                return NotFound();

            var dto = new DetalleVentaReadDto
            {
                DetalleVentaId = detalle.DetalleVentaId,
                VentaId = detalle.VentaId,
                ProductoId = detalle.ProductoId,
                Cantidad = detalle.Cantidad,
                Subtotal = detalle.Subtotal
            };

            return Ok(dto);
        }

        // POST: api/detalleventas
        [HttpPost]
        public async Task<ActionResult<DetalleVentaReadDto>> CreateDetalleVenta([FromBody] DetalleVentaCreateDto dto)
        {
            // Opcional: validar existencia de Venta y Producto
            var detalle = new DetalleVenta
            {
                VentaId = dto.VentaId,
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                Subtotal = dto.Subtotal,
                Venta = new Venta(), // ⚠️ requerido por el modelo, pero puedes ignorar si haces nullable
                Producto = new Producto()
            };

            _context.DetalleVentas.Add(detalle);
            await _context.SaveChangesAsync();

            var readDto = new DetalleVentaReadDto
            {
                DetalleVentaId = detalle.DetalleVentaId,
                VentaId = detalle.VentaId,
                ProductoId = detalle.ProductoId,
                Cantidad = detalle.Cantidad,
                Subtotal = detalle.Subtotal
            };

            return CreatedAtAction(nameof(GetDetalleVenta), new { id = detalle.DetalleVentaId }, readDto);
        }

        // PUT: api/detalleventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetalleVenta(int id, [FromBody] DetalleVentaUpdateDto dto)
        {
            var detalle = await _context.DetalleVentas.FindAsync(id);

            if (detalle == null)
                return NotFound();

            detalle.VentaId = dto.VentaId;
            detalle.ProductoId = dto.ProductoId;
            detalle.Cantidad = dto.Cantidad;
            detalle.Subtotal = dto.Subtotal;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/detalleventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(int id)
        {
            var detalle = await _context.DetalleVentas.FindAsync(id);

            if (detalle == null)
                return NotFound();

            _context.DetalleVentas.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
