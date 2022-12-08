using Domain.Exceptions.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.Directory
{
    public record class DirectoryTabId
    {
        public Guid Value { get; }

        public DirectoryTabId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new EmptyDirectoryTabIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(DirectoryTabId directoryTabId)
        {
            return directoryTabId.Value;
        }

        public static implicit operator DirectoryTabId(Guid id)
        {
            return new(id);
        }
    }
}
