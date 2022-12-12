using Shared.Abstractions.Exceptions;

namespace Domain.Exceptions.Tab
{
    public class EmptyTabIdException : TabException
    {
        public EmptyTabIdException() : base("Tab id cannot be empty.")
        {

        }
    }
}
