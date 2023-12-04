using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Doctor
    {
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int SpecialtiesId { get; set; }
        public Specialties Specialties { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [DefaultValue(0.0)]
        public float Price { get; set; }

        public int NoOfRequests { get; set; }
        [Range(0, 5)]
        public int rating { get; set; }


    }
}
