using Shared.Abstractions.Exceptions;

namespace Domain.Exceptions.Tab
{
    public class EmptyTabNameException : TabException
    {
        public EmptyTabNameException() : base("Tab name cannot be empty.")
        {

        }
    }
}
