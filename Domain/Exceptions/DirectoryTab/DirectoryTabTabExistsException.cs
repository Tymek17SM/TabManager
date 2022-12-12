using Shared.Abstractions.Exceptions;

namespace Domain.Exceptions.DirectoryTab
{
    public class DirectoryTabTabExistsException : DirectoryTabException
    {
        public DirectoryTabTabExistsException(string directoryName) 
            : base($"Tab does not exists in directory {directoryName}.")
        {

        }
    }
}
