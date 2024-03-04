using Application.DTOs.ContactUs;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ContactUsService: IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;
        public ContactUsService(IContactUsRepository contactUsRepository, IMapper mapper)
        {
            _contactUsRepository = contactUsRepository;
            _mapper = mapper;
        }

        public async Task<ContactUsDTO> Get()
        {
           var contacts = await _contactUsRepository.GetAll();
           return contacts.Any()? _mapper.Map<ContactUsDTO>(contacts.FirstOrDefault()) : null; 
        }
        public async Task<int> Create(ContactUsCreateDTO contactUsCreateDTO)
        {
            var all =await _contactUsRepository.GetAll();
            if (all.Any())
               await _contactUsRepository.RemoveRange(all);
           var result =  await _contactUsRepository.Insert(_mapper.Map<ContactUs>(contactUsCreateDTO));
            return result;
        }
        public async Task Update(ContactUsUpdateDTO contactUsUpdateDTO)
        {
            await _contactUsRepository.Update(_mapper.Map<ContactUs>(contactUsUpdateDTO));
        }
    }
}
