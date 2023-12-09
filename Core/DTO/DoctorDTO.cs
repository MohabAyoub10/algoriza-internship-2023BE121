using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class DoctorDTO
    {
        [Required(ErrorMessage = "Speciality is required.")]
        public string Speciality { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 10000)]
        public float Price { get; set; }
    }
}
