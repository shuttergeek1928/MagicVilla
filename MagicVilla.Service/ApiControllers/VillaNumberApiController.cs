using AutoMapper;
using MagicVilla.Service.Data;
using MagicVilla.Service.Models;
using MagicVilla.Service.Models.Villa;
using MagicVilla.Service.Models.VillaNumber;
using MagicVilla.Service.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace MagicVilla.Service.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberApiController : Controller
    {
        private readonly IVillaNumberRepository _villaNumberContext;
        private readonly IVillaRepository _villaContext;
        private readonly IMapper _mapper;
        protected readonly APIResponse _response;

        public VillaNumberApiController(IVillaNumberRepository villaNumberContext, IVillaRepository villaContext, IMapper mapper)
        {
            _villaNumberContext = villaNumberContext;
            _villaContext = villaContext;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        public ActionResult<APIResponse> GetAllVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumberModel> villaNumberList = _villaNumberContext.GetAll();

                _response.Result = _mapper.Map<List<VillaNumberViewModel>>(villaNumberList);

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

        [HttpGet("{villaNumber:int}")]
        public ActionResult<APIResponse> GetVillaNumber(int villaNumber)
        {

            if (villaNumber <= 0)
                return BadRequest();

            var villa = _villaNumberContext.Get(x => x.VillaNumber == villaNumber);

            if (villa == null)
                return NotFound();

            try
            {
                _response.Result = _mapper.Map<List<VillaNumberViewModel>>(villa);

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
        public ActionResult<APIResponse> CreateNewVillaNumber([FromBody] VillaNumberCreateModel createVillaNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (createVillaNumber == null || createVillaNumber.VillaNumber <= 0)
                return BadRequest();

            if (_villaNumberContext.Get(x => x.VillaNumber == createVillaNumber.VillaNumber) != null)
            {
                ModelState.AddModelError("CustomError", "Villa number already exist");
                return BadRequest(ModelState);
            }

            if (_villaContext.Get(x => x.Id == createVillaNumber.VillaId) == null)
            {
                ModelState.AddModelError("CustomError", "Villa id does not exist");
                return BadRequest(ModelState);
            }

            try
            {
                createVillaNumber.CreatedDate = DateTime.Now;
                createVillaNumber.LastUpdated = DateTime.Now;

                VillaNumberModel newVilla = _mapper.Map<VillaNumberModel>(createVillaNumber);

                _villaNumberContext.Create(newVilla);

                _villaNumberContext.Save();

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

        [HttpDelete]
        public ActionResult<APIResponse> DeleteVilla(int villaNumber)
        {
            if (villaNumber <= 0)
                return BadRequest();

            var villa = _villaNumberContext.Get(x => x.VillaNumber == villaNumber);

            if (villa == null)
                return NotFound();

            try
            {
                _villaNumberContext.Remove(villa);

                _villaNumberContext.Save();

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
        public ActionResult<APIResponse> UpdateVillaNumber(int villaNumber, [FromBody] VillaNumberUpdateModel updateVillaNumber)
        {
            if (villaNumber <= 0)
                return BadRequest();

            var villa = _villaNumberContext.Get(x => x.VillaNumber == villaNumber, false);

            if (villa == null)
            {
                ModelState.AddModelError("CustomError", "Villa number not found");
                return NotFound();
            }

            if (_villaContext.Get(x => x.Id == updateVillaNumber.VillaId) == null)
            {
                ModelState.AddModelError("CustomError", "Villa id does not exist");
                return BadRequest(ModelState);
            }

            try
            {

                updateVillaNumber.LastUpdated = DateTime.Now;

                villa = _mapper.Map<VillaNumberModel>(updateVillaNumber);

                _villaNumberContext.Update(villa);

                _villaNumberContext.Save();

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

    }
}
