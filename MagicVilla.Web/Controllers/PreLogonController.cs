using AutoMapper;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Authentications;
using MagicVilla.Web.Models.Registration;
using MagicVilla.Web.Services.IServices;
using MagicVilla.Web.SessionTokenStore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MagicVilla.Web.Controllers
{
    public class PreLogonController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISessionToken _session;

        public PreLogonController(IAuthService authService, IMapper mapper, IHttpContextAccessor httpContextAccessor, ISessionToken session)
        {
            _mapper = mapper;
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
            _session = session;
        }

        public async Task<IActionResult> Logon()
        {
            LogonRequestModel request = new();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Logon(LogonRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                APIResponse response = await _authService.LoginAsync<APIResponse>(requestModel);

                if (response != null && response.IsSuccess)
                {
                    LogonResponseModel logonResponse = JsonConvert.DeserializeObject<LogonResponseModel>(Convert.ToString(response.Result));

                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Name, logonResponse.User.AccountId.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, logonResponse.User.Role));

                    var principal = new ClaimsPrincipal(identity);
                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    _session.SaveToken(logonResponse.Token);

                    TempData["success"] = "Login Successful";

                    return RedirectToAction("Index", "Home");
                }

                TempData["error"] = "Login Unsuccessful";

                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());

                return View();
            }

            TempData["error"] = "Username or Password incorrect!";

            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                Users newUser = _mapper.Map<Users>(requestModel);

                APIResponse response = await _authService.RegisterAsync<APIResponse>(newUser);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction("Logon");
                }

                TempData["error"] = "Registration Unsuccessful";

                if (response.Errors.Count > 0)
                    ModelState.AddModelError("ErrorMessage", response.Errors.FirstOrDefault());

                return View();
            }

            TempData["error"] = "Please provide correct details!";

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();

            _session.SaveToken("");
            return RedirectToAction("Logon", "PreLogon");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
