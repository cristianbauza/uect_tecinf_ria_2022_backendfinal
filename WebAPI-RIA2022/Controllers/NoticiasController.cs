using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;

namespace WebAPI_RIA2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private IBL_Noticias bl;

        public NoticiasController(IBL_Noticias _bl)
        {
            bl = _bl;
        }

        // GET: api/Noticias
        //[HttpGet]
        //[Authorize]
        //public IEnumerable<Noticia> Get()
        //{
        //    return bl.GetAll();
        //}

        // GET: api/Noticias/Activas
        [HttpGet("Activas")]
        public IEnumerable<Noticia> GetActivas()
        {
            return bl.GetActivas();
        }

        // GET: api/Noticias/Paged
        [HttpGet("Paged/{offset}/{limit}")]
        public ActionResult<PagedListResponse<Noticia>> GetPaged(int offset, int limit)
        {
            return Ok(bl.GetPaged(offset, limit));
        }

        // GET: api/Noticias/5
        [HttpGet("{id}")]
        public ActionResult<Noticia> Get(long id)
        {
            Noticia result = bl.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/Noticias
        [HttpPost]
        [Authorize]
        public ActionResult<Noticia> Post([FromBody] Noticia x)
        {
            try
            {
                Noticia result = bl.Add(x);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO Retornar error interno.
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Noticias/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Noticia> Put(long id, [FromBody] Noticia x)
        {
            try
            {
                if (id != x.Id)
                    throw new Exception("El id de la entidad no coincide con el id del parámetro.");

                Noticia result = bl.Update(x);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO Retornar error interno.
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Noticias/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(long id)
        {
            bl.Delete(id);
            return Ok();
        }
    }
}
