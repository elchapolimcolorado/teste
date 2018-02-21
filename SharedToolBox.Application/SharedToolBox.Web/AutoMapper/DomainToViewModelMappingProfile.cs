using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Models;
using System.Collections.Generic;

namespace SharedToolBox.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Categoria, CategoriaViewModel>()
                    .ForMember(d => d.Codigo, o => o.MapFrom(s => s.Codigo))
                    .ForMember(d => d.Nome, o => o.MapFrom(s => s.Nome))
                    .ForMember(d => d.Imagem, o => o.MapFrom(s => s.Imagem))
                    .ForMember(d => d.DataCadastro, o => o.Ignore())
                    .ForMember(d => d.Ativo, o => o.Ignore());
            });


                

            //var map = new MapperConfiguration(cfg => { cfg.CreateMap<Categoria, CategoriaViewModel>(); });
        }
    }
}