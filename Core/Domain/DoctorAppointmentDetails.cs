using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    internal class DoctorAppointmentDetails
    {
        public int Id { get; set; }
        public DoctorSchedule DoctorSchedule { get; set; }
        public int DoctorScheduleId { get; set; }
        public int TotalNumberOfAppointments { get; set; }
        public DateTime Date { get; set; }
    }
}
