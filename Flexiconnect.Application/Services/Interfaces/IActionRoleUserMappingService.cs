using Flexiconnect.Application.DTOs;

namespace Flexiconnect.Application.Services.Interfaces
{
    public interface IActionRoleUserMappingService
    {
        Task<IEnumerable<ActionRoleUserMappingFetchDto>> GetActionRoleUserMapping(int RoleID, int UserID);

        Task AddActionRoleUserMapping(IEnumerable<ActionRoleUserMappingDto> actionRoleUserMappingDto);
    }
}
