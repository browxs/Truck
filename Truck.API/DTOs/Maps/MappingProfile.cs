using AutoMapper;
using Truck.Domain.Entities;

namespace Truck.API.DTOs.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaRespostaDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaVeiculosDTO>().ReverseMap();

            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoRespostaDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoCategoriaDTO>().ReverseMap();
        }
    }
}
