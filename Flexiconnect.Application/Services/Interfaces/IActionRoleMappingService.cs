using Flexiconnect.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.Services.Interfaces
{
    public interface IActionRoleMappingService
    {
        Task<IEnumerable<ActionRoleMappingFetchDto>> GetActionRoleMapping(int RoleID);

        Task AddActionRoleMapping(ActionRoleMappingDto actionRoleMappingDto);
    }
}
