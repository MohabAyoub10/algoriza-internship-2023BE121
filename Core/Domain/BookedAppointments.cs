using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities;
namespace Core.Domain
{
    public class BookedAppointments
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentTimeId { get; set; }
        public BookingStatus AppointmentStatus { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedAt =  DateTime.Now;

        public int? PromoCodeId { get; set; }
        public ApplicationUser? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public AppointmentTimes? AppointmentTime { get; set; }
        public PromoCodes? PromoCode { get; set; }



    }
}
