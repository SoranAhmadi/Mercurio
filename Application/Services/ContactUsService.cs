using Application.DTOs.ContactUs;
using Application.DTOs.OVerViews;
using Application.IServices;
using AutoMapper;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Domain.Common;

namespace Application.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHistoryRepository _historyRepository;

        public ContactUsService(IContactUsRepository contactUsRepository, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, IHistoryRepository historyRepository)
        {
            _contactUsRepository = contactUsRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _historyRepository = historyRepository;
        }

        public async Task<ContactUsDTO> Get()
        {
            var contacts = await _contactUsRepository.GetAll();
            return contacts.Any() ? _mapper.Map<ContactUsDTO>(contacts.FirstOrDefault()) : null;
        }
        public async Task<int> Create(ContactUsCreateDTO contactUsCreateDTO)
        {
            var all = await _contactUsRepository.GetAll();
            if (all.Any())
                await _contactUsRepository.RemoveRange(all);
            var result = await _contactUsRepository.Insert(_mapper.Map<ContactUs>(contactUsCreateDTO));
            
            var newHistory = new History(nameof(ContactUs), ActionType.Update, _httpContextAccessor.GetUserId(), result);
            await _historyRepository.Insert(newHistory);
            
            return result;
        }
        public async Task Update(ContactUsUpdateDTO contactUsUpdateDTO)
        {
            await _contactUsRepository.Update(_mapper.Map<ContactUs>(contactUsUpdateDTO));
            var newHistory = new History(nameof(ContactUs), ActionType.Update, _httpContextAccessor.GetUserId(), contactUsUpdateDTO.Id);
            await _historyRepository.Insert(newHistory);


        }
    }
}
