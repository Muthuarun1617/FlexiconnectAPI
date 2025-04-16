using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Flexiconnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionRoleMappingController : ControllerBase
    {
        private readonly IActionRoleMappingService _actionRoleMappingService;
        public ActionRoleMappingController(IActionRoleMappingService actionRoleMappingService)
        {
            _actionRoleMappingService = actionRoleMappingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActionRoleMappingData(int RoleID)
        {
            IEnumerable<ActionRoleMappingFetchDto> response = new List<ActionRoleMappingFetchDto>();
            try
            {
                response = await _actionRoleMappingService.GetActionRoleMapping(RoleID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddActionRoleMappingData(ActionRoleMappingDto actionRoleMappingDto)
        {
            try
            {
                await _actionRoleMappingService.AddActionRoleMapping(actionRoleMappingDto);
                return Ok(new { message = MessageConstants.SuccessInsertResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
    }
}
