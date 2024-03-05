using Application.DTOs.ContactUs;
using Application.DTOs.OVerViews;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class OverViewService: IOverViewService
    {
        private readonly IOverViewRepository _overViewRepository;
        private readonly IMapper _mapper;
        public OverViewService(IOverViewRepository overViewRepository, IMapper mapper)
        {
            _overViewRepository = overViewRepository;
            _mapper = mapper;
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
            return result;
        }
        public async Task Update(OverViewUpdateDTO overViewUpdateDTO)
        {
            await _overViewRepository.Update(_mapper.Map<OverView>(overViewUpdateDTO));
        }
    }
}
