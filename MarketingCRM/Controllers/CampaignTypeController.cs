using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketingCRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaignTypeController : ControllerBase
    {
        private readonly ICampaignTypeService _campaignTypeService;
        public CampaignTypeController(ICampaignTypeService campaignTypeService)
        {
            _campaignTypeService = campaignTypeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
        public async Task<IActionResult> GetallCampaignTypes()
        {
            var result = await _campaignTypeService.GetAllCampaignTypes();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
