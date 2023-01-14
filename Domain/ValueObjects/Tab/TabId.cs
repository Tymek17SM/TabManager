using Domain.Exceptions.Tab;

namespace Domain.ValueObjects.Tab
{
    public record TabId
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
