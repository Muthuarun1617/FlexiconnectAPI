using AutoMapper;
using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;

namespace Flexiconnect.Application.Services.Implementations
{
    public class ActionMenuMasterService : IActionMenuMasterService
    {
        private readonly IActionMenuMasterDomain _actionMenuMaster;
        private readonly IMapper _mapper;
        public ActionMenuMasterService(IActionMenuMasterDomain actionMenuMaster, IMapper mapper)
        {
            _actionMenuMaster = actionMenuMaster;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActionMenuDto>> GetActionMenuMaster()
        {
            IEnumerable<ActionMenuDto> actionMenuMasters = new List<ActionMenuDto>(); 
            var response = await _actionMenuMaster.GetActionMenu();
            actionMenuMasters = _mapper.Map< IEnumerable < ActionMenuMaster > ,IEnumerable <ActionMenuDto>>(response.ToList());
            return actionMenuMasters;
        }

        public async Task AddActionMenuMaster(IEnumerable<ActionMenuAddDto> actionMenuAddDto)
        {
            IEnumerable<ActionMenuMaster> actionMenuMaster = new List<ActionMenuMaster>();
            actionMenuMaster = _mapper.Map< IEnumerable<ActionMenuAddDto>, IEnumerable<ActionMenuMaster>>(actionMenuAddDto);
            await _actionMenuMaster.AddActionMenu(actionMenuMaster);
        }

        public async Task UpdateActionMenuMaster(IEnumerable<ActionMenuUpdateDto> actionMenuDto)
        {
            IEnumerable<ActionMenuMaster> actionMenuMaster = new List<ActionMenuMaster>();
            actionMenuMaster = _mapper.Map<IEnumerable<ActionMenuUpdateDto>, IEnumerable<ActionMenuMaster>>(actionMenuDto);
            await _actionMenuMaster.UpdateActionMenu(actionMenuMaster);
        }

        public async Task DeleteActionMenuMaster(ActionMenuDeleteDto actionMenuDeleteDto)
        {
            ActionMenuMaster actionMenuMaster = new ActionMenuMaster();
            actionMenuMaster = _mapper.Map<ActionMenuDeleteDto, ActionMenuMaster>(actionMenuDeleteDto);
            await _actionMenuMaster.DeleteActionMenu(actionMenuMaster);
        }
    }
}
