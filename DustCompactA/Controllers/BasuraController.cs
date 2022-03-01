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

        [HttpGet]
        public async Task<IActionResult> GetAllBasuras()
        {
            return Ok(await _basuraRepositoy.GetAllBasuras());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDetalles(int id)
        {
            return Ok(await _basuraRepositoy.GetBasurasDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasura([FromBody] Basuras basura)
        {
            if (basura == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _basuraRepositoy.insertBasuras(basura);

            return Created("inserted", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasura([FromBody] Basuras basura)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasura(int id)
        {
            await _basuraRepositoy.deleteBasuras(new Basuras { iId = id });

            return NoContent();
        }
    }
}
