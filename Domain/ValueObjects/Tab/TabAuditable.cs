using Shared.Abstractions.Auditables;

namespace Domain.ValueObjects.Tab
{
    public class TabAuditable : AuditableBase
    {
        public TabAuditable(DateTime created, string createdBy)
        {
            _created = created;
            _createdBy = createdBy;
        }
    }
}
