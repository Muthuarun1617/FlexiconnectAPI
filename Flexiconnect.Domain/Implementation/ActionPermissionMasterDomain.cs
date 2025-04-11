using Dapper;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces;
using Flexiconnect.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Implementation
{
    public class ActionPermissionMasterDomain : IActionPermissionMasterDomain
    {
        private readonly IGenericRepository<ActionPermissionMaster> _genericRepository;

        public ActionPermissionMasterDomain(IGenericRepository<ActionPermissionMaster> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<ActionPermissionMaster>> GetActionPermission()
        {
            IEnumerable<ActionPermissionMaster> result = new List<ActionPermissionMaster>();
            result = await _genericRepository.GetAsync(DBConstants.FetchActionPermissionSP, new DynamicParameters());
            return result;
        }

        public async Task AddActionPermission(ActionPermissionMaster actionPermissionMaster)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("PermissionName", actionPermissionMaster.PermissionName);
            dynamicParameters.Add("IsActive", actionPermissionMaster.IsActive);
            dynamicParameters.Add("CreatedBy", actionPermissionMaster.CreatedBy);

            await _genericRepository.AddAsync(DBConstants.InsertActionPermissionSP, dynamicParameters);
        }

        public async Task UpdateActionPermission(ActionPermissionMaster actionPermissionMaster)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("PermissionID", actionPermissionMaster.PermissionID);
            dynamicParameters.Add("PermissionName", actionPermissionMaster.PermissionName);
            dynamicParameters.Add("IsActive", actionPermissionMaster.IsActive);
            dynamicParameters.Add("ModifiedBy", actionPermissionMaster.ModifiedBy);

            await _genericRepository.UpdateAsync(DBConstants.UpdateActionPermissionSP, dynamicParameters);
        }

        public async Task DeleteActionPermission(ActionPermissionMaster actionPermissionMaster)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("PermissionID", actionPermissionMaster.PermissionID);
            dynamicParameters.Add("ModifiedBy", actionPermissionMaster.ModifiedBy);

            await _genericRepository.UpdateAsync(DBConstants.DeleteActionPermissionSP, dynamicParameters);
        }
    }
}
