using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_4_Tablas_A_O_M.Models
{
    public class Producto
    {
        public int ProductoId { get; set; } 
        public string Nombre { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public int Stock {  get; set; }

    }
}
