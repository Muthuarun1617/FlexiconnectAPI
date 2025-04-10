using Dapper;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces;
using Flexiconnect.Shared.Constants;

namespace Flexiconnect.Domain.Implementation
{
    public class ActionMenuMasterDomain : IActionMenuMasterDomain
    {
        private readonly IGenericRepository<ActionMenuMaster> _genericRepository;
        
        public ActionMenuMasterDomain(IGenericRepository<ActionMenuMaster> genericRepository) {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<ActionMenuMaster>> GetActionMenu()
        {
            IEnumerable<ActionMenuMaster>  result = new List<ActionMenuMaster>();
            result = await _genericRepository.GetAsync(DBConstants.FetchActionMenuSP);
            return result;
        }

        public async Task AddActionMenu(ActionMenuMaster actionMenuMaster)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ActionMenuName", actionMenuMaster.ActionMenuName);
            dynamicParameters.Add("IsActive", actionMenuMaster.IsActive);
            dynamicParameters.Add("CreatedBy", actionMenuMaster.CreatedBy);

            await _genericRepository.AddAsync(DBConstants.InsertActionMenuSP, dynamicParameters);
        }

        public async Task UpdateActionMenu(ActionMenuMaster actionMenuMaster)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ActionMenuID", actionMenuMaster.ActionMenuID);
            dynamicParameters.Add("ActionMenuName", actionMenuMaster.ActionMenuName);
            dynamicParameters.Add("IsActive", actionMenuMaster.IsActive);
            dynamicParameters.Add("ModifiedBy", actionMenuMaster.ModifiedBy);

            await _genericRepository.UpdateAsync(DBConstants.UpdateActionMenuSP, dynamicParameters);
        }

        public async Task DeleteActionMenu(ActionMenuMaster actionMenuMaster)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ActionMenuID", actionMenuMaster.ActionMenuID);
            dynamicParameters.Add("ModifiedBy", actionMenuMaster.ModifiedBy);

            await _genericRepository.UpdateAsync(DBConstants.DeleteActionMenuSP, dynamicParameters);
        }
    }
}
