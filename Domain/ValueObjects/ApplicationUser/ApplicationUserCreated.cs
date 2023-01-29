using Domain.Exceptions.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.ApplicationUser
{
    public record ApplicationUserCreated
    {
        public DateTime Value { get; }

        public ApplicationUserCreated(DateTime value)
        {
            if (value == DateTime.MinValue || value == DateTime.MaxValue)
            {
                throw new ApplicationUserCreatedException();
            }

            Value = value;
        }

        public static implicit operator DateTime(ApplicationUserCreated applicationUserCreated)
        {
            return applicationUserCreated.Value;
        }

        public static implicit operator ApplicationUserCreated(DateTime dateTime)
        {
            return new(dateTime);
        }
        
    }
}
