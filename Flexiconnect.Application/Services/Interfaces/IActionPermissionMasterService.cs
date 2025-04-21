using Flexiconnect.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.Services.Interfaces
{
    public interface IActionPermissionMasterService
    {
        Task<IEnumerable<ActionPermissionDto>> GetActionPermissionMaster();
        Task<IEnumerable<ActionPermissionDto>> GetActionPermissionMasterByName(string permissionName);

        Task AddActionPermissionMaster(IEnumerable<ActionPermissionAddDto> actionPermissionAddDto);

        Task UpdateActionPermissionMaster(IEnumerable<ActionPermissionUpdateDto> actionPermissionUpdateDto);

        Task DeleteActionPermissionMaster(ActionPermissionDeleteDto actionPermissionDeleteDto);
    }
}
