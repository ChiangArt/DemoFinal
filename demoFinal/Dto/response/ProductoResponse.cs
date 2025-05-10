using demoFinal.dto.enums;
using demoFinal.entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demoFinal.Dto.response
{
    public class ProductoResponse
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string RutaImagen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Talla Talla { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
