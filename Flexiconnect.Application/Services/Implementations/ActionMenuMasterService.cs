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
    }
}
