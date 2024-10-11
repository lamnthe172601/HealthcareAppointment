using HealthcareAppointment.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HealthcareAppointmentContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetDoctorsAsync()
        {
            return await _context.Users.Where(u => u.Role == 1).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetPatientsAsync()
        {
            return await _context.Users.Where(u => u.Role == 0).ToListAsync();
        }
    }
}
