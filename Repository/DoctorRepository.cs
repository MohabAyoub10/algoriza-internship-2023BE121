using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using Core.DTO;
using Core.Repository;
using Core.Utilities;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DoctorRepository : IDoctorRepository
    {

        protected readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Doctor GetByID(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }
        public int GetDoctorId(int slotid)
        {
            var doctorId = _context.AppointmentTimes
                .Where(a => a.Id == slotid)
                .Select(a => a.DoctorSchedule.DoctorId)
                .FirstOrDefault();

            return doctorId;
        }

        public IActionResult AllDoctorsInfoWithAppointment(int Page, int PageSize, Func<DoctorDTO, bool>? criteria)
        {
            var ListOfDoctors = _context.Doctors
                               .Join(_context.Users,
                                d => d.UserId,
                                u => u.Id,
                                (d, u) => new { d, u })
                                .Select(x => new
                                {
                                    ImagePath = x.u.Image,
                                    FullName = x.u.FullName,
                                    Email = x.u.Email,
                                    Phone = x.u.PhoneNumber,
                                    Gender = Enum.GetName(x.u.Gender),
                                    Speciality = _context.Specialties.FirstOrDefault(s => s.Id == x.d.SpecialtiesId).NameEN,
                                    Price = x.d.Price,
                                    Appointments = _context.DoctorSchedules
                                                    .Where(a => a.DoctorId == x.d.Id)
                                                    .Select(d => new
                                                    {
                                                        d.Id,
                                                        Day = d.DayOfWeek.ToString(),

                                                        Slots = _context.AppointmentTimes
                                                            .Where(t => t.DoctorScheduleId == d.Id)
                                                            .Select(s => new 
                                                            { 
                                                                SlotID = s.Id,
                                                                time = s.Time.ToString(),

                                                            } 
                                                            
                                                            ).ToList(),
                                                    }).ToList(),
                                });


            // Apply criteria if provided
            /*
             * if (criteria != null)
            {
                ListOfDoctors = ListOfDoctors.Where(criteria);
            }
            */

            // Apply pagination
            var totalCount = ListOfDoctors.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / PageSize);
            ListOfDoctors = ListOfDoctors.Skip((Page - 1) * PageSize).Take(PageSize);

            // Return result
            return new OkObjectResult(new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Data = ListOfDoctors
            });
        }

    }
}
