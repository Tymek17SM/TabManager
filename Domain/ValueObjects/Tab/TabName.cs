using Domain.Exceptions.Tab;

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
            return new(name);
        }
    }
}
