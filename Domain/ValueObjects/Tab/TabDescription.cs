using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.Tab
{
    public record TabDescription
    {
        public string Value { get; }

        public TabDescription(string value)
        {
            Value = value;
        }

        public static implicit operator string(TabDescription tabDescription)
        {
            return tabDescription.Value;
        }

        public static implicit operator TabDescription(string tabDescription)
        {
            return new(tabDescription);
        }
    }
}
