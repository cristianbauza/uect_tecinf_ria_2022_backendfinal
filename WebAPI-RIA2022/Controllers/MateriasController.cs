using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using WebAPI_RIA2022.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_RIA2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private IBL_Materias bl;

        public MateriasController(IBL_Materias _bl)
        {
            bl = _bl;
        }

        // GET: api/<MateriasController>/
        [HttpGet]
        public IEnumerable<Materia> Get()
        {
            return bl.Get();
        }

        // POST api/<MateriasController>
        [HttpPost]
        [Authorize]
        public ActionResult<Materia> Post([FromBody] Materia value)
        {
            return Ok(bl.Add(value));
        }

        // PUT api/<MateriasController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Materia> Put(int id, [FromBody] Materia value)
        {
            return Ok(bl.Update(value));
        }

        // DELETE api/<MateriasController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<StatusDTO> Delete(int id)
        {
            bl.Delete(id);
            return Ok(new StatusDTO() { Status = true, Message = "" });
        }
    }
}
