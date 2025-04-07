using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Flexiconnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionMenuMasterController : ControllerBase
    {
        private readonly IActionMenuMasterService _actionMenuMasterService;
        public ActionMenuMasterController(IActionMenuMasterService actionMenuMasterService) 
        {
            _actionMenuMasterService = actionMenuMasterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActionMenuData()
        {
            IEnumerable<ActionMenuDto> response = new List<ActionMenuDto>();
            try
            {
                response = await _actionMenuMasterService.GetActionMenuMaster();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
    }
}
