using demoFinal.dto.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoFinal.entity
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

       
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        
        public Talla Talla { get; set; }
        public Sexo Sexo { get; set; }

        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
