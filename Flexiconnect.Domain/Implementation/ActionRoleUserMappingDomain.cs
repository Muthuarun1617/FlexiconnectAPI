using Dapper;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces;
using Flexiconnect.Shared.Constants;

namespace Flexiconnect.Domain.Implementation
{
    public class ActionRoleUserMappingDomain : IActionRoleUserMappingDomain
    {
        private readonly IGenericRepository<ActionRoleUserMapping> _genericRepository;

        public ActionRoleUserMappingDomain(IGenericRepository<ActionRoleUserMapping> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<ActionRoleUserMapping>> GetActionRoleUserMapping(int RoleID, int UserID)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("RoleID", RoleID);
            dynamicParameters.Add("UserID", UserID);

            IEnumerable<ActionRoleUserMapping> result = new List<ActionRoleUserMapping>();
            result = await _genericRepository.GetAsync(DBConstants.FetchActionRoleUserMappingSP, dynamicParameters);
            return result;
        }

        public async Task AddActionRoleUserMapping(ActionRoleUserMapping actionRoleUserMapping)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("RoleMappingID", actionRoleUserMapping.RoleMappingID);
            dynamicParameters.Add("UserID", actionRoleUserMapping.UserID);
            dynamicParameters.Add("IsActive", actionRoleUserMapping.IsActive);
            dynamicParameters.Add("CreatedBy", actionRoleUserMapping.CreatedBy);

            await _genericRepository.AddAsync(DBConstants.InsertUpdateActionRoleUserMappingSP, dynamicParameters);
        }
    }
}
