using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketingCRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        public ProjectController(IProjectService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ProjectResponse>), 200)]
        public async Task<IActionResult> GetProjectsByFilter(string? name, int? campaign, int? client, int? offset, int? size)
        {
            var result = await _service.GetAllProjectResponse(name, campaign, client, offset, size);
            return new JsonResult(result) { StatusCode = 200 };
          
        }
        [HttpPost]
        [ProducesResponseType(typeof(ProjectDetailsResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> CreateProject(ProjectRequest request)
        {
            try
            {
                var result = await _service.CreateProject(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectDetailsResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            try
            {
                var result = await _service.GetProjectById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionNotFound ex)
            {

                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 404 };
            }

        }


        [HttpPatch("{id}/Interactions")]
        [ProducesResponseType(typeof(List<InteractionResponse>), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> AddInteraction(InteractionRequest request, Guid id)
        {
            try
            {
                var result = await _service.AddInteraction(request, id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (Conflict ex)
            {

                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }
        [HttpPatch("{id}/tasks")]
        [ProducesResponseType(typeof(List<TaskResponse>), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> AddTaskToProject(TaskRequest request, Guid id)
        {
            try
            {
                var result = await _service.AddTaskToProject(request, id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (Conflict ex)
            {

                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("/api/v1/Tasks/{id}")]
        [ProducesResponseType(typeof(List<TaskResponse>), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> UpdateTask(TaskRequest request, Guid id)
        {
            try
            {
                var result = await _service.UpdateTask(request, id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (Conflict ex)
            {

                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }


        }
    }
}
