using AutoMapper;
using HiBlazor.Server.Authorization;
using HiBlazor.Server.Helpers;
using HiBlazor.Shared.Entity;
using HiBlazor.Shared.VmModels;
using Microsoft.EntityFrameworkCore;
using SimpleHashing.Net;

namespace HiBlazor.Server.Services
{
    public class ReservationService : IReservationService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ReservationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(ReservationVm model)
        {
            // map model to new user object
            var reservation = _mapper.Map<Reservation>(model);

            _context.Reservation.Add(reservation);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var reservation = getReservation(id);
            _context.Reservation.Remove(reservation);
            _context.SaveChanges();
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservation.ToList();
        }

        public Reservation GetById(int id)
        {
            return getReservation(id);
        }

        public void Update(int id, ReservationVm model)
        {
            var reservation = getReservation(id);

            _mapper.Map(model, reservation);
            _context.Reservation.Update(reservation);
            _context.SaveChanges();
        }
        private Reservation getReservation(int id)
        {
            var reservation = _context.Reservation.Find(id);
            if (reservation == null) throw new KeyNotFoundException("User not found");
            return reservation;
        }
    }
}
