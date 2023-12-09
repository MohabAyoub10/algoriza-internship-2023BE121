using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Domain
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public UserType UserType { get; set; }

        public string? Address { get; set; }
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National Id must be 14 digits.")]

        public string? NationalId { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string? Image { get; set; }
    }
}
