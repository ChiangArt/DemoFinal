using System.ComponentModel.DataAnnotations;

namespace demoFinal.Dto.request
{
    public class UsuarioRegisterRequest
    {

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La contrasena es obligatoria")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "El Rol es obligatorio")]
        public string Rol { get; set; }
    }
}
