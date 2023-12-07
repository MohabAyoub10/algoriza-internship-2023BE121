using Core.Domain;
using Core.DTO;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public  interface IAppointmentService
    {
        public IActionResult AddDay(int doctorId, AppointmentsDTO day);
        public IActionResult AddDays(int doctorId, List<AppointmentsDTO> appointments);
        public IEnumerable<DoctorScheduleDTO> GetSchedule(int doctorId);

        public IActionResult UpdateDay(int doctorId, UpdateDoctorScheduleDTO day);

        public IActionResult DeleteDay(int doctorId, int dayId);
    }
}
