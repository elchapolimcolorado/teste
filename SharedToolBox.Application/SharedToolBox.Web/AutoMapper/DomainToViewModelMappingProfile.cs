
using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.ViewModels;

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
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<CategoriaViewModel, Categoria>();
            });

        }
    }
}