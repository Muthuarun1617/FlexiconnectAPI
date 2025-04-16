using AutoMapper;
using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;

namespace Flexiconnect.Application.Services.Implementations
{
    public class ActionRoleUserMappingService : IActionRoleUserMappingService
    {
        private readonly IActionRoleUserMappingDomain _actionRoleUserMapping;
        private readonly IMapper _mapper;
        public ActionRoleUserMappingService(IActionRoleUserMappingDomain actionRoleUserMapping, IMapper mapper)
        {
            _actionRoleUserMapping = actionRoleUserMapping;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActionRoleUserMappingFetchDto>> GetActionRoleUserMapping(int RoleID, int UserID)
        {
            IEnumerable<ActionRoleUserMappingFetchDto> actionRoleUserMappings = new List<ActionRoleUserMappingFetchDto>();
            var response = await _actionRoleUserMapping.GetActionRoleUserMapping(RoleID, UserID);
            actionRoleUserMappings = _mapper.Map<IEnumerable<ActionRoleUserMapping>, IEnumerable<ActionRoleUserMappingFetchDto>>(response.ToList());
            return actionRoleUserMappings;
        }

        public async Task AddActionRoleUserMapping(ActionRoleUserMappingDto actionRoleUserMappingDto)
        {
            ActionRoleUserMapping actionRoleUserMapping = new ActionRoleUserMapping();
            actionRoleUserMapping = _mapper.Map<ActionRoleUserMappingDto, ActionRoleUserMapping>(actionRoleUserMappingDto);
            await _actionRoleUserMapping.AddActionRoleUserMapping(actionRoleUserMapping);
        }
    }
}
