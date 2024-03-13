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
    public class OverViewService: IOverViewService
    {
        private readonly IOverViewRepository _overViewRepository;
        private readonly IMapper _mapper;
        private readonly IHistoryRepository _historyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OverViewService(IOverViewRepository overViewRepository, IMapper mapper, IHistoryRepository historyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _overViewRepository = overViewRepository;
            _mapper = mapper;
            _historyRepository = historyRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<OverViewDTO> Get()
        {
            var overViews = await _overViewRepository.GetAll();
            return overViews.Any() ? _mapper.Map<OverViewDTO>(overViews.FirstOrDefault()) : null;
        }
        public async Task<int> Create(OverViewCreateDTO overViewCreateDTO)
        {
            var all = await _overViewRepository.GetAll();
            if (all.Any())
                await _overViewRepository.RemoveRange(all);
            var result = await _overViewRepository.Insert(_mapper.Map<OverView>(overViewCreateDTO));

            var newHistory = new History(nameof(OverView), ActionType.Update, _httpContextAccessor.GetUserId(), result);
            await _historyRepository.Insert(newHistory);
            return result;
        }
        public async Task Update(OverViewUpdateDTO overViewUpdateDTO)
        {
            await _overViewRepository.Update(_mapper.Map<OverView>(overViewUpdateDTO));
            var newHistory = new History(nameof(OverView), ActionType.Update, _httpContextAccessor.GetUserId(), overViewUpdateDTO.Id);
            await _historyRepository.Insert(newHistory);
        }
    }
}
