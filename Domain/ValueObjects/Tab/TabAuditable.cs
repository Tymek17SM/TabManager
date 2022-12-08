using Shared.Abstractions.Auditables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
