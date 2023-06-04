using System.ComponentModel.DataAnnotations;
namespace PROYECTOFINAL.Models
{
    public class ProductoModel
    {

        [Key]
        public int id_Producto { get; set; }
      
        public string? Nombre { get; set; }
        

        public int CantidadExistente { get; set; }
     

        public int CantidadEntrante { get; set; }
        

        public double Precio { get; set; }
        

        public string? Detalle { get; set; }
       

        public string? Codigo  { get; set; }
        
        public int Total { get; set; }
        
    }
}