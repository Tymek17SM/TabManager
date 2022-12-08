using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Abstractions.Auditables
{
    public abstract class AuditableBase
    {
        protected DateTime _created { get; init; }
        protected string _createdBy { get; init; }
    }
}
