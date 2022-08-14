using AutoMapper;
using MagicVilla.Service.Data;
using MagicVilla.Service.Models.Villa;
using MagicVilla.Service.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : Controller
    {
        private readonly IVillaRepository _villaContext;
        private readonly IMapper _mapper;

        public VillaApiController(IVillaRepository villaContext, IMapper mapper)
        {
            _villaContext = villaContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaViewModel>> GetVillas()
        {
            IEnumerable<VillaModel> villaList = _villaContext.GetAll();
            
            return Ok(_mapper.Map<List<VillaViewModel>>(villaList));
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<VillaViewModel> GetVillaByName(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound();

            return Ok(_mapper.Map<VillaViewModel>(villa));
        }

        [HttpPost]
        public ActionResult<VillaViewModel> CreateNewVilla([FromBody] VillaCreateModel villa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (villa == null)
                return BadRequest();

            /*
            var newVilla = new VillaModel()
            {
                Id = Guid.NewGuid(),
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                Area = villa.Area,
                Occupancy = villa.Occupancy,
                Amenities = villa.Amenities,
                ImageUrl = villa.ImageUrl,
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now
            };
            */

            
            VillaModel newVilla = _mapper.Map<VillaModel>(villa);

            _villaContext.Create(newVilla);

            _villaContext.Save();

            return Ok(newVilla);
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult DeleteVilla(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound();

            _villaContext.Remove(villa);

            _villaContext.Save();

            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateVilla(Guid id, [FromBody] VillaUpdateModel updateVilla)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound(id);
            /*
            villa.Name = updateVilla.Name;
            villa.Details = updateVilla.Details;
            villa.Rate = updateVilla.Rate;
            villa.Area = updateVilla.Area;
            villa.Occupancy = updateVilla.Occupancy;
            villa.Amenities = updateVilla.Amenities;
            villa.ImageUrl = updateVilla.ImageUrl;
            villa.LastUpdate = DateTime.Now;
            */

            updateVilla.LastUpdate = DateTime.Now;

            villa = _mapper.Map<VillaModel>(updateVilla);

            _villaContext.Update(villa);
            
            _villaContext.Save();

            return Ok(villa);
        }

        [HttpPatch]
        public ActionResult UpdatePartialVilla(Guid id, JsonPatchDocument<VillaViewModel> patchVilla)
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
