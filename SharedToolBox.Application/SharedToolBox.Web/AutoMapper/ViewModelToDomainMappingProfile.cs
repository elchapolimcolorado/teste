using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Models;

namespace SharedToolBox.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            var map = new MapperConfiguration(cfg => { cfg.CreateMap<Categoria, CategoriaViewModel>(); });
        }
    }
}