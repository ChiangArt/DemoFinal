using System.ComponentModel.DataAnnotations;

namespace demoFinal.entity
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
