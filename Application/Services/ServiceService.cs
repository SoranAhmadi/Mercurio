using Application.DTOs.Service;
using Application.DTOs.Users;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{

    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepsitory;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHistoryRepository _historyRepository;
        public ServiceService(IServiceRepository serviceRepsitory, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHistoryRepository historyRepository)
        {
            _serviceRepsitory = serviceRepsitory;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _historyRepository = historyRepository;
        }

        public async Task<IEnumerable<ServiceDTO>> GetAll()
        => await _serviceRepsitory.GetAllQueryAble().ProjectTo<ServiceDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<IEnumerable<ServiceSummaryDTO>> GetAllSummary()
        => await _serviceRepsitory.GetAllQueryAble().ProjectTo<ServiceSummaryDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<int> Create(ServiceCreateDTO serviceCreateDTO)
        {
            var newService = new Service()
            {
                Title = serviceCreateDTO.Title,
                Subtitle = serviceCreateDTO.Subtitle,
                Title1 = serviceCreateDTO.Title1,
                Title2 = serviceCreateDTO.Title2,
                ImageBase64 = serviceCreateDTO.ImageBase64,
                Description = serviceCreateDTO.Description,
                ExtraDescription = string.IsNullOrEmpty(serviceCreateDTO.ExtraDescription) ? null : serviceCreateDTO.ExtraDescription,
                ExtraTitle = string.IsNullOrEmpty(serviceCreateDTO.ExtraTitle) ? null : serviceCreateDTO.ExtraTitle,
                ServiceItems = serviceCreateDTO.ServiceItems.Select(s => new ServiceItem() { Title = s }).ToList()
            };
            var resut = await _serviceRepsitory.Insert(newService);

            var newHistory = new History(nameof(Service), ActionType.Create, _httpContextAccessor.GetUserId(), resut);
            await _historyRepository.Insert(newHistory);

            return resut;
        }

        public async Task Delete(ServiceDeleteDTO delete)
        {
            await _serviceRepsitory.Delete(delete.Id);
            var newHistory = new History(nameof(Service), ActionType.Delete, _httpContextAccessor.GetUserId(), delete.Id);
            await _historyRepository.Insert(newHistory);
        }

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
                Title = s
            }).ToList();

            await _serviceRepsitory.AddServiceItems(serviceItems);
            var newHistory = new History(nameof(Service), ActionType.Update, _httpContextAccessor.GetUserId(), serviceUpdateDTO.Id);
            await _historyRepository.Insert(newHistory);
        }

        public async Task UpdateSummary(ServiceUpdateSummaryDTO summary)
        {
            var service = _mapper.Map<ServiceUpdateSummaryDTO, Service>(summary);
            await _serviceRepsitory.UpdateSummary(service);

            var newHistory = new History(nameof(Service), ActionType.Update, _httpContextAccessor.GetUserId(), summary.Id);
            await _historyRepository.Insert(newHistory);
        }

        
    }
}
