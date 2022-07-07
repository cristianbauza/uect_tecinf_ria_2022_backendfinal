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
    public class UnidadesCurricularesController : ControllerBase
    {
        private IBL_UnidadesCurriculares bl;

        public UnidadesCurricularesController(IBL_UnidadesCurriculares _bl)
        {
            bl = _bl;
        }

        // GET: api/<UnidadesCurriculares>/
        [HttpGet]
        public IEnumerable<UnidadCurricular> Get()
        {
            return bl.Get();
        }

        // GET: api/<UnidadesCurriculares>/5
        [HttpGet("{id}")]
        public ActionResult<UnidadCurricular> Get(long id)
        {
            return Ok(bl.Get(id));
        }

        // POST api/<UnidadesCurriculares>
        [HttpPost]
        [Authorize]
        public ActionResult<UnidadCurricular> Post([FromBody] UnidadCurricular value)
        {
            return Ok(bl.Add(value));
        }

        // PUT api/<UnidadesCurriculares>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<UnidadCurricular> Put(int id, [FromBody] UnidadCurricular value)
        {
            return Ok(bl.Update(value));
        }

        // DELETE api/<UnidadesCurriculares>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<StatusDTO> Delete(int id)
        {
            bl.Delete(id);
            return Ok(new StatusDTO() { Status = true, Message = "" });
        }
    }
}
