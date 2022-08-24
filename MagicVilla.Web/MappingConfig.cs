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
            CreateMap<VillaNumberViewModel, VillaNumberUpdateModel>().ForMember(d => d.VillaId, opt => opt.MapFrom(s => s.Villa.Id)).ReverseMap();
            CreateMap<VillaNumberUpdateViewModel, VillaNumberUpdateModel>()
                .ForMember(d => d.VillaNumber, opt => opt.MapFrom(s => s.VillaNumber.VillaNumber))
                .ForMember(d => d.VillaId, opt => opt.MapFrom(s => s.VillaNumber.VillaId))
                .ForMember(d => d.SpecialDetails, opt => opt.MapFrom(s => s.VillaNumber.SpecialDetails));

            CreateMap<RegistrationRequestModel, Users>();
        }
    }
}
