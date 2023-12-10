using Core.Domain;
using Core.Repository;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult BookAppointment(int slotId, string patientId, string date, string promocode = null)
        {
            try
            {
                var DoctorId = _unitOfWork.Doctors.GetDoctorId(slotId);
                var doctor = _unitOfWork.Doctors.GetByID(DoctorId);
                var slot = _unitOfWork.TimeSlots.GetById(slotId);
                var patient = _unitOfWork.ApplicationUsers.GetByUser(patientId);

                int? PromoCodeId = null;
                if(promocode != null)
                {
                     PromoCodeId = _unitOfWork.PromoCodes.GetPromoCodeId(promocode);
                }
               
                DateTime dateTime = DateTime.Parse(date);
                var appointment = new BookedAppointments
                {
                    Patient = patient,
                    PatientId  = patient.Id,

                    Doctor = doctor,
                    DoctorId = doctor.Id,
                    AppointmentTimeId = slot.Id,
                    AppointmentTime = slot,
                    PromoCodeId = PromoCodeId,
                    CreatedAt = DateTime.Now,
                    AppointmentDate = dateTime,
                    AppointmentStatus = BookingStatus.Pending
                };
                _unitOfWork.Booking.AddBookAppointment(appointment);
                _unitOfWork.Save();
                return new OkObjectResult(new { message = "Appointment booked successfully" , appointment});
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
        

        public IActionResult GetAllBookedAppointments(string patientId)
        {
            try
            {
                var appointments = _unitOfWork.Booking.GetAllBookedAppointments(patientId);

                

                return new OkObjectResult(appointments);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
