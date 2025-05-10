using demoFinal.entity;
using System.ComponentModel.DataAnnotations;

namespace demoFinal.Dto.response
{
    public class UsuarioResponse
    {
   
        public Usuario usuario {  get; set; }
    
        public string Rol { get; set; }
    }
}
