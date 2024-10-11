using HealthcareAppointment.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HealthcareAppointmentContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(string doctorId, DateTime? startDate, DateTime? endDate, int? status, int pageNumber, int pageSize)
        {
            var query = _context.Appointments.Where(a => a.DoctorId == doctorId);

            if (startDate.HasValue)
                query = query.Where(a => a.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(a => a.Date <= endDate.Value);

            if (status.HasValue)
                query = query.Where(a => a.Status == status.Value);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
