﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class AppointmentTimes
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public int DoctorScheduleId { get; set; }
        public DoctorSchedule DoctorSchedule { get; set; }
    }
}
