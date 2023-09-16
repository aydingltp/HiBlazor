using HiBlazor.Shared.Entity;
using HiBlazor.Shared.VmModels;

namespace HiBlazor.Server.Services
{
    public interface IReservationService
    {
        List<Reservation> GetAll();
        Reservation GetById(int id);
        void Create(ReservationVm model, int userId);
        void Update(int id, ReservationVm model);
        void Delete(int id);
    }
}
