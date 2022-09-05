using AutoMapper;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Villa;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.SessionTokenStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaService _villaService;
        private readonly string _token;

        public VillaController(IMapper mapper, IVillaService villaService, ISessionToken session)
        {
            _mapper = mapper;
            _villaService = villaService;
            _token = session.ReadToken();
        }

        [Authorize(Roles = "admin, manager, broker")]
        public async Task<IActionResult> VillaIndex()
        {
            List<VillaViewModel> villas = new();

            var response = await _villaService.GetAllAsync<APIResponse>(_token);

            if (response != null && response.IsSuccess)
            {
                villas = JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result));
            }

            return View(villas);
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> CreateVilla([FromForm] VillaCreateModel villaCreateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(villaCreateModel, _token);

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

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> UpdateVilla(Guid villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId, _token);

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
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> UpdateVilla(Guid villaId, [FromForm] VillaUpdateModel villaUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<APIResponse>(villaId, villaUpdateModel, _token);

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

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> DeleteVilla(Guid villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId, _token);

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
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> DeleteVilla(Guid id, bool delete = true)
        {
            if (delete)
            {
                var response = await _villaService.DeleteAsync<APIResponse>(id, _token);

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
