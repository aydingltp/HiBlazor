using AutoMapper;
using HiBlazor.Server.Authorization;
using HiBlazor.Server.Helpers;
using HiBlazor.Server.Services;
using HiBlazor.Shared.VmModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HiBlazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationService _reservationService;
        private IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create(ReservationVm model)
        {
            //_reservationService.Create(model);
            return Ok(new { message = "Reservation successful" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reservation = _reservationService.GetById(id);
            return Ok(reservation);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ReservationVm model)
        {
            _reservationService.Update(id, model);
            return Ok(new { message = "Reservation updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reservationService.Delete(id);
            return Ok(new { message = "Reservation deleted successfully" });
        }
    }
}
