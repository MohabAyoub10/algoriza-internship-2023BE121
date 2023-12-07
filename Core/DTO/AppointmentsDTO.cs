using Core.Utilities;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AppointmentsDTO
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public List<string> times { get; set; }
        public ActivationStatus AppointmentStatus { get; set; }
    }

    
}
