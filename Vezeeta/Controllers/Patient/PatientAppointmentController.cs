using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using Core.Services;    
namespace Vezeeta.Controllers.Patient
{
    [Route("api/appointment")]
    [ApiController]
    public class PatientAppointmentController : ControllerBase
    {

        private readonly IDoctorServices _doctorServices;

        public PatientAppointmentController(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        [HttpGet("Doctors")]
        public IActionResult AllDoctorsInfoWithAppointments(int Page, int PageSize, string? search)
        {
           
            return _doctorServices.AllDoctorsInfoWithAppointments(Page, PageSize, search);
        }

    }
}
