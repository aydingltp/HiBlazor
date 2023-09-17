using HiBlazor.Shared.Entity;
using HiBlazor.Shared.VmModels;

namespace HiBlazor.Server.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll();
        IEnumerable<Reservation> GetAllWithId(int userId);
        Reservation GetById(int id);
        void Create(ReservationVm model, int userId);
        void Update(int id, ReservationVm model);
        void Delete(int id);
    }
}
