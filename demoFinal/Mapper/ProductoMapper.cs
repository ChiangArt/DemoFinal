using AutoMapper;
using demoFinal.Dto.request;
using demoFinal.Dto.response;
using demoFinal.entity;

namespace demoFinal.Mapper
{
    public class ProductoMapper : Profile
    {
        public ProductoMapper()
        {
            CreateMap<Producto, ProductoRequest>().ReverseMap();
            CreateMap<Producto, ProductoResponse>().ReverseMap();

        }
    }
}
