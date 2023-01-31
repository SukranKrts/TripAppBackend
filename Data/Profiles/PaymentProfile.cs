using AutoMapper;
using TripApplication.Data.DTO.PaymentDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class PaymentProfile: Profile
    {
        public PaymentProfile() {
            CreateMap<PaymentInformation, PaymentInfoDTO>()
                .ReverseMap();
            CreateMap<PaymentInfoDTO,PaymentInformation>()
                .ReverseMap();
            CreateMap<PaymentInformation, PaymentInformationDTO>()
                .ReverseMap();
            CreateMap<PaymentInformationDTO, PaymentInformation>()
                .ReverseMap();
        }
    }
}
