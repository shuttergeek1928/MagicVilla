using MagicVilla.Service.Data;
using MagicVilla.Service.Logging;
using MagicVilla.Service.Models.Villa;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : Controller
    {
        //private readonly ILogging _logger;

        public VillaApiController(ILogging logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //_logger.Log("Fetching all Villas", "Error");
            return Ok(VillaDataStore.villaList);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<VillaDTO> GetVillaByName(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = VillaDataStore.villaList.FirstOrDefault(x => x.Id == id);

            if (villa == null)
                return NotFound();

            return Ok(villa);
        }

        [HttpPost]
        public ActionResult<VillaDTO> CreateNewVilla([FromBody] VillaCreateModel villa)
        {
            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError("CustomError", "You are missing some fields.");
                return BadRequest(ModelState);
            }

            if (villa == null)
                return BadRequest();

            var newVilla = new VillaDTO()
            {
                Id = Guid.NewGuid(),
                Name = villa.Name,
            };

            VillaDataStore.villaList.Add(newVilla);

            return Ok(newVilla);
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult DeleteVilla(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = VillaDataStore.villaList.FirstOrDefault(x => x.Id == id);

            if (villa == null)
                return NotFound();

            VillaDataStore.villaList.Remove(villa);

            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateVilla(Guid id, [FromBody] VillaCreateModel newVilla)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = VillaDataStore.villaList.FirstOrDefault(x => x.Id == id);

            if (villa == null)
                return NotFound(id);

            villa.Name = newVilla.Name;

            return Ok(villa);
        }

        [HttpPatch]
        public ActionResult UpdatePartialVilla(Guid id, JsonPatchDocument<VillaDTO> patchVilla)
        {
            if (patchVilla == null)
                return BadRequest();

            var villa = VillaDataStore.villaList.FirstOrDefault(x => x.Id == id);

            if (villa == null)
                return NotFound();

            patchVilla.ApplyTo(villa, ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            return NoContent();
        }
    }
}
