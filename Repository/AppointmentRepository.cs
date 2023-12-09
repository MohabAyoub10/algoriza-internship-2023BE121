using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Add(DoctorSchedule entity)
        {
            try
            {

                _context.DoctorSchedules.Add(entity);
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        public void AddRange(IEnumerable<DoctorSchedule> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(DoctorSchedule entity)
        {
            _context.DoctorSchedules.Remove(entity);
        }

        public IEnumerable<DoctorSchedule> GetAll()
        {
            return _context.DoctorSchedules.ToList();
        }

        public DoctorSchedule GetById(int id)
        {
            return _context.DoctorSchedules.FirstOrDefault(x => x.Id == id);
        }

        public void Update(DoctorSchedule entity)
        {
            _context.DoctorSchedules.Update(entity);
        }   

        public IEnumerable<DoctorSchedule> GetAllById(int Id)
        {
            return _context.DoctorSchedules.Include(t => t.AppointmentTimes).Where(x => x.DoctorId == Id).ToList();

        }

        public void UpdateRange(IEnumerable<DoctorSchedule> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<DoctorSchedule> entities)
        {
            throw new NotImplementedException();
        }
    }
}
