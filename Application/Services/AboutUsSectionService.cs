using Application.DTOs.AboutUsSections;
using Application.IServices;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class AboutUsSectionService: IAboutUsSectionService
    {
        private readonly IAboutUsSectionRepository _aboutUsSectionRepository;
        private readonly IMapper _mapper;

        public AboutUsSectionService(IMapper mapper , IAboutUsSectionRepository aboutUsSectionRepository)
        {
            _aboutUsSectionRepository = aboutUsSectionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AboutUsSectionRowDTO>> GetAll()
        {
            var allAboutUs = await _aboutUsSectionRepository.GetAll();
            List<int> list = allAboutUs.Select(p=>p.Row).OrderByDescending(a=>a).ToList();
            List<AboutUsSectionRowDTO> listSections = new List<AboutUsSectionRowDTO>();
            for(var index = 0; index <list.Count(); index ++)
            {
                var itemCurrentRow = allAboutUs.Where(a=>a.Row == list[index]).ToList();
                listSections.Add(new AboutUsSectionRowDTO()
                {
                    Row = list[index],
                    AboutUsSectionItemDTOs = _mapper.Map<List<AboutUsSectionItemDTO>>(itemCurrentRow)
                });
            }
            return listSections;
        }

    }
}
