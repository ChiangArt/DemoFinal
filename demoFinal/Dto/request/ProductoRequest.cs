using demoFinal.dto.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoFinal.Dto.request
{
    public class ProductoRequest
    {
        [Required]
        public int CategoriaId { get; set; }

        public string RutaImagen { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(300)]
        public string Descripcion { get; set; }

        [Required]
        public string Marca { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        [Required]
        public Talla Talla { get; set; }

        [Required]
        public Sexo Sexo { get; set; }
    }
}
