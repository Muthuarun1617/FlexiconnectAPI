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
            result = await _genericRepository.GetAsync(DBConstants.FetchActionMenuSP, new DynamicParameters());
            return result;
        }

        public async Task<IEnumerable<ActionMenuMaster>> GetActionMenuByName(string menuName)
        {
            IEnumerable<ActionMenuMaster> result = new List<ActionMenuMaster>();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ActionMenuName", menuName);
            result = await _genericRepository.GetAsync(DBConstants.FetchActionMenuByNameSP, dynamicParameters);
            return result;
        }

        public async Task AddActionMenu(IEnumerable<ActionMenuMaster> actionMenuMaster)
        {
            if(actionMenuMaster.Count() > 0)
            {
                foreach (var item in actionMenuMaster)
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("ActionMenuName", item.ActionMenuName);
                    dynamicParameters.Add("IsActive", item.IsActive);
                    dynamicParameters.Add("CreatedBy", item.CreatedBy);

                    await _genericRepository.AddAsync(DBConstants.InsertActionMenuSP, dynamicParameters);
                }
            }
        }

        public async Task UpdateActionMenu(IEnumerable<ActionMenuMaster> actionMenuMaster)
        {
            if (actionMenuMaster.Count() > 0)
            {
                foreach (var item in actionMenuMaster)
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("ActionMenuID", item.ActionMenuID);
                    dynamicParameters.Add("ActionMenuName", item.ActionMenuName);
                    dynamicParameters.Add("IsActive", item.IsActive);
                    dynamicParameters.Add("ModifiedBy", item.ModifiedBy);

                    await _genericRepository.UpdateAsync(DBConstants.UpdateActionMenuSP, dynamicParameters);
                }
            }  
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
