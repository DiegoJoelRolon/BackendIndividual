using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketingCRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypeController : ControllerBase
    {
        private readonly IInteractionTypeService _service;
        public InteractionTypeController(IInteractionTypeService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
        public async Task<IActionResult> GetAllInteractionTypes()
        {
            var result = await _service.GetAllInteractionTypes();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
