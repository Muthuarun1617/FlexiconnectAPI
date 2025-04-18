using Flexiconnect.Domain.Entities;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IActionRoleUserMappingDomain
    {
        Task<IEnumerable<ActionRoleUserMapping>> GetActionRoleUserMapping(int RoleID, int UserID);
        Task AddActionRoleUserMapping(IEnumerable<ActionRoleUserMapping> actionRoleUserMapping);
    }
}
