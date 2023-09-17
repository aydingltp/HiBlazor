using AutoMapper;
using HiBlazor.Shared.Entity;
using HiBlazor.Shared.VmModels;

namespace HiBlazor.Server.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<UserRegisterRequest, User>().ForMember(x => x.UserType, options => 
            options.MapFrom(src => src.IsCompany ? UserType.CompanyOwner : UserType.User));

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
