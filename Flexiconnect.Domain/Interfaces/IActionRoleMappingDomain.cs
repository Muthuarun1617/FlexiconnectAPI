using Flexiconnect.Domain.Entities;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IActionRoleMappingDomain
    {
        Task<IEnumerable<ActionRoleMapping>> GetActionRoleMapping(int RoleID);
        Task AddActionRoleMapping(IEnumerable<ActionRoleMapping> actionRoleMapping);
    }
}
