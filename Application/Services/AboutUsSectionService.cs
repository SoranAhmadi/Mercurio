using Application.DTOs.AboutUsSections;
using Application.IServices;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class AboutUsSectionService: IAboutUsSectionService
    {
        private readonly IAboutUsSectionRepository _aboutUsSectionRepository;
        public AboutUsSectionService(IAboutUsSectionRepository aboutUsSectionRepository)
        {
            _aboutUsSectionRepository = aboutUsSectionRepository;
            
        }
        public async Task<IEnumerable<AboutUsSectionRowDTO>> GetAll()
        {
            var allAboutUs = await _aboutUsSectionRepository.GetAll();

            return null;
        }

    }
}
