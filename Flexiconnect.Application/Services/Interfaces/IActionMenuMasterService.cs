using Flexiconnect.Application.DTOs;

namespace Flexiconnect.Application.Services.Interfaces
{
    public interface IActionMenuMasterService
    {
        Task<IEnumerable<ActionMenuDto>> GetActionMenuMaster();

        Task AddActionMenuMaster(IEnumerable<ActionMenuAddDto> actionMenuAddDto);

        Task UpdateActionMenuMaster(IEnumerable<ActionMenuUpdateDto> actionMenuDto);

        Task DeleteActionMenuMaster(ActionMenuDeleteDto actionMenuDeleteDto);
    }
}
