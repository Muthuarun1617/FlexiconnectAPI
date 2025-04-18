using AutoMapper;
using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;

namespace Flexiconnect.Application.Services.Implementations
{
    public class ActionRoleMappingService : IActionRoleMappingService
    {
        private readonly IActionRoleMappingDomain _actionRoleMapping;
        private readonly IMapper _mapper;
        public ActionRoleMappingService(IActionRoleMappingDomain actionRoleMapping, IMapper mapper)
        {
            _actionRoleMapping = actionRoleMapping;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActionRoleMappingFetchDto>> GetActionRoleMapping(int RoleID)
        {
            IEnumerable<ActionRoleMappingFetchDto> actionRoleMappings = new List<ActionRoleMappingFetchDto>();
            var response = await _actionRoleMapping.GetActionRoleMapping(RoleID);
            actionRoleMappings = _mapper.Map<IEnumerable<ActionRoleMapping>, IEnumerable<ActionRoleMappingFetchDto>>(response.ToList());
            return actionRoleMappings;
        }

        public async Task AddActionRoleMapping(IEnumerable<ActionRoleMappingDto> actionRoleMappingDto)
        {
            IEnumerable<ActionRoleMapping> actionRoleMapping = new List<ActionRoleMapping>();
            actionRoleMapping = _mapper.Map<IEnumerable<ActionRoleMappingDto>, IEnumerable<ActionRoleMapping>>(actionRoleMappingDto);
            await _actionRoleMapping.AddActionRoleMapping(actionRoleMapping);
        }
    }
}
