using AutoMapper;
using Flexiconnect.Application.Services.Implementations;
using Flexiconnect.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var response = await _actionMenuMasterService.GetActionMenuMaster();
            return Ok(response);
        }
    }
}
