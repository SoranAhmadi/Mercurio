using Application.DTOs.Histories;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.Histories
{
    public class HistoryProfile:Profile
    {
        public HistoryProfile() 
        {
            Read();
        }
        private void Read()
        {
            CreateMap<HistoryDTO, History>();
        }
    }
}
