using demoFinal.entity;
using System.ComponentModel.DataAnnotations;

namespace demoFinal.Dto.request
{
    public class CategoriaRequest
    {
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100")]
        public string Nombre { get; set; } 
        
    }
}
