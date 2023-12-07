using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities;

namespace Core.DTO
{
    public class DoctorScheduleDTO
    {
        public int Id { get; set; }
        public Day DayOfWeek { get; set; }
        public List<ScheduleSlotDTO> times { get; set; }
        public ActivationStatus AppointmentStatus { get; set; }
    }
    public class UpdateDoctorScheduleDTO
    {
        public int Id { get; set; }
        public Day DayOfWeek { get; set; }
        public List<UpdateScheduleSlotDTO> times { get; set; }
        public ActivationStatus AppointmentStatus { get; set; }
    }
    public class ScheduleSlotDTO
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
    }
    public class UpdateScheduleSlotDTO
    {
        public int Id { get; set; }
        public string Time { get; set; }
    }
}
