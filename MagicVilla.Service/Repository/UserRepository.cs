using AutoMapper;
using MagicVilla.Service.Authorization;
using MagicVilla.Service.Data;
using MagicVilla.Service.Models.Authentications;
using MagicVilla.Service.Models.Registration;
using MagicVilla.Service.Repository.IRepository;

namespace MagicVilla.Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private string _secretKey;
        private readonly IMapper _mapper;
        private readonly IJwtTokenHandler _tokenhandler;
        public UserRepository(ApplicationDbContext context, IJwtTokenHandler tokenhandler, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _tokenhandler = tokenhandler;
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(int accountId)
        {
            var user = _context.Users.FirstOrDefault(x => x.AccountId == accountId);
            
            if(user == null)
                return true;

            return false;
        }

        public LogonResponseModel? Logon(LogonRequestModel logonRequestModel)
        {
            Users user = _context.Users.FirstOrDefault(x => x.UserName.ToLower() == logonRequestModel.UserName.ToLower() && x.Password == logonRequestModel.Password);

            if (user == null)
                return null;

            AuthorizationClient authorizationClient = _tokenhandler.GenerateToken(_secretKey, user);

            if (authorizationClient == null)
                return null;

            LogonResponseModel logonResponseModel = new LogonResponseModel()
            {
               Token = authorizationClient.Token,
               User = user
            };

            return logonResponseModel;
        }

        public Users? Register(RegistrationRequestModel registrationRequestModel)
        {
            var newUserAccountId = 1;

            var lastAccount = _context.Users.OrderByDescending(x => x.AccountId).FirstOrDefault();
            
            if(lastAccount != null)
                newUserAccountId = lastAccount.AccountId + 1;

            if (!IsUniqueUser(newUserAccountId))
                return null;

            Users user = _mapper.Map<Users>(registrationRequestModel);

            user.AccountId = newUserAccountId;

            user.Id = Guid.NewGuid();

            _context.Users.Add(user);

            _context.SaveChanges();

            return user;
        }
    }
}
