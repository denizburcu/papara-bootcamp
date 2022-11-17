using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using OwnerProject.Domain.Entities;
using OwnerProject.Services.Contract;

namespace OwnerProject.API.Controller
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
        public IActionResult GetAllOwners()
        {
            var owners = _ownerService.GetAllOwner();
            return Ok(owners);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            _ownerService.AddOwner(owner);
            return Ok(owner);
        }

        [HttpPut()]
        [Consumes("application/json")]
        public IActionResult UpdateOwner([FromBody] Owner updatedOwner)
        {
            _ownerService.UpdateOwner(updatedOwner);
            return Ok(updatedOwner);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {   _ownerService.DeleteOwner(id);
            return Ok("Owner successfully deleted.");
        }
    }
}
