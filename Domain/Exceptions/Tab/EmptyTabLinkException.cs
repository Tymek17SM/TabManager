using Shared.Abstractions.Exceptions;

namespace Domain.Exceptions.Tab
{
    public class EmptyTabLinkException : TabException
    {
        public EmptyTabLinkException() : base("Tab link cannot be empty.")
        {

        }
    }
}
