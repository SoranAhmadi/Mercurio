using Application.DTOs.Category;
using Application.DTOs.ContactComment;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    

    public class ContactCommentService : IContactCommentService
    {
        private readonly IContactCommentRepository _contactCommentRepsitory;
        private readonly IMapper _mapper;
        public ContactCommentService(IContactCommentRepository contactCommentRepsitory, IMapper mapper)
        {
            _contactCommentRepsitory = contactCommentRepsitory;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ContactCommentDTO>> GetAll()
            => await _contactCommentRepsitory.GetAllQueryAble().ProjectTo<ContactCommentDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<int> Create(ContactCommentCreateDTO contactCommentCreateDTO)
        {
            return await _contactCommentRepsitory.Insert(_mapper.Map<ContactComment>(contactCommentCreateDTO));
        }
        public async Task<ContactCommentUpdateDTO> GetById(int id)
        {
            var contactComment = await _contactCommentRepsitory.Get(id);
            return _mapper.Map<ContactCommentUpdateDTO>(contactComment);
        }
        public async Task Update(ContactCommentUpdateDTO contactComment)
        => await _contactCommentRepsitory.Update(_mapper.Map<ContactComment>(contactComment));

        public async Task Delete(ContactCommentDeleteDTO category)
        => await _contactCommentRepsitory.DeleteById(category.Id);
    }
}
