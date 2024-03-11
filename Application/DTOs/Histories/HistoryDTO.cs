using Domain.Common.Enums;

namespace Application.DTOs.Histories
{
    public class HistoryDTO
    {
        public required string Entity { get; set; } 
        public ActionType Action { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public int UserId { get; set; }
    }
}
