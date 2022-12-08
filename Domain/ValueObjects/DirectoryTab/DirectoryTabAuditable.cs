using Shared.Abstractions.Auditables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
