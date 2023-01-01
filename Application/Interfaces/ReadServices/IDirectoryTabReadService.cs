using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReadServices
{
    public interface IDirectoryTabReadService : IApplicationReadService
    {
        Task<bool> ExistsByIdAsync(Guid Id);
    }
}
