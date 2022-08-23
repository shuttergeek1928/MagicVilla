using AutoMapper;
using MagicVilla.Service.Models.Authentications;
using MagicVilla.Service.Models.Registration;
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
            CreateMap<VillaModel, VillaUpdateModel>();
            CreateMap<VillaUpdateModel, VillaModel>().ForMember(destinationModel => destinationModel.Id, options => options.Ignore());

            CreateMap<VillaNumberModel, VillaNumberViewModel>().ReverseMap();
            CreateMap<VillaNumberModel, VillaNumberCreateModel>().ReverseMap();
            CreateMap<VillaNumberModel, VillaNumberUpdateModel>().ReverseMap();

            CreateMap<RegistrationRequestModel, Users>();
        }
    }
}
