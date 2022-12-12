using Domain.Exceptions.Tab;

namespace Domain.ValueObjects.Tab
{
    public record TabLink
    {
        public string Value { get; }

        public TabLink(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyTabLinkException();
            }

            Value = value;
        }

        public static implicit operator string(TabLink tabLink)
        {
            return tabLink.Value;
        }

        public static implicit operator TabLink(string value)
        {
            return new(value);
        }
    }
}
