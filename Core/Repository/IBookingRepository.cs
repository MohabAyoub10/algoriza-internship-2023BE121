using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IBookingRepository
    {
        IActionResult AddBookAppointment(BookedAppointments appointment);   
        List<BookedAppointmentDTO> GetAllBookedAppointments(string patientId);
    }
}
