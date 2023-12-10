using Core.Domain;
using Core.DTO;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult AddBookAppointment(BookedAppointments appointment)
        {

            try
            {
                _context.BookedAppointments.Add(appointment);
                return new OkObjectResult(appointment);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }


        public List<BookedAppointmentDTO> GetAllBookedAppointments(string patientId)
        {
            try
            {
                var appointments = _context.BookedAppointments
                    .Include(patientId => patientId.Patient)
                    .Include(doctorId => doctorId.Doctor)
                    .Include(slotId => slotId.AppointmentTime)
                    .Include(promoCodeId => promoCodeId.PromoCode)
                    .Where(b => b.PatientId == patientId).ToList();

                List<BookedAppointmentDTO> bookedAppointments = new List<BookedAppointmentDTO>();
                
                foreach (var appointment in appointments)
                {
                    var doctor = _context.Doctors.FirstOrDefault(d => d.Id == appointment.DoctorId);
                    var patient = _context.Users.FirstOrDefault(p => p.Id == appointment.PatientId);
                    var slot = _context.AppointmentTimes.FirstOrDefault(s => s.Id == appointment.AppointmentTimeId);
                    var promoCode = _context.PromoCodes.FirstOrDefault(p => p.Id == appointment.PromoCodeId);
                    var bookedAppointment = new BookedAppointmentDTO
                    {
                        doctorName =_context.Users.FirstOrDefault(u => u.Id == doctor.UserId).FullName,
                        speciality = _context.Specialties.FirstOrDefault(s => s.Id == doctor.SpecialtiesId).NameEN,

                        day =  _context.DoctorSchedules.FirstOrDefault(d => d.DoctorId == doctor.Id).DayOfWeek.ToString(),
                        date = appointment.AppointmentDate.ToString("dd/MM/yyyy"),
                        time = slot.Time.ToString(),
                        price = doctor.Price.ToString(),
                        promocode = promoCode.CodeName,
                        status = appointment.AppointmentStatus.ToString()
                    };
                    bookedAppointments.Add(bookedAppointment);
                }
                    
                return bookedAppointments;
            }
            catch (Exception e)
            {
               return null;
            }
        }


    }
}
