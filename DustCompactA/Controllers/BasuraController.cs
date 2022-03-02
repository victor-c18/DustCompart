using DustCompact.Bussiones.Repositories;
using DustCompact.Model;
using Microsoft.AspNetCore.Mvc;

namespace DustCompactA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasuraController : Controller
    {

        private readonly IBasuraRepositoy _basuraRepositoy;

        public BasuraController(IBasuraRepositoy basuraRepositoy)
        {
            _basuraRepositoy = basuraRepositoy;
        }
        /// <summary>
        /// diferentes procedimientos de una API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBasuras()
        {
            return Ok(await _basuraRepositoy.GetAllBasuras());///
        }

        [HttpGet("{id}")]/// implementa el id de recuperacion
        public async Task<IActionResult> GetAllDetalles(int id)
        {
            return Ok(await _basuraRepositoy.GetBasurasDetails(id));
        }

        /// <summary>
        /// create de un nuevo elementos
        /// </summary>
        /// <param name="basura">basuras en un objeto del de los endpoints</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBasura([FromBody] BasurasDTO basura)
        {
           if (basura == null)
            {
                return BadRequest();///respuestas de microsoft
            }
            if (!ModelState.IsValid)///validacion del modelo 
            {
                return BadRequest(ModelState);
            }

            var created = await _basuraRepositoy.insertBasuras(basura); ///variable await 

            return Created("inserted", created);
        }

        /// <summary>
        /// update de la base de datos de basura
        /// </summary>
        /// <param name="basura">se utiliza la librerias DTO para instanciar el objeto basura</param>
        /// <returns>retorna un nocontent</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBasura([FromBody] BasurasDTO basura)
        {
            if (basura == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _basuraRepositoy.insertBasuras(basura);

            return NoContent();



        }

        /// <summary>
        /// delete 
        /// </summary>
        /// <param name="id">id del elemento a eliminar</param>
        /// <returns>retorna un nocontent</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasura(int id)
        {
            await _basuraRepositoy.deleteBasuras(new BasurasDTO { iId = id });

            return NoContent();
        }
    }
}
