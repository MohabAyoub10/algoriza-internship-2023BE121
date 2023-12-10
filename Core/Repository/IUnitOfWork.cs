using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IBaseRepository<AppointmentTimes> TimeSlots { get; }
        IDoctorRepository Doctors { get; }
        IApplicationUserRepository ApplicationUsers { get; }
        IBookingRepository Booking { get; }
        IPromoCodesRepository PromoCodes { get; }

        void Save();
    }
}
