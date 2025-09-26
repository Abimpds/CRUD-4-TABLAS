namespace Crud_4_Tablas_A_O_M.DTOs
{
    public class DetalleVentaReadDto
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
