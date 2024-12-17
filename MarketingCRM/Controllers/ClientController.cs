using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketingCRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ClientResponse>), 200)]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _clientService.GetAllClients();
            return new JsonResult(result) { StatusCode = 200 };
        }
        [HttpPost]
        [ProducesResponseType(typeof(ClientResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> CreateClient(ClientRequest request)
        {
            try
            {
                var result = await _clientService.CreateClient(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
