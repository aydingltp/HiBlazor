using AutoMapper;
using HiBlazor.Server.Authorization;
using HiBlazor.Server.Helpers;
using HiBlazor.Server.Services;
using HiBlazor.Shared.Entity;
using HiBlazor.Shared.VmModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SimpleHashing.Net;
using System.Text;

namespace HiBlazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationService _reservationService;
        private IUserService _userService;
        private IMapper _mapper;
        ISimpleHash simpleHash = new SimpleHash();
        private IJwtUtils _jwtUtils;
        private readonly IHttpContextAccessor _contextAccessor;
        public ReservationController(IReservationService reservationService, IMapper mapper, IJwtUtils jwtUtils, IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create(ReservationVm model)
        {
            var userToken = _contextAccessor.HttpContext.Session.GetString("token");
            var userId = _jwtUtils.ValidateToken(userToken).Value;
           
            _reservationService.Create(model, userId);
            return Ok(new { message = "Reservation successful" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }

        [HttpGet("getallwithid")]
        public IActionResult GetAllWithId()
        {
            var userId = _userService.GetLoggedUserId();
            var reservations = _reservationService.GetAllWithId(userId);
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
