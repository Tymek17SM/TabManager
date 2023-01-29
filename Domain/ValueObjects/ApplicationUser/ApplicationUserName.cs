using Domain.Exceptions.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.ApplicationUser
{
    public record ApplicationUserName
    {
        public string Value { get; }

        public ApplicationUserName(string value)
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new EmptyApplicationUserNameException();
            }

            Value = value;
        }

        public static implicit operator string(ApplicationUserName applicationUserName)
        {
            return applicationUserName.Value;
        }

        public static implicit operator ApplicationUserName(string name)
        {
            return new(name);
        }
    }
}
