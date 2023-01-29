using Domain.Exceptions.ApplicationUser;

namespace Domain.ValueObjects.ApplicationUser
{
    public record ApplicationUserPasswordHash
    {
        public string Value { get; }
        public ApplicationUserPasswordHash(string value)
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new EmptyApplicationUserPasswordHashException();
            }

            Value = value;
        }

        public static implicit operator string(ApplicationUserPasswordHash applicationUserPasswordHash)
        {
            return applicationUserPasswordHash.Value;
        }

        public static implicit operator ApplicationUserPasswordHash(string value)
        {
            return new(value);
        }
    }
}
