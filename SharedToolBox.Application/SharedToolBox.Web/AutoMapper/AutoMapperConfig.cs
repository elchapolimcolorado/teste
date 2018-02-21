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
                x.CreateMap<Categoria, CategoriaViewModel>()
                    .ForMember(d => d.DataCadastro, o => o.Ignore())
                    .ForMember(d => d.Ativo, o => o.Ignore())
                    .ReverseMap();

                //x.AddProfile<DomainToViewModelMappingProfile>();
                //x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}