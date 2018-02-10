
using AutoMapper;
using SharedToolBox.Domain.Entities;
using SharedToolBox.MVC.ViewModels;

namespace SharedToolBox.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}