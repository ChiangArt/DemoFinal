using AutoMapper;
using demoFinal.Dto.request;
using demoFinal.Dto.response;
using demoFinal.entity;

namespace demoFinal.Mapper
{
    public class CategoriaMapper : Profile
    {
       public CategoriaMapper() 
        { 
            CreateMap<Categoria, CategoriaRequest>().ReverseMap();
            CreateMap<Categoria, CategoriaResponse>().ReverseMap();

        }
    }
}
