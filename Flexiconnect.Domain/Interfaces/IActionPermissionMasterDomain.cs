using Flexiconnect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IActionPermissionMasterDomain
    {
        Task<IEnumerable<ActionPermissionMaster>> GetActionPermission();

        Task AddActionPermission(ActionPermissionMaster actionMenu);

        Task UpdateActionPermission(ActionPermissionMaster actionMenu);

        Task DeleteActionPermission(ActionPermissionMaster actionMenu);
    }
}
