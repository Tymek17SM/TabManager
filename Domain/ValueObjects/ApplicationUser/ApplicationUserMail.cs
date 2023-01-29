using Domain.Exceptions.ApplicationUser;

namespace Domain.ValueObjects.ApplicationUser
{
    public record ApplicationUserMail
    {
        public string Value { get; }

        public ApplicationUserMail(string value)
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new EmptyApplicationUserMailException();
            }

            Value = value;
        }

        public static implicit operator string (ApplicationUserMail applicationUserMail)
        {
            return applicationUserMail.Value;
        }

        public static implicit operator ApplicationUserMail(string mail)
        {
            return new(mail);
        }
    }
}
