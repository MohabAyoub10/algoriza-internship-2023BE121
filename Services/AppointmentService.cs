using Core.Domain;
using Core.DTO;
using Core.Repository;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppointmentService : IAppointmentService
    {
         protected IUnitOfWork _unitOfWork;
        protected IAppointmentTimeService _appointmentTimeService;

        public AppointmentService(IUnitOfWork unitOfWork, ApplicationDbContext context, IAppointmentTimeService appointmentTimeService)
        {
            _unitOfWork = unitOfWork;
            _appointmentTimeService = appointmentTimeService;
        }



        public TimeSpan GetTimeSpan(string time)
        {
            var timeArray = time.Split(':');
            var hour = int.Parse(timeArray[0]);
            var minute = int.Parse(timeArray[1]);
            var timeSpan = new TimeSpan(hour, minute, 0);
            return timeSpan;
        }
        public IEnumerable<DoctorScheduleDTO> GetSchedule(int doctorId)
        {
            var schedule = _unitOfWork.Appointments.GetAllById(doctorId);

            var scheduleDTO = schedule
                .Select(s => new DoctorScheduleDTO()
                {
                    Id = s.Id,
                    DayOfWeek = s.DayOfWeek,
                    AppointmentStatus = s.AppointmentStatus,
                    times = s.AppointmentTimes.Select(t => new ScheduleSlotDTO()
                    {
                        Id = t.Id,
                        Time = t.Time,
                    }).ToList()

                }).ToList();

            return scheduleDTO;
        }
        public IActionResult AddDay(int doctorId, AppointmentsDTO day)
        {
            var NewSchedule = new DoctorSchedule()
            {
                DoctorId = doctorId,
                DayOfWeek = (Day)day.DayOfWeek,
                AppointmentStatus = day.AppointmentStatus,
            };

            var times = day.times.Select(x => GetTimeSpan(x)).ToList();
            _unitOfWork.Appointments.Add(NewSchedule);
            _unitOfWork.Save();
            _appointmentTimeService.AddTimeSlots(NewSchedule.Id, times);
            _unitOfWork.Save();
            return new OkResult();
        }

        public IActionResult UpdateDay(int doctorId, UpdateDoctorScheduleDTO day)
        {
            var schedule = _unitOfWork.Appointments.GetById(day.Id);
            schedule.AppointmentStatus = day.AppointmentStatus;
            schedule.DayOfWeek = (Day)day.DayOfWeek;
            var times = day.times;
            _unitOfWork.Appointments.Update(schedule);
            _appointmentTimeService.UpdateTimeSlots(schedule.Id, times);
            _unitOfWork.Save();
            return new OkResult();
        }

        public IActionResult DeleteDay(int doctorId, int dayId)
        {
            var schedule = _unitOfWork.Appointments.GetById(dayId);
            _unitOfWork.Appointments.Delete(schedule);
            _unitOfWork.Save();
            return new OkResult();
        }
        public IActionResult AddDays(int doctorId, List<AppointmentsDTO> appointments)
        {
            throw   new Exception();
        }


    }
}
