using Application.DTOs.Histories;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class HistoryService: IHistoryService
    {
        private readonly IHistoryRepository _historyRepsitory;
        private readonly IMapper _mapper;
        public HistoryService(IHistoryRepository historyRepsitory, IMapper mapper)
        {
            _historyRepsitory = historyRepsitory;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HistoryDTO>> GetAll()
        {
           var histories = await _historyRepsitory.GetAllQueryAble().ProjectTo<HistoryDTO>(_mapper.ConfigurationProvider).ToListAsync();
           return histories;
        }
    }
}
