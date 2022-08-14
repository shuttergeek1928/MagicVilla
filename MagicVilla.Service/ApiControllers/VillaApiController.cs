using AutoMapper;
using MagicVilla.Service.Data;
using MagicVilla.Service.Models;
using MagicVilla.Service.Models.Villa;
using MagicVilla.Service.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : Controller
    {
        private readonly IVillaRepository _villaContext;
        private readonly IMapper _mapper;
        protected readonly APIResponse _response;

        public VillaApiController(IVillaRepository villaContext, IMapper mapper)
        {
            _villaContext = villaContext;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        public ActionResult<APIResponse> GetVillas()
        {
            try
            {
                IEnumerable<VillaModel> villaList = _villaContext.GetAll();

                _response.Result = _mapper.Map<List<VillaViewModel>>(villaList);

                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch(Exception e)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<APIResponse> GetVillaById(Guid id)
        {
            
            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound();

            try { 
                _response.Result = _mapper.Map<List<VillaViewModel>>(villa);

                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { e.ToString() };
            }

            return _response;

        }

        [HttpPost]
        public ActionResult<APIResponse> CreateNewVilla([FromBody] VillaCreateModel villa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (villa == null)
                return BadRequest();

            try
            {
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

                _response.Result = newVilla;

                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult<APIResponse> DeleteVilla(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound();

            try
            {
                _villaContext.Remove(villa);

                _villaContext.Save();

                _response.IsSuccess = true;

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public ActionResult<APIResponse> UpdateVilla(Guid id, [FromBody] VillaUpdateModel updateVilla)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound(id);

            try
            {
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

                _response.Result = villa;

                _response.IsSuccess = true;

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { e.ToString() };
            }

            return _response;
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
