using System.ComponentModel.DataAnnotations;

namespace demoFinal.Dto.request
{
    public class UsuarioRequest
    {
       
   
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La contrasena es obligatoria")]
        public string Contrasena { get; set; }
     
    }
}
