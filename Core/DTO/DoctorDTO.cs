using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Utilities;
using System.Drawing;

namespace Core.DTO
{
    public class DoctorDTO
    {
        public string FullName;
        public string Email;
        public string Phone;
        public string Gender;
        public string Speciality;
        public float Price;
        public List<AppointmentTimeDTO> Appointments;
        public string ImagePath;
    }
}
