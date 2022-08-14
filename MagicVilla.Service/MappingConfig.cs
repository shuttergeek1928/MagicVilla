﻿using AutoMapper;
using MagicVilla.Service.Models.Villa;
using MagicVilla.Service.Models.VillaNumber;

namespace MagicVilla.Service
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaModel, VillaViewModel>();
            CreateMap<VillaViewModel, VillaModel>();

            CreateMap<VillaModel, VillaCreateModel>().ReverseMap();
            CreateMap<VillaModel, VillaUpdateModel>().ReverseMap();

            CreateMap<VillaNumberModel, VillaNumberViewModel>().ReverseMap();
            CreateMap<VillaNumberModel, VillaNumberCreateModel>().ReverseMap();
            CreateMap<VillaNumberModel, VillaNumberUpdateModel>().ReverseMap();
        }
    }
}
