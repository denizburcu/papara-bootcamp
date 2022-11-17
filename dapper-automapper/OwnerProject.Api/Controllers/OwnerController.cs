using Microsoft.AspNetCore.Mvc;
using OwnerProject.Services.Contract;

namespace OwnerProject.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult GetAllOWner()
        {
            var owners = _ownerService.GetAllOwners();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public IActionResult GetOwner(int id)
        {
            var owner = _ownerService.GetOwner(id);
            return Ok(owner);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddOwner([FromBody] OwnerDto ownerDto)
        {
            _ownerService.AddOwner(ownerDto);
            return Ok(ownerDto);
        }

        [HttpPut()]
        [Consumes("application/json")]
        public IActionResult UpdateOwner([FromBody] OwnerDto ownerDto)
        {
            _ownerService.UpdateOwner(ownerDto);
            return Ok(ownerDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOWner(int id)
        {
            _ownerService.DeleteOwner(id);
            return Ok("Owner successfully deleted.");
        }
    }
}