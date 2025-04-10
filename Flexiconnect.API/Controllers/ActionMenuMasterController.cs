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

        [HttpPost]
        public async Task<IActionResult> AddActionMenuData(ActionMenuAddDto actionMenuAddDto)
        {
            try
            {
                await _actionMenuMasterService.AddActionMenuMaster(actionMenuAddDto);
                return Ok(new { message = MessageConstants.SuccessInsertResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActionMenuData(ActionMenuUpdateDto actionMenuDto)
        {
            try
            {
                await _actionMenuMasterService.UpdateActionMenuMaster(actionMenuDto);
                return Ok(new { message = MessageConstants.SuccessUpdateResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteActionMenuData(ActionMenuDeleteDto actionMenuDeleteDto)
        {
            try
            {
                await _actionMenuMasterService.DeleteActionMenuMaster(actionMenuDeleteDto);
                return Ok(new { message = MessageConstants.SuccessDeleteResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
    }
}
