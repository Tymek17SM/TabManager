using Shared.Abstractions.Exceptions;

namespace Domain.Exceptions.Directory
{
    public class EmptyDirectoryTabIdException : DirectoryTabException
    {
        public EmptyDirectoryTabIdException() : base("Directory Id cannot be empty.")
        {

        }
    }
}
