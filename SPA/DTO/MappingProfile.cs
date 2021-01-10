using ABC.Core.Models;
using AutoMapper;

namespace SPA.DTO.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BuyerInfo, BuyerInfoDTO>()
                .ForMember(dest => dest.StartOfPayment,
                opt => opt.MapFrom(src => src.StartOfPayment.ToString("yyyy-MM-dd")));

            CreateMap<AmortizationSchedule, AmortizationScheduleDTO>()
                .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Date.ToString("MM/dd/yyyy")));
        }
    }
}
