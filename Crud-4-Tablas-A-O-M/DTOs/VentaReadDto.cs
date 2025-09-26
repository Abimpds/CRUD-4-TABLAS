namespace Crud_4_Tablas_A_O_M.DTOs
{
    public class VentaReadDto
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
    }
}
