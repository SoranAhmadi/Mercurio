using Application.DTOs.ContactComment;
using Application.DTOs.WhyUses;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Domain.Common;

namespace Application.Services
{
    public class WhyUsService : IWhyUsService
    {
        private readonly IWhyUsRepository _whyUsRepsitory;
        private readonly IMapper _mapper;
        private readonly IHistoryRepository _historyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WhyUsService(IWhyUsRepository whyUsRepsitory, IMapper mapper,
            IHistoryRepository historyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _whyUsRepsitory = whyUsRepsitory;
            _mapper = mapper;
            _historyRepository = historyRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<WhyUsDTO>> GetAll()
        => await _whyUsRepsitory.GetAllQueryAble().OrderByDescending(w => w.Priority).ProjectTo<WhyUsDTO>(_mapper.ConfigurationProvider).ToListAsync();
        public async Task<int> Create(WhyUsCreateDTO whyUsCreateDTO)
        {
            var result = await _whyUsRepsitory.Insert(_mapper.Map<WhyUs>(whyUsCreateDTO));
            var newHistory = new History(nameof(Product), ActionType.Update, _httpContextAccessor.GetUserId(), result);
            await _historyRepository.Insert(newHistory);
            return result;
        }
        public async Task Delete(WhyUsDeleteDTO whyUsDeleteDTO)
        {
            await _whyUsRepsitory.DeleteById(whyUsDeleteDTO.Id);
            var newHistory = new History(nameof(WhyUs), ActionType.Delete, _httpContextAccessor.GetUserId(), whyUsDeleteDTO.Id);
            await _historyRepository.Insert(newHistory);
        }


        public async Task<WhyUsUpdateDTO> GetById(WhyUsByIdDTO whyUsByIdDTO)
        {
            var whyUs = await _whyUsRepsitory.Get(whyUsByIdDTO.Id);
            return _mapper.Map<WhyUsUpdateDTO>(whyUs);
        }
        public async Task Update(WhyUsUpdateDTO whyUsUpdateDTO)
        {
            await _whyUsRepsitory.Update(_mapper.Map<WhyUs>(whyUsUpdateDTO));
            var newHistory = new History(nameof(WhyUs), ActionType.Update, _httpContextAccessor.GetUserId(), whyUsUpdateDTO.Id);
            await _historyRepository.Insert(newHistory);

        }


    }
}
