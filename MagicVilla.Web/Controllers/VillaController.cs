using AutoMapper;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.Models.Villa;
using MagicVilla.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaService _villaService;

        public VillaController(IMapper mapper, IVillaService villaService)
        {
            _mapper = mapper;
            _villaService = villaService;
        }

        public async Task<IActionResult> VillaIndex()
        {
            List<VillaViewModel> villas = new();

            var response = await _villaService.GetAllAsync<APIResponse>();

            if(response != null && response.IsSuccess)
            {
                villas = JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result));
            }

            return View(villas);
        }

        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla([FromForm] VillaCreateModel villaCreateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(villaCreateModel);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Created Successfully";
                    return RedirectToAction("VillaIndex");
                }

                TempData["error"] = "Error encountered";
                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());
            }

            return View(villaCreateModel);
        }

        public async Task<IActionResult> UpdateVilla(Guid villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);

            var villa = new VillaViewModel();

            if (response != null && response.IsSuccess)
            {
                villa = JsonConvert.DeserializeObject<VillaViewModel>(Convert.ToString(response.Result));
                
                return View(_mapper.Map<VillaViewModel>(villa));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(Guid villaId, [FromForm] VillaUpdateModel villaUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<APIResponse>(villaId, villaUpdateModel);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Updated Successfully";
                    return RedirectToAction("VillaIndex");
                }

                TempData["error"] = "Error encountered";
                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());
            }

            return View(_mapper.Map<VillaViewModel>(villaUpdateModel));
        }

        public async Task<IActionResult> DeleteVilla(Guid villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);

            var villa = new VillaViewModel();

            if (response != null && response.IsSuccess)
            {
                villa = JsonConvert.DeserializeObject<VillaViewModel>(Convert.ToString(response.Result));

                return View(_mapper.Map<VillaViewModel>(villa));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(Guid id, bool delete = true)
        {
            if (delete)
            {
                var response = await _villaService.DeleteAsync<APIResponse>(id);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Deleted Successfully";
                    return RedirectToAction("VillaIndex");
                }

                TempData["error"] = "Error encountered";
                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());
            }

            return View();
        }
    }
}
