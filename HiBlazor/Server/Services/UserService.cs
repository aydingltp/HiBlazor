using AutoMapper;
using HiBlazor.Server.Authorization;
using HiBlazor.Server.Helpers;
using HiBlazor.Shared.Entity;
using HiBlazor.Shared.VmModels;
using SimpleHashing.Net;
using System.Text;

namespace HiBlazor.Server.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        ISimpleHash simpleHash = new SimpleHash();
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !simpleHash.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);

           _contextAccessor.HttpContext.Session.SetString("token", response.Token);

            return response;
        }
        public void LogOut()
        {
            _contextAccessor.HttpContext.Session.Remove("token");
        }
        public bool IsLogin()
        {
            var token = _contextAccessor.HttpContext.Session.GetString("token");

            return token is not null;
        }
        public int GetLoggedUserId()
        {
            var token = _contextAccessor.HttpContext.Session.GetString("token");
            return _jwtUtils.ValidateToken(token).Value;
        }
        public bool IsCompany()
        {
            var token = _contextAccessor.HttpContext.Session.GetString("token");
            if (token is null)
                return false;

            var userid = _jwtUtils.ValidateToken(token).Value;
            var user = getUser(userid);
            return user.UserType == UserType.CompanyOwner;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(UserRegisterRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = simpleHash.Compute(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UserUpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                //user.PasswordHash = BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
