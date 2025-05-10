using demoFinal.entity;
using System.ComponentModel.DataAnnotations;

namespace demoFinal.Dto.response
{
    public class CategoriaResponse
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
