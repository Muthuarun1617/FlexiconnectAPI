using Flexiconnect.Domain.Entities;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IActionMenuMasterDomain
    {
        Task<IEnumerable<ActionMenuMaster>> GetActionMenu();

        Task AddActionMenu(IEnumerable<ActionMenuMaster> actionMenu);

        Task UpdateActionMenu(IEnumerable<ActionMenuMaster> actionMenu);

        Task DeleteActionMenu(ActionMenuMaster actionMenu);
    }
}
