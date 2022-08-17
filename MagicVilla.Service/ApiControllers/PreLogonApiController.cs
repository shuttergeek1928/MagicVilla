using AutoMapper;
using MagicVilla.Service.Models;
using MagicVilla.Service.Models.Authentications;
using MagicVilla.Service.Models.Registration;
using MagicVilla.Service.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla.Service.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreLogonApiController : Controller
    {
        private readonly IUserRepository _userContext;
        private readonly IMapper _mapper;
        protected readonly APIResponse _response;

        public PreLogonApiController(IUserRepository userContext, IMapper mapper)
        {
            _userContext = userContext;
            _mapper = mapper;
            _response = new();
        }

        [HttpPost("logon")]
        public ActionResult<APIResponse> Logon([FromBody] LogonRequestModel logonRequestModel)
        {
            if (logonRequestModel == null || !ModelState.IsValid)
                return BadRequest(_response);

            var response = _userContext.Logon(logonRequestModel);

            if (response == null)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { "Can not login at the moment" };
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;

            _response.Result = response;

            return Ok(_response);
        }

        [HttpPost("register")]
        public ActionResult<APIResponse> RegisterNewUser([FromBody] RegistrationRequestModel registrationRequestModel)
        {
            if (registrationRequestModel == null || !ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { "Data not sufficient to create a new user" };
                return BadRequest(_response);
            }

            var user = _userContext.Register(registrationRequestModel);

            if (user == null)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { "User not created" };
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.Created;

            _response.Result = user;

            return Ok(_response);
        }
    }
}
