using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using Core.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Vezeeta.Controllers.Patient
{
    [Route("api/appointment")]
    [ApiController]
    public class PatientAppointmentController : ControllerBase
    {

        private readonly IDoctorServices _doctorServices;
        private readonly IBookingService _bookingService;

        public PatientAppointmentController(IDoctorServices doctorServices, IBookingService bookingService)
        {
            _doctorServices = doctorServices;
            _bookingService = bookingService;
        }

        [HttpGet("Doctors")]
        public IActionResult AllDoctorsInfoWithAppointments(int Page, int PageSize, string? search)
        {
            return _doctorServices.AllDoctorsInfoWithAppointments(Page, PageSize, search);
        }


        [HttpPost("Book")]
        public IActionResult BookAppointment(int slotId,  string date, string? promocode)
        {
            var patientId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            try
            {
                return _bookingService.BookAppointment(slotId, patientId, date, promocode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BookedAppointments")]
        public IActionResult GetAllBookedAppointments()
        {
            var patientId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            try
            {
                return _bookingService.GetAllBookedAppointments(patientId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
