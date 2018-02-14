using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.Models;

namespace SharedToolBox.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            var map = new MapperConfiguration(cfg => { cfg.CreateMap<CategoriaViewModel, Categoria>(); });
        }
    }
}