using Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookedAppointments>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookedAppointments>()
                .HasOne(b => b.Doctor)
                .WithMany(d => d.Appointments)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Specialties>().HasData(
                new Specialties
                {
                    Id = 1,
                    NameAR = "SpecialtyAR1",
                    NameEN = "SpecialtyEN1",
                    DescriptionAR = "DescriptionAR1",
                    DescriptionEN = "DescriptionEN1",
                    NoOfRequests = 10
                },
                new Specialties
                {
                    Id = 2,
                    NameAR = "SpecialtyAR2",
                    NameEN = "SpecialtyEN2",
                    DescriptionAR = "DescriptionAR2",
                    DescriptionEN = "DescriptionEN2",
                    NoOfRequests = 5
                }
                // Add more initial values as needed
            );
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<AppointmentTimes> AppointmentTimes { get; set; }
        public DbSet<BookedAppointments> BookedAppointments { get; set; }
        public DbSet<DoctorAppointmentDetails> DoctorAppointmentDetails { get; set; }
        public DbSet<PromoCodes> PromoCodes { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
    }
}
