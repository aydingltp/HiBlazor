using HiBlazor.Shared.Entity;
using HiBlazor.Shared.VmModels;

namespace HiBlazor.Server.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        List<User> GetAll();
        User GetById(int id);
        void Register(UserRegisterRequest model);
        void Update(int id, UserUpdateRequest model);
        void Delete(int id);
    }
}
