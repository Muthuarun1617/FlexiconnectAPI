using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Shared.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flexiconnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionPermissionMasterController : ControllerBase
    {
        private readonly IActionPermissionMasterService _actionPermissionMasterService;
        public ActionPermissionMasterController(IActionPermissionMasterService actionPermissionMasterService)
        {
            _actionPermissionMasterService = actionPermissionMasterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActionPermissionData()
        {
            IEnumerable<ActionPermissionDto> response = new List<ActionPermissionDto>();
            try
            {
                response = await _actionPermissionMasterService.GetActionPermissionMaster();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddActionPermissionData(IEnumerable<ActionPermissionAddDto> actionPermissionAddDto)
        {
            try
            {
                await _actionPermissionMasterService.AddActionPermissionMaster(actionPermissionAddDto);
                return Ok(new { message = MessageConstants.SuccessInsertResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActionPermissionData(IEnumerable<ActionPermissionUpdateDto> actionPermissionUpdateDto)
        {
            try
            {
                await _actionPermissionMasterService.UpdateActionPermissionMaster(actionPermissionUpdateDto);
                return Ok(new { message = MessageConstants.SuccessUpdateResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteActionPermissionData(ActionPermissionDeleteDto actionPermissionDeleteDto)
        {
            try
            {
                await _actionPermissionMasterService.DeleteActionPermissionMaster(actionPermissionDeleteDto);
                return Ok(new { message = MessageConstants.SuccessDeleteResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
    }
}
