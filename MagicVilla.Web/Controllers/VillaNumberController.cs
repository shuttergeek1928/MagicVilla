﻿using AutoMapper;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Villa;
using MagicVilla.Web.Models.VillaNumber;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.SessionTokenStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicVilla.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly string _token;

        public VillaNumberController(IMapper mapper, IVillaService villaService, IVillaNumberService villaNumberService, ISessionToken session)
        {
            _mapper = mapper;
            _villaService = villaService;
            _villaNumberService = villaNumberService;
            _token = session.ReadToken();
        }

        [Authorize(Roles = "admin, manager, broker")]
        public async Task<IActionResult> VillaNumberIndex()
        {
            List<VillaNumberViewModel> villaNumbers = new();

            var response = await _villaNumberService.GetAllAsync<APIResponse>(_token, "Villa");

            if (response != null && response.IsSuccess)
            {
                villaNumbers = JsonConvert.DeserializeObject<List<VillaNumberViewModel>>(Convert.ToString(response.Result));
            }

            return View(villaNumbers);
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> CreateVillaNumber()
        {
            var villaCreateVM = new VillaNumberCreateViewModel()
            {
                VillaList = (IEnumerable<SelectListItem>)await GetVillaNames()
            };

            return View(villaCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> CreateVillaNumber([FromForm] VillaNumberCreateViewModel villaNumberCreateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(villaNumberCreateModel.VillaNumber, _token);

                if (response != null && response.IsSuccess) //if (response != null && response.IsSuccess && response.Errors.Count == 0) - Not the good way of handling the response erros. - Refer BaseService for betther implementation
                {
                    TempData["success"] = "Villa Number Created Successfully";
                    return RedirectToAction("VillaNumberIndex");
                }

                TempData["error"] = "Error encountered";
                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());
            }

            var villaCreateVM = new VillaNumberCreateViewModel()
            {
                VillaList = (IEnumerable<SelectListItem>)await GetVillaNames()
            };

            return View(villaCreateVM);
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> UpdateVillaNumber(int villaNumber)
        {
            var villaNum = await GetVillaNumber(villaNumber, "Villa");

            var villaList = await GetVillaNames();

            VillaNumberUpdateViewModel villaNumberUpdateViewModel = new VillaNumberUpdateViewModel()
            {
                VillaList = villaList,
                VillaNumber = _mapper.Map<VillaNumberUpdateModel>(villaNum)
            };

            if (villaNumberUpdateViewModel != null)
                return View(villaNumberUpdateViewModel);

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> UpdateVillaNumber(int villaNumber, [FromForm] VillaNumberUpdateViewModel villaNumberUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var villaUpdate = _mapper.Map<VillaNumberUpdateModel>(villaNumberUpdateViewModel);

                var response = await _villaNumberService.UpdateAsync<APIResponse>(villaNumber, villaUpdate, _token);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Number Updated Successfully";
                    return RedirectToAction("VillaNumberIndex");
                }

                TempData["error"] = "Error encountered";
                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());
            }

            return View(villaNumberUpdateViewModel);
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> DeleteVillaNumber(int villaNumber)
        {
            var response = await GetVillaNumber(villaNumber, includeChildProperty: "Villa");

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> DeleteVillaNumber(int villaNumber, bool delete = true)
        {
            if (delete)
            {
                var response = await _villaNumberService.DeleteAsync<APIResponse>(villaNumber, _token);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Number Deleted Successfully";
                    return RedirectToAction("VillaNumberIndex");
                }

                TempData["error"] = "Error encountered";
                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());
            }

            var errResponse = await GetVillaNumber(villaNumber, includeChildProperty: "Villa");

            return View(errResponse);
        }

        private async Task<IEnumerable<SelectListItem>> GetVillaNames()
        {
            var response = await _villaService.GetAllAsync<APIResponse>(_token);

            if (response != null && response.IsSuccess)
            {
                var villaList = JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result))
                                .Select(i => new SelectListItem
                                {
                                    Text = i.Name,
                                    Value = i.Id.ToString()
                                });

                return villaList;
            }

            return null;
        }

        private async Task<VillaNumberViewModel> GetVillaNumber(int villaNumber, string? includeChildProperty = null)
        {
            VillaNumberViewModel villaNumberViewModel = new VillaNumberViewModel();

            var response = new APIResponse();

            if (includeChildProperty != null)
                response = await _villaNumberService.GetAsync<APIResponse>(_token, villaNumber, includeChildProperty);
            else
                response = await _villaNumberService.GetAsync<APIResponse>(_token, villaNumber);

            if (response != null && response.IsSuccess)
            {
                villaNumberViewModel = JsonConvert.DeserializeObject<VillaNumberViewModel>(Convert.ToString(response.Result));
            }

            return villaNumberViewModel;
        }
    }
}

