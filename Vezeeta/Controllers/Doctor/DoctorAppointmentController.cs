using Core.DTO;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Vezeeta.Controllers.Doctor
{
    [Route("api/schedules")]
    [ApiController]
    public class DoctorAppointmentController : ControllerBase
    {
        internal protected IAppointmentService _appointmentService;
        protected IAppointmentTimeService _appointmentTimeService;
        private readonly ApplicationDbContext _context;

        public DoctorAppointmentController(IAppointmentService appointmentService, ApplicationDbContext context, 
            
            IAppointmentTimeService appointmentTimeService
            ) { 
        _appointmentService = appointmentService;
            _appointmentTimeService = appointmentTimeService;
            _context = context;
        }

        [HttpPost("Add")]
        public IActionResult AddNewSchedule(int doctorId, [FromBody]AppointmentsDTO schedule)
        {
            try
            {
                _appointmentService.AddDay(doctorId, schedule);

            }
            catch(Exception  ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("schedula Created Succesfuly");

        }

        [HttpGet("Get")]
        public IActionResult GetSchedule(int doctorid)
        {
            var allSchedules = _appointmentService.GetSchedule(doctorid);
            return Ok(allSchedules);
        }

        [HttpPut("Update")]
        public IActionResult UpdateSchedule(int doctorId, [FromBody] UpdateDoctorScheduleDTO schedule)
        {
            try
            {
                _appointmentService.UpdateDay(doctorId, schedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("schedula Updated Succesfuly");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteSchedule(int doctorId, int dayId)
        {
            try
            {
                _appointmentService.DeleteDay(doctorId, dayId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("schedula Deleted Succesfuly");
        }
        [HttpDelete("DeleteTimeSlots")]
        public IActionResult DeleteTimeSlots(int DoctorSheduleId, [FromBody] List<int> slots)
        {

            try
            {
                _appointmentTimeService.DeleteTimeSlots(DoctorSheduleId, slots);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Time Slots Deleted Succesfuly");
        }
    }
}
