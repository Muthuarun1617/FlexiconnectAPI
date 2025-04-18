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
    public class ActionPermissionMasterService : IActionPermissionMasterService
    {
        private readonly IActionPermissionMasterDomain _actionPermissionMaster;
        private readonly IMapper _mapper;
        public ActionPermissionMasterService(IActionPermissionMasterDomain actionPermissionMaster, IMapper mapper)
        {
            _actionPermissionMaster = actionPermissionMaster;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActionPermissionDto>> GetActionPermissionMaster()
        {
            IEnumerable<ActionPermissionDto> actionPermissionMasters = new List<ActionPermissionDto>();
            var response = await _actionPermissionMaster.GetActionPermission();
            actionPermissionMasters = _mapper.Map<IEnumerable<ActionPermissionMaster>, IEnumerable<ActionPermissionDto>>(response.ToList());
            return actionPermissionMasters;
        }

        public async Task AddActionPermissionMaster(IEnumerable<ActionPermissionAddDto> actionPermissionAddDto)
        {
            IEnumerable<ActionPermissionMaster> actionPermissionMaster = new List<ActionPermissionMaster>();
            actionPermissionMaster = _mapper.Map<IEnumerable<ActionPermissionAddDto>, IEnumerable<ActionPermissionMaster>>(actionPermissionAddDto);
            await _actionPermissionMaster.AddActionPermission(actionPermissionMaster);
        }

        public async Task UpdateActionPermissionMaster(IEnumerable<ActionPermissionUpdateDto> actionPermissionUpdateDto)
        {
            IEnumerable<ActionPermissionMaster> actionPermissionMaster = new List<ActionPermissionMaster>();
            actionPermissionMaster = _mapper.Map<IEnumerable<ActionPermissionUpdateDto>, IEnumerable<ActionPermissionMaster>>(actionPermissionUpdateDto);
            await _actionPermissionMaster.UpdateActionPermission(actionPermissionMaster);
        }

        public async Task DeleteActionPermissionMaster(ActionPermissionDeleteDto actionPermissionDeleteDto)
        {
            ActionPermissionMaster actionPermissionMaster = new ActionPermissionMaster();
            actionPermissionMaster = _mapper.Map<ActionPermissionDeleteDto, ActionPermissionMaster>(actionPermissionDeleteDto);
            await _actionPermissionMaster.DeleteActionPermission(actionPermissionMaster);
        }
    }
}
