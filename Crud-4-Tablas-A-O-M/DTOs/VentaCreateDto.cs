namespace Crud_4_Tablas_A_O_M.DTOs
{
    public class VentaCreateDto
    {
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
    }
}
