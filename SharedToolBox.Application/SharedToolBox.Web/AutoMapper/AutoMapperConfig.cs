﻿using AutoMapper;
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
                x.CreateMap<Tipo, TipoViewModel>().ReverseMap();//.ForMember(y => y.Categorias, opt => opt.Ignore()).ReverseMap();
            });
        }
    }
}