using Dapper;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces;
using Flexiconnect.Shared.Constants;

namespace Flexiconnect.Domain.Implementation
{
    public class ActionRoleMappingDomain : IActionRoleMappingDomain
    {
        private readonly IGenericRepository<ActionRoleMapping> _genericRepository;

        public ActionRoleMappingDomain(IGenericRepository<ActionRoleMapping> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<ActionRoleMapping>> GetActionRoleMapping(int RoleID)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("RoleID", RoleID);

            IEnumerable<ActionRoleMapping> result = new List<ActionRoleMapping>();
            result = await _genericRepository.GetAsync(DBConstants.FetchActionRoleMappingSP, dynamicParameters);
            return result;
        }

        public async Task AddActionRoleMapping(IEnumerable<ActionRoleMapping> actionRoleMapping)
        {
            if (actionRoleMapping.Count() > 0)
            {
                foreach (var item in actionRoleMapping)
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("RoleID", item.RoleID);
                    dynamicParameters.Add("ActionMenuID", item.ActionMenuID);
                    dynamicParameters.Add("PermissionID", item.PermissionID);
                    dynamicParameters.Add("IsActive", item.IsActive);
                    dynamicParameters.Add("CreatedBy", item.CreatedBy);

                    await _genericRepository.AddAsync(DBConstants.InsertUpdateActionRoleMappingSP, dynamicParameters);
                }
            }
        }
    }
}
