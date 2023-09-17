

using AutoMapper;
using HiBlazor.SPA.Entity;
using HiBlazor.SPA.VmModels;

namespace HiBlazor.SPA.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<UserRegisterRequest, User>();   
            CreateMap<Reservation, ReservationVm>();
            CreateMap<ReservationVm, Reservation>();

            // UpdateRequest -> User
            CreateMap<UserUpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}
