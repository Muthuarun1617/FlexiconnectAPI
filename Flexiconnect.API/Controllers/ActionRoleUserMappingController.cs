using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Shared.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flexiconnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionRoleUserMappingController : ControllerBase
    {
        private readonly IActionRoleUserMappingService _actionRoleUserMappingService;
        public ActionRoleUserMappingController(IActionRoleUserMappingService actionRoleUserMappingService)
        {
            _actionRoleUserMappingService = actionRoleUserMappingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActionRoleUserMappingData(int RoleID, int UserID)
        {
            IEnumerable<ActionRoleUserMappingFetchDto> response = new List<ActionRoleUserMappingFetchDto>();
            try
            {
                response = await _actionRoleUserMappingService.GetActionRoleUserMapping(RoleID, UserID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddActionRoleUserMappingData(IEnumerable<ActionRoleUserMappingDto> actionRoleUserMappingDto)
        {
            try
            {
                await _actionRoleUserMappingService.AddActionRoleUserMapping(actionRoleUserMappingDto);
                return Ok(new { message = MessageConstants.SuccessInsertResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
    }
}
