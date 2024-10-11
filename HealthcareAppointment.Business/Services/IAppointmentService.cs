using HealthcareAppointment.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto> GetAppointmentByIdAsync(string id);
        Task<AppointmentDto> CreateAppointmentAsync(AppointmentDto appointmentDto);
        Task<AppointmentDto> UpdateAppointmentAsync(string id, AppointmentDto appointmentDto);
        Task DeleteAppointmentAsync(string id);
        Task<AppointmentDto> CancelAppointmentAsync(string id);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsForDoctorAsync(string doctorId, DateTime? startDate, DateTime? endDate, int? status, int pageNumber, int pageSize);
    }
}
