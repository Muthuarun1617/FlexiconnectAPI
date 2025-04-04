using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Application.DTOs;
using Flexiconnect.Domain.Implementation;
using Flexiconnect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Flexiconnect.Domain.Entities;
using System.Data;
using Flexiconnect.Infrastructure.Persistence.Interfaces;

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
