using Application.DTOs.AboutUsSections;
using Application.DTOs.ContactComment;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AboutUsSectionService : IAboutUsSectionService
    {
        private readonly IAboutUsSectionRepository _aboutUsSectionRepository;
        private readonly IMapper _mapper;

        public AboutUsSectionService(IMapper mapper, IAboutUsSectionRepository aboutUsSectionRepository)
        {
            _aboutUsSectionRepository = aboutUsSectionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AboutUsSectionRowDTO>> GetAll()
        {
            var allAboutUs = await _aboutUsSectionRepository.GetAll();
            List<int> list = allAboutUs.Select(p => p.Row).OrderBy(a => a).Distinct().ToList();
            List<AboutUsSectionRowDTO> listSections = new List<AboutUsSectionRowDTO>();
            for (var index = 0; index < list.Count(); index++)
            {
                var itemCurrentRow = allAboutUs.Where(a => a.Row == list[index]).ToList();
                listSections.Add(new AboutUsSectionRowDTO()
                {
                    Row = list[index],
                    AboutUsSectionItemDTOs = itemCurrentRow.OrderBy(i => i.Priority).AsQueryable().ProjectTo<AboutUsSectionItemDTO>(_mapper.ConfigurationProvider).ToList(),
                });
            }
            return listSections;
        }
        public async Task<IEnumerable<AboutUsDetailDTO>> GetAllWithDetail()
        {
            var aboutSections = await _aboutUsSectionRepository.GetAllQueryAble().ProjectTo<AboutUsDetailDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return aboutSections;
        }

        public async Task<int> Create(AboutUsSectionCreateDTO aboutUsSectionCreate)
        {
            return await _aboutUsSectionRepository.Insert(_mapper.Map<AboutUsSection>(aboutUsSectionCreate));
        }
        public async Task<AboutUsSectionUpdateDTO> GetById(int id)
        {
            var aboutUsSection = await _aboutUsSectionRepository.Get(id);
            return _mapper.Map<AboutUsSectionUpdateDTO>(aboutUsSection);

        }
        public async Task Update(AboutUsSectionUpdateDTO aboutUsSectionUpdate)
        {
            var aboutSection = _mapper.Map<AboutUsSection>(aboutUsSectionUpdate);
            await _aboutUsSectionRepository.Update(aboutSection);
        }
        public async Task Delete(AboutUsSectionDeleteDTO aboutUsSectionDelete)
       => await _aboutUsSectionRepository.DeleteById(aboutUsSectionDelete.Id);

    }
}
