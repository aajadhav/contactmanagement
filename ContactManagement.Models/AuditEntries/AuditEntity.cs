using System;

namespace ContactManagement.Models.AuditEntries
{
    public abstract class AuditEntity<T> : Entity<T>, IAuditEntity
    {
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
