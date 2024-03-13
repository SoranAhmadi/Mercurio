using Application.DTOs.AboutUsSections;
using Application.DTOs.ContactComment;
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
    public class AboutUsSectionService : IAboutUsSectionService
    {
        private readonly IAboutUsSectionRepository _aboutUsSectionRepository;
        private readonly IMapper _mapper;
        private readonly IHistoryRepository _historyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AboutUsSectionService(IMapper mapper, IAboutUsSectionRepository aboutUsSectionRepository, IHistoryRepository historyRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _aboutUsSectionRepository = aboutUsSectionRepository;
            _mapper = mapper;
            _historyRepository = historyRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<OurCompanyDTO> GetOurCompany()
        {
            var aboutSections = await _aboutUsSectionRepository.GetAllQueryAble().Where(c=>c.Type == AboutUsType.OurCompany).ProjectTo<OurCompanyDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return aboutSections.FirstOrDefault();

        }
        public async Task<AboutUsOnlyDTO> GetAboutUs()
        {
            var aboutSections = await _aboutUsSectionRepository.GetAllQueryAble().Where(c => c.Type == AboutUsType.AboutUs).ProjectTo<AboutUsOnlyDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return aboutSections.FirstOrDefault();
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
        public async Task InsertOrUpdateAboutUs(AboutUsInsertOrUpdateDTO aboutUs)
        {
            var aboutSection = _mapper.Map<AboutUsSection>(aboutUs);
            aboutSection.Type = AboutUsType.AboutUs;
           await _aboutUsSectionRepository.InsertOrUpdateAboutUs(aboutSection);

            var newHistory = new History(nameof(AboutUsSection), ActionType.Update, _httpContextAccessor.GetUserId(), 1);
            await _historyRepository.Insert(newHistory);


        }
        public async Task InsertOrUpdateOurCompany(OurCompanyInsertOrUpdateDTO aboutUs)
        {
            var aboutSection = _mapper.Map<AboutUsSection>(aboutUs);
            aboutSection.Type = AboutUsType.OurCompany;
            await _aboutUsSectionRepository.InsertOrUpdateOurCompany(aboutSection);
            var newHistory = new History(nameof(AboutUsSection), ActionType.Update, _httpContextAccessor.GetUserId(), 1);
            await _historyRepository.Insert(newHistory);

        }
    }
}
