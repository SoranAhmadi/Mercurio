using Application.DTOs.ContactComment;
using Application.DTOs.WhyUses;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class WhyUsService: IWhyUsService
    {
        private readonly IWhyUsRepository _whyUsRepsitory;
        private readonly IMapper _mapper;
        public WhyUsService(IWhyUsRepository whyUsRepsitory, IMapper mapper)
        {
            _whyUsRepsitory = whyUsRepsitory;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WhyUsDTO>> GetAll()
        => await _whyUsRepsitory.GetAllQueryAble().OrderByDescending(w=>w.Priority).ProjectTo<WhyUsDTO>(_mapper.ConfigurationProvider).ToListAsync();
        public async Task<int> Create(WhyUsCreateDTO whyUsCreateDTO)
        {
            return await _whyUsRepsitory.Insert(_mapper.Map<WhyUs>(whyUsCreateDTO));
        }
        public async Task Delete(WhyUsDeleteDTO whyUsDeleteDTO)
                => await _whyUsRepsitory.DeleteById(whyUsDeleteDTO.Id);

        public async Task<WhyUsUpdateDTO> GetById(WhyUsByIdDTO whyUsByIdDTO)
        {
            var whyUs = await _whyUsRepsitory.Get(whyUsByIdDTO.Id);
            return _mapper.Map<WhyUsUpdateDTO>(whyUs);
        }
        public async Task Update(WhyUsUpdateDTO whyUsUpdateDTO)
                => await _whyUsRepsitory.Update(_mapper.Map<WhyUs>(whyUsUpdateDTO));


    }
}
