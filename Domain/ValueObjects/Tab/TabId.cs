using Domain.Exceptions.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.Tab
{
    public record class TabId
    {
        public Guid Value { get; }

        public TabId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new EmptyTabIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(TabId tabId)
        {
            return tabId.Value;
        }

        public static implicit operator TabId(Guid id)
        {
            return new(id);
        }
    }
}
