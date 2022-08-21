﻿using AutoMapper;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.Models.VillaNumber;
using MagicVilla.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaNumberService _villaNumberService;

        public VillaNumberController(IMapper mapper, IVillaNumberService villaNumberService)
        {
            _mapper = mapper;
            _villaNumberService = villaNumberService;
        }

        public async Task<IActionResult> VillaNumberIndex()
        {
            List<VillaNumberViewModel> villaNumbers = new();

            var response = await _villaNumberService.GetAllAsync<APIResponse>();

            if(response != null && response.IsSuccess)
            {
                villaNumbers = JsonConvert.DeserializeObject<List<VillaNumberViewModel>>(Convert.ToString(response.Result));
            }

            return View(villaNumbers);
        }

        public async Task<IActionResult> CreateVillaNumber()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber([FromForm] VillaNumberCreateModel villaNumberCreateModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(villaNumberCreateModel);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("VillaIndex");
                }
            }

            return View(villaNumberCreateModel);
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
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNumber);

            var villa = new VillaNumberViewModel();

            if (response != null && response.IsSuccess)
            {
                villa = JsonConvert.DeserializeObject<VillaNumberViewModel>(Convert.ToString(response.Result));

                return View(_mapper.Map<VillaNumberViewModel>(villa));
            }

            return NotFound();
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

            return View();
        }
    }
}
