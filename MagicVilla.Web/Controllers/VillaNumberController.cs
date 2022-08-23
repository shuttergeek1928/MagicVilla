using AutoMapper;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.Models.VillaNumber;
using MagicVilla.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MagicVilla.Web.Models.Villa;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;

        public VillaNumberController(IMapper mapper, IVillaService villaService, IVillaNumberService villaNumberService)
        {
            _mapper = mapper;
            _villaService = villaService;
            _villaNumberService = villaNumberService;
        }

        public async Task<IActionResult> VillaNumberIndex()
        {
            List<VillaNumberViewModel> villaNumbers = new();

            var response = await _villaNumberService.GetAllAsync<APIResponse>("Villa");

            if(response != null && response.IsSuccess)
            {
                villaNumbers = JsonConvert.DeserializeObject<List<VillaNumberViewModel>>(Convert.ToString(response.Result));
            }

            return View(villaNumbers);
        }

        public async Task<IActionResult> CreateVillaNumber()
        {
            var villaNames = await GetVillaNames();

            return View(villaNames);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber([FromForm] VillaNumberCreateViewModel villaNumberCreateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(villaNumberCreateModel.VillaNumber);

                if (response != null && response.IsSuccess) //if (response != null && response.IsSuccess && response.Errors.Count == 0) - Not the good way of handling the response erros. - Refer BaseService for betther implementation
                {
                    return RedirectToAction("VillaNumberIndex");
                }

                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());
            }

            var villaNames = await GetVillaNames();

            return View(villaNames);
        }

        public async Task<IActionResult> UpdateVillaNumber(int villaNumber)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNumber);

            var villa = new VillaNumberModel();

            if (response != null && response.IsSuccess)
            {
                villa = JsonConvert.DeserializeObject<VillaNumberModel>(Convert.ToString(response.Result));
                
                return View(_mapper.Map<VillaNumberModel>(villa));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(int villaNumber, [FromForm] VillaNumberUpdateModel villaNumberUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<APIResponse>(villaNumber, villaNumberUpdateModel);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("VillaIndex");
                }
            }

            return View(_mapper.Map<VillaNumberViewModel>(villaNumberUpdateModel));
        }

        public async Task<IActionResult> DeleteVillaNumber(int villaNumber)
        {
            var response = await GetVillaNumber(villaNumber, includeChildProperty: "Villa");

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(int villaNumber, bool delete = true)
        {
            if (delete)
            {
                var response = await _villaNumberService.DeleteAsync<APIResponse>(villaNumber);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("VillaIndex");
                }
            }

            var errResponse = await GetVillaNumber(villaNumber, includeChildProperty: "Villa");

            return View(errResponse);
        }

        private async Task<VillaNumberCreateViewModel> GetVillaNames()
        {
            VillaNumberCreateViewModel villaNumberCreateViewModel = new VillaNumberCreateViewModel();

            var response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villaNumberCreateViewModel.VillaList =
                    JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result))
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
            }
            return villaNumberCreateViewModel;
        }

        private async Task<VillaNumberViewModel> GetVillaNumber(int villaNumber, string? includeChildProperty = null)
        {
            VillaNumberViewModel villaNumberViewModel = new VillaNumberViewModel();

            var response = new APIResponse();

            if (includeChildProperty != null)
                response = await _villaNumberService.GetAsync<APIResponse>(villaNumber, includeChildProperty);
            else
                response = await _villaNumberService.GetAsync<APIResponse>(villaNumber);

            if (response != null && response.IsSuccess)
            {
                villaNumberViewModel = JsonConvert.DeserializeObject<VillaNumberViewModel>(Convert.ToString(response.Result));
            }

            return villaNumberViewModel;
        }
    }
}

