using Flexiconnect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IActionRoleMappingDomain
    {
        Task<IEnumerable<ActionRoleMapping>> GetActionRoleMapping(int RoleID);
        Task AddActionRoleMapping(ActionRoleMapping actionRoleMapping);
    }
}
