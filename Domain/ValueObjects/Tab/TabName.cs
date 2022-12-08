using Domain.Exceptions;
using Domain.Exceptions.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.Tab
{
    public record TabName
    {
        public string Value { get; }

        public TabName(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyTabNameException();
            }

            Value = value;
        }

        public static implicit operator string(TabName tabName)
        {
            return tabName.Value;
        }

        public static implicit operator TabName(string name)
        {
            //return new TabName(name);
            return new(name);
        }
    }
}
