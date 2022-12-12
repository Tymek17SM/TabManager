using Domain.Exceptions.Directory;

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
