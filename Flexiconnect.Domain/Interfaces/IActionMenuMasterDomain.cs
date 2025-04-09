using Flexiconnect.Domain.Entities;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IActionMenuMasterDomain
    {
        Task<IEnumerable<ActionMenuMaster>> GetActionMenu();

        Task AddActionMenu(ActionMenuMaster actionMenu);

        Task UpdateActionMenu(ActionMenuMaster actionMenu);

        Task DeleteActionMenu(ActionMenuMaster actionMenu);
    }
}
