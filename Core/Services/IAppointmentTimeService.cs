using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAppointmentTimeService
    {

        IActionResult AddTimeSlots(int DoctorSheduleId, List<TimeSpan> time);
        IActionResult UpdateTimeSlots(int DoctorSheduleId, List<UpdateScheduleSlotDTO> time);
        IActionResult DeleteTimeSlots(int DoctorSheduleId, List<int> time);
    }
}
