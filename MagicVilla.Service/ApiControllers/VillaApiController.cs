using AutoMapper;
using MagicVilla.Service.Models;
using MagicVilla.Service.Models.Villa;
using MagicVilla.Service.Repository;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "admin, manager, broker")]
        public ActionResult<APIResponse> GetVillas()
        {
            try
            {
                IEnumerable<VillaModel> villaList = _villaContext.GetAll();

                _response.Result = _mapper.Map<List<VillaViewModel>>(villaList);

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

        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "admin, manager, broker")]
        public ActionResult<APIResponse> GetVillaById(Guid id)
        {

            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound();

            try
            {
                _response.Result = _mapper.Map<VillaViewModel>(villa);

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
        [Authorize(Roles = "admin, manager")]
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
                VillaModel newVilla = _mapper.Map<VillaModel>(villa);

                newVilla.CreatedDate = DateTime.Now;

                newVilla.LastUpdate = DateTime.Now;

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
        [Authorize(Roles = "admin, manager")]
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
        [Authorize(Roles = "admin, manager")]
        public ActionResult<APIResponse> UpdateVilla(Guid id, [FromBody] VillaUpdateModel updateVilla)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var villa = _villaContext.Get(x => x.Id == id);

            if (villa == null)
                return NotFound(id);

            try
            {
                updateVilla.LastUpdate = DateTime.Now;

                villa = _mapper.Map<VillaUpdateModel, VillaModel>(updateVilla, villa);

                _villaContext.Update(villa);

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

        /*
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
        */
    }
}

