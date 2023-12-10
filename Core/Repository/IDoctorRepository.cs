using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Core.Repository
{
    public interface IDoctorRepository
    {
        IActionResult AllDoctorsInfoWithAppointment(int Page, int PageSize, Func<DoctorDTO, bool> criteria = null);
        int GetDoctorId(int slotid);
         Doctor GetByID(int id);

    }
}
