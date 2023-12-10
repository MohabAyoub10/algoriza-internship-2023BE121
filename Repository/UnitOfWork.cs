using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Identity;
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
        public IBookingRepository Booking { get; private set; }

        public IApplicationUserRepository ApplicationUsers { get; private set; }

        public IPromoCodesRepository PromoCodes { get; private set; }




        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

            Appointments = new AppointmentRepository(_context);
            TimeSlots = new BaseRepository<AppointmentTimes>(_context);
            ApplicationUsers = new ApplicationUserRepository(_context, _userManager,_roleManager);
            Doctors = new DoctorRepository(_context);
            Booking = new BookingRepository(_context);
            PromoCodes = new PromoCodesRepository(_context);
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
