using Flexiconnect.Domain.Entities;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IActionMenuMasterDomain
    {
        Task<IEnumerable<ActionMenuMaster>> GetActionMenu();
    }
}
