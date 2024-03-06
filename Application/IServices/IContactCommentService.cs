using Application.DTOs.ContactComment;

namespace Application.IServices
{
    public interface IContactCommentService
    {
        Task<IEnumerable<ContactCommentDTO>> GetAll();
        Task<int> Create(ContactCommentCreateDTO productCreateDTO);
        Task Delete(ContactCommentDeleteDTO delete);
        Task<ContactCommentUpdateDTO> GetById(int id);
        Task Update(ContactCommentUpdateDTO serviceUpdateDTO);
    }
}
