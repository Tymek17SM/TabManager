using Domain.Exceptions.Directory;

namespace Domain.ValueObjects.Directory
{
    public record DirectoryTabId
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
