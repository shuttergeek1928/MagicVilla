using AutoMapper;
using MagicVilla.Web.Models.Authentications;
using MagicVilla.Web.Models.Registration;
using MagicVilla.Web.Models.Villa;
using MagicVilla.Web.Models.VillaNumber;

namespace MagicVilla.Web
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

            CreateMap<RegistrationRequestModel, Users>();
        }
    }
}
