using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDoctorServices
    {
        IActionResult AllDoctorsInfoWithAppointments(int Page, int PageSize, string? search);

    }
}
