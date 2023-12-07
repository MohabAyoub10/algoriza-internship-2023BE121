using Core.Domain;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        public IDoctorRepository Doctors { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IBaseRepository<AppointmentTimes> TimeSlots { get; private set; }



        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Appointments = new AppointmentRepository(_context);
            TimeSlots = new BaseRepository<AppointmentTimes>(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
