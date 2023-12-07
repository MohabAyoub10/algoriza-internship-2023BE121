using Core.Domain;
using Core.DTO;
using Core.Repository;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppointmentTimeService : IAppointmentTimeService
    {
        internal protected  IUnitOfWork _unitOfWork;

        public AppointmentTimeService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public IActionResult AddTimeSlots(int DoctorSheduleId, List<TimeSpan> time)
        {
            var NewTimeSlots = time.Select(x => new AppointmentTimes()
            {
                DoctorScheduleId = DoctorSheduleId,
                Time = x,

            }).ToList();
             _unitOfWork.TimeSlots.AddRange(NewTimeSlots);
            _unitOfWork.Save();
            return new OkResult();
        }

        public IActionResult UpdateTimeSlots(int DoctorSheduleId, List<UpdateScheduleSlotDTO> time)
        {
            var NewTimeSlots = time.Select(x => new AppointmentTimes()
            {
                DoctorScheduleId = DoctorSheduleId,
                Id = x.Id,
                Time = TimeSpan.Parse(x.Time),


            }).ToList();
            _unitOfWork.TimeSlots.UpdateRange(NewTimeSlots);
            _unitOfWork.Save();
            return new OkResult();
        }

        public IActionResult DeleteTimeSlots(int DoctorSheduleId, List<int> time)
        {
            var NewTimeSlots = time.Select(x => new AppointmentTimes()
            {
                DoctorScheduleId = DoctorSheduleId,
                Id = x,
            }).ToList();
            _unitOfWork.TimeSlots.DeleteRange(NewTimeSlots);
            _unitOfWork.Save();
            return new OkResult();
        }
    }
}
