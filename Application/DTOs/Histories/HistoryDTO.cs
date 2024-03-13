using Domain.Common.Enums;

namespace Application.DTOs.Histories
{
    public class HistoryDTO
    {
        public required string Entity { get; set; } 
        public string Action { get; set; } 
        public string CreatedDate { get; set; } 
        public string Hour { get; set; }
        public string FullName { get; set; }
        public int RecordId { get; set; }
    }
}
