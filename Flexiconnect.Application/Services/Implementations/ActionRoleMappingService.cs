using AutoMapper;
using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddActionRoleMapping(ActionRoleMappingDto actionRoleMappingDto)
        {
            ActionRoleMapping actionRoleMapping = new ActionRoleMapping();
            actionRoleMapping = _mapper.Map<ActionRoleMappingDto, ActionRoleMapping>(actionRoleMappingDto);
            await _actionRoleMapping.AddActionRoleMapping(actionRoleMapping);
        }
    }
}
