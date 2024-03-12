using Domain.Common.Enums;
using System.Security.AccessControl;

namespace Domain.Entities
{
    public class History(string entity, ActionType action,int UserId,int recordId) : Entity
    {
        public int RecordId { get; set; } = recordId;
        public  string Entity { get; set; } = entity;
        public ActionType Action { get; set; } = action;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int UserId { get; set; } = UserId;
        public virtual User User { get; set; }
    }
}
