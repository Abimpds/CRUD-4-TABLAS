namespace Crud_4_Tablas_A_O_M.DTOs
{
    public class ProductoCreateDto
    {
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
