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

        Task AddActionPermissionMaster(ActionPermissionAddDto actionPermissionAddDto);

        Task UpdateActionPermissionMaster(ActionPermissionDto actionPermissionDto);

        Task DeleteActionPermissionMaster(ActionPermissionDeleteDto actionPermissionDeleteDto);
    }
}
