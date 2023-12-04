
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    internal class Specialties
    {
        public int Id { get; set; }
        [Required]
        public string NameAR { get; set; }
        [Required]
        public string NameEN { get; set; }
        public string? DescriptionAR { get; set; }
        public string? DescriptionEN { get; set; }
        [DefaultValue(0)]
        public int NoOfRequests { get; set; }


    }
}
