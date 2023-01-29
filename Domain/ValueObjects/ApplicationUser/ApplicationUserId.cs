using Domain.Exceptions.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.ApplicationUser
{
    public record ApplicationUserId
    {
        public Guid Value { get; }

        public ApplicationUserId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new EmptyApplicationUserIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(ApplicationUserId applicationUserId)
        {
            return applicationUserId.Value;
        }

        public static implicit operator ApplicationUserId(Guid guid)
        {
            return new(guid);
        }
    }
}
