using System.Diagnostics.Eventing.Reader;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using OwnerApi;

namespace Owner.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            return Ok(OwnerData.OwnerList);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            if (owner == null)
                throw new InvalidRequestException("Owner Is Empty");

            if (owner.Description != null && owner.Description.Contains("hack"))
                throw new InvalidRequestException("Wrong Content");
            else
            {
                OwnerData.OwnerList.Add(owner);
                return Ok(owner);
            }
        }

        [HttpPut("{id:int}")]
        [Consumes("application/json")]
        public IActionResult UpdateOwner(int id, [FromBody] Owner updatedOwner)
        {
            var owner = OwnerData.OwnerList.SingleOrDefault(owner => owner.Id == id);
            if (owner == null)
                throw new OwnerNotFoundException($"{id} no owner not found.");

            owner.Id = updatedOwner.Id != default ? updatedOwner.Id : owner.Id;
            owner.Name = updatedOwner.Name != default ? updatedOwner.Name : owner.Name;
            owner.Surname = updatedOwner.Surname != default ? updatedOwner.Surname : owner.Surname;
            owner.Date = updatedOwner.Date != default ? updatedOwner.Date : owner.Date;
            owner.Description = updatedOwner.Description != default ? updatedOwner.Description : owner.Description;
            owner.Type = updatedOwner.Type != default ? updatedOwner.Type : owner.Type;

            return Ok(updatedOwner);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {
            var owner = OwnerData.OwnerList.SingleOrDefault(owner => owner.Id == id);
            if (owner == null)
                throw new OwnerNotFoundException($"{id} no owner not found.");

            OwnerData.OwnerList.Remove(owner);
            return Ok("Owner successfully deleted.");
        }
    }
}
