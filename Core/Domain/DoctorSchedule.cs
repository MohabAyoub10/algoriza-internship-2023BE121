using Core.Utilities;

namespace Core.Domain
{
    internal class DoctorSchedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Day DayOfWeek { get; set; }
        public ActivationStatus AppointmentStatus { get; set; }
        public List<AppointmentTimes> AppointmentTimes { get; set; }
    }
}
