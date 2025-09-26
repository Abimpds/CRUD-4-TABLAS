namespace Crud_4_Tablas_A_O_M.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public required string Nombre { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono {  get; set; }
    }
}
