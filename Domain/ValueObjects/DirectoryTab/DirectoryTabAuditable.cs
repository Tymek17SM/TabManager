using Shared.Abstractions.Auditables;

namespace Domain.ValueObjects.Directory
{
    public class DirectoryTabAuditable : AuditableBase
    {
        public DirectoryTabAuditable(DateTime created, string  createdBy)
        {
            _created = created;
            _createdBy = createdBy;
        }
    }
}
