using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Models;

namespace SharedToolBox.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
                x.CreateMap<Tipo, TipoViewModel>().ReverseMap();
                x.CreateMap<Subtipo, SubtipoViewModel>().ReverseMap();
                x.CreateMap<Marca, MarcaViewModel>().ReverseMap();
                x.CreateMap<Ferramenta, FerramentaViewModel>().ReverseMap();
                x.CreateMap<Dominio, DominioViewModel>().ReverseMap();
                x.CreateMap<Caracteristica, CaracteristicaViewModel>().ReverseMap();
            });
        }
    }
}