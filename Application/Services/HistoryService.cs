using Application.IServices;
using AutoMapper;
using Domain.Interfaces;

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
    }
}
