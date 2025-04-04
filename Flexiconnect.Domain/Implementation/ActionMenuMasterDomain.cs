using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            result = await _genericRepository.GetAsync("ActionMenuMaster");
            return result;
        }
    }
}
