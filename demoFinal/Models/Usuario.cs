using System.ComponentModel.DataAnnotations;

namespace demoFinal.entity
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}
