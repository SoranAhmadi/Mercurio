﻿using Application.DTOs.Service;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.Services
{
    public class ServiceProfile:Profile
    {
        public ServiceProfile()
        {
            Read();
            Update();
            ReadSumamry();
            UpdateSumamry();
        }
        private void Read()
        {
            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.ServiceItems, opt => opt.MapFrom(src => src.ServiceItems.Select(s=>s.Title).ToList()));
            
        }
        private void Update()
        {
            CreateMap<Service, ServiceUpdateDTO>()
                .ForMember(dest => dest.ServiceUpdateItems, opt => opt.MapFrom(src => src.ServiceItems.Select(s => new ServiceItemUpdateDTO()
                {
                    Title = s.Title,
                    Id  = s.Id,
                }).ToList())); ;

            CreateMap<ServiceUpdateDTO, Service>();
        }
        private void ReadSumamry()
        {
            CreateMap<Service, ServiceSummaryDTO>();
            
        }

        private void UpdateSumamry()
        {
            CreateMap<Service, ServiceUpdateSummaryDTO>().ReverseMap();

        }

    }
}
