using AutoMapper;
using MagicVilla.Service.Models.Villa;

namespace MagicVilla.Service
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaModel, VillaViewModel>();
            CreateMap<VillaViewModel, VillaModel>();

            CreateMap<VillaModel, VillaCreateModel>().ReverseMap();
        }
    }
}
