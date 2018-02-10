
using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Web.ViewModels;

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
            Mapper.Initialize(cfg => {

                cfg.CreateMap<Categoria, CategoriaViewModel>();
            });
        }
    }
}