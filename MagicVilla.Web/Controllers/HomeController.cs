using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Villa;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.SessionTokenStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly ILogger<HomeController> _logger;
        private readonly string _token;

        public HomeController(IVillaService villaService, ISessionToken session)
        {
            _villaService = villaService;
            _token = session.ReadToken();
        }

        [Authorize(Roles = "admin, manager, broker")]
        public async Task<IActionResult> Index()
        {
            List<VillaViewModel> villas = new();

            var response = await _villaService.GetAllAsync<APIResponse>(_token);

            if (response != null && response.IsSuccess)
            {
                villas = JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result));
            }

            return View(villas);
        }
    }
}