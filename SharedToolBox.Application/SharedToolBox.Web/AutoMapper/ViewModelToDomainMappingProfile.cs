using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Models;
using System.Collections.Generic;

namespace SharedToolBox.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CategoriaViewModel, Categoria>()
                    .ForMember(d => d.Codigo, o => o.MapFrom(s => s.Codigo))
                    .ForMember(d => d.Nome, o => o.MapFrom(s => s.Nome))
                    .ForMember(d => d.Imagem, o => o.MapFrom(s => s.Imagem));
            });
            //var map = new MapperConfiguration(cfg => { cfg.CreateMap<CategoriaViewModel, Categoria>(); });
        }
    }
}