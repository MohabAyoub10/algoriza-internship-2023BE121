using Core.Utilities;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Domain
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Day DayOfWeek { get; set; }
        public ActivationStatus AppointmentStatus { get; set; }
        public List<AppointmentTimes>? AppointmentTimes { get; set; }
    }
}
