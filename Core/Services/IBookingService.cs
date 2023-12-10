using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBookingService
    {
        IActionResult BookAppointment(int slotId, string promocode, string patientId, string date);
        IActionResult GetAllBookedAppointments(string patientId);
    }
}
