using Microsoft.AspNetCore.Mvc;
using MagicVilla.Web.Models;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.Models.Villa;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IVillaService villaService)
        {

            _villaService = villaService;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaViewModel> villas = new();

            var response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villas = JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result));
            }

            return View(villas);
        }
    }
}