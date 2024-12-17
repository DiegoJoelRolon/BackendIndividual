using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketingCRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusService _taskStatusService;
        public TaskStatusController(ITaskStatusService taskStatusService)
        {
            _taskStatusService = taskStatusService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
        public async Task<IActionResult> GetAllTaskStatus()
        {
            var result = await _taskStatusService.GetAllTaskStatus();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
