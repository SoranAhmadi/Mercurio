using Application.DTOs.Histories;
using AutoMapper;
using Domain.Common.Enums;
using Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Application.AutoMappers.Histories
{
    public class HistoryProfile : Profile
    {
        public HistoryProfile()
        {
            Read();
            Create();
        }
        private void Read()
        {
            CreateMap<History, HistoryDTO>()
                              .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => string.Format("{0} {1}", src.User.FirstName, src.User.LastName)))
                               .ForMember(dest => dest.Action, opt => opt.MapFrom(src => Enum.GetName(src.Action)))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src=>src.CreatedDate.ToString("yyyy-MM-dd")))
            .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.CreatedDate.ToString("hh-ss")))
            ;

            ;
        }
        private void Create()
        {
            CreateMap<HistoryCreateDTO, History>();
        }
    }
}
