using System;

namespace ContactManagement.Models.AuditEntries
{
    public interface IAuditEntity
    {
        bool Status { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
