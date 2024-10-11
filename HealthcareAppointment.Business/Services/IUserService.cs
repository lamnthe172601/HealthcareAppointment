using HealthcareAppointment.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllPatientsAsync();
        Task<IEnumerable<UserDto>> GetAllDoctorsAsync();
        Task<UserDto> GetUserByIdAsync(string id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> UpdateUserAsync(string id, UserDto userDto);
        Task DeleteUserAsync(string id);
    }
}
