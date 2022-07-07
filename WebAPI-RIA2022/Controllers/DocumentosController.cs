using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;
using Shared.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_RIA2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private IBL_Documentos bl;

        public DocumentosController(IBL_Documentos _bl)
        {
            bl = _bl;
        }

        // GET: api/<DocumentosController>/Paged
        [HttpGet("Paged/{offset}/{limit}")]
        [Authorize]
        public ActionResult<PagedListResponse<Documento>> GetPaged(int offset, int limit)
        {
            return Ok(bl.GetPaged(offset, limit));
        }

        // GET: api/<DocumentosController>/Activos
        [HttpGet("Activos")]
        public IEnumerable<Documento> GetActivosPorTipo(string tipo)
        {
            return bl.GetActivos(tipo);
        }

        // POST api/<DocumentosController>
        [HttpPost]
        [Authorize]
        public ActionResult<Documento> Post([FromBody] Documento value)
        {
            return Ok(bl.Add(value));
        }

        // PUT api/<DocumentosController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Documento> Put(int id, [FromBody] Documento value)
        {
            return Ok(bl.Update(value));
        }
    }
}
