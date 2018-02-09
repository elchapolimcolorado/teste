
using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.MVC.ViewModels;

namespace SharedToolBox.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}