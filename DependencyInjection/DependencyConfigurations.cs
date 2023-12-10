using Core.Domain;
using Core.Repository;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

namespace DependencyInjection
{
    public class DependencyConfigurations
    {
        public static IServiceCollection DependenciesConfigurations(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.Password.RequireDigit = true
                ).
                AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAppointmentTimeService, AppointmentTimeService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IDoctorServices, DoctorService>();
            return services;

        }
    }
}
