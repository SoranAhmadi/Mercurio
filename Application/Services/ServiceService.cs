using Application.DTOs.Service;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
namespace Application.Services
{

    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepsitory;
        private readonly IMapper _mapper;
        public ServiceService(IServiceRepository serviceRepsitory, IMapper mapper)
        {
            _serviceRepsitory = serviceRepsitory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceDTO>> GetAll()
        => await _serviceRepsitory.GetAllQueryAble().ProjectTo<ServiceDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<int> Create(ServiceCreateDTO serviceCreateDTO)
        {
            var newService = new Service()
            {
                Title = serviceCreateDTO.Title,
                Subtitle = serviceCreateDTO.Subtitle,
                Title1 = serviceCreateDTO.Title1,
                Title2 = serviceCreateDTO.Title2,
                ImageBase64 = serviceCreateDTO.ImageBase64,
                ExtraDescription = string.IsNullOrEmpty(serviceCreateDTO.ExtraDescription) ? null : serviceCreateDTO.ExtraDescription,
                ExtraTitle = string.IsNullOrEmpty(serviceCreateDTO.ExtraTitle) ? null : serviceCreateDTO.ExtraTitle,
                ServiceItems = serviceCreateDTO.ServiceItems.Select(s => new ServiceItem() { Title = s }).ToList()
            };
            var resut = await _serviceRepsitory.Insert(newService);
            return resut;
        }

        public async Task Delete(ServiceDeleteDTO delete)
            => await _serviceRepsitory.Delete(delete.Id);

        public async Task<ServiceUpdateDTO> GetById(int id)
        {
            var service = await _serviceRepsitory.GetById(id);
            var serviceUpdate = _mapper.Map<Service, ServiceUpdateDTO>(service);
            return serviceUpdate;
        }

        public async Task Update(ServiceUpdateDTO serviceUpdateDTO)
        {
            var service = _mapper.Map<Service>(serviceUpdateDTO);
            await _serviceRepsitory.Update(service);
            await _serviceRepsitory.DeleteServiceItems(serviceUpdateDTO.Id);

            var serviceItems = serviceUpdateDTO.ServiceUpdateItems.Select(s => new ServiceItem()
            {
                ServiceId = serviceUpdateDTO.Id,
                Title = s.Title
            }).ToList();

            await _serviceRepsitory.AddServiceItems(serviceItems);
        }
    }
}
