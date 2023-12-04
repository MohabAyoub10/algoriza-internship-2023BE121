using Core.Utilities;

namespace Core.Domain
{
    public class BookedAppointments
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public ApplicationUser Patient { get; set; }
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime Date { get; set; }
        public int AppointmentTimesId { get; set; }
        public AppointmentTimes AppointmentTimes { get; set; }
        public BookingStatus bookingStatus { get; set; }
        public DateTime CreatedAt  = DateTime.Now;
        public int? PromoCodeId { get; set; }
        public PromoCodes? PromoCode { get; set; }


    }
}
