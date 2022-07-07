using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using WebAPI_RIA2022.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_RIA2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviasController : ControllerBase
    {
        private IBL_Previas bl;

        public PreviasController(IBL_Previas _bl)
        {
            bl = _bl;
        }

        // POST api/<Previas>
        [HttpPost]
        [Authorize]
        public ActionResult<Previatura> Post([FromBody] PreviaCreateDTO value)
        {
            return Ok(bl.Add(value));
        }

        // DELETE api/<Previas>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<StatusDTO> Delete(int id)
        {
            bl.Delete(id);
            return Ok(new StatusDTO() { Status = true, Message = "" });
        }
    }
}
