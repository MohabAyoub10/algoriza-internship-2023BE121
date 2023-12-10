using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.Utilities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.Repository;

namespace Services
{
    public class DoctorService : IDoctorServices
    {

        private readonly IUnitOfWork _unitOfWork;
        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult AllDoctorsInfoWithAppointments(int Page, int PageSize, string? search)
        {
            Func<DoctorDTO, bool> filter = null;
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                filter = (d => d.FullName.ToLower().Contains(search) ||
                d.Phone.ToLower().Contains(search) ||
                d.Speciality.ToLower().Contains(search) ||
                d.Price.ToString().ToLower().Contains(search)
                );
            }

            var ListOfDoctors = _unitOfWork.Doctors.AllDoctorsInfoWithAppointment(Page, PageSize);
            if(ListOfDoctors == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(ListOfDoctors);
        }
    }
}
