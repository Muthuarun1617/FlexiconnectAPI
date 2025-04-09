using Flexiconnect.Application.DTOs;

namespace Flexiconnect.Application.Services.Interfaces
{
    public interface IActionMenuMasterService
    {
        Task<IEnumerable<ActionMenuDto>> GetActionMenuMaster();

        Task AddActionMenuMaster(ActionMenuAddDto actionMenuAddDto);

        Task UpdateActionMenuMaster(ActionMenuDto actionMenuDto);

        Task DeleteActionMenuMaster(ActionMenuDeleteDto actionMenuDeleteDto);
    }
}
