using Shared.Abstractions.Exceptions;

namespace Domain.Exceptions.Directory
{
    public class EmptyDirectoryTabNameException : DirectoryTabException
    {
        public EmptyDirectoryTabNameException() : base("Directory name cannot be empty.")
        {
                
        }
    }
}
