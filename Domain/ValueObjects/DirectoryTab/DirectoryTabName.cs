using Domain.Exceptions.Directory;
using Domain.Exceptions.Tab;
using Domain.ValueObjects.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.Directory
{
    public record class DirectoryTabName
    {
        public string Value { get; }

        public DirectoryTabName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyDirectoryTabNameException();
            }

            Value = value;
        }

        public static implicit operator string(DirectoryTabName directoryTabName)
        {
            return directoryTabName.Value;
        }

        public static implicit operator DirectoryTabName(string name)
        {
            return new(name);
        }
    }
}
