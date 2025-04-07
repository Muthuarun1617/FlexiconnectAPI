using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces;
using Flexiconnect.Shared.Constants;

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
            result = await _genericRepository.GetAsync(DBConstants.FetchActionMenuSP);
            return result;
        }
    }
}
