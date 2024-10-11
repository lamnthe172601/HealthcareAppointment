using AutoMapper;
using HealthcareAppointment.Business.DTOs;
using HealthcareAppointment.Data.Repositories;
using HealthcareAppointment.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(string id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            appointment.Id = Guid.NewGuid().ToString();
            await _appointmentRepository.AddAsync(appointment);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<AppointmentDto> UpdateAppointmentAsync(string id, AppointmentDto appointmentDto)
        {
            var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
            if (existingAppointment == null)
                throw new KeyNotFoundException("Appointment not found");

            _mapper.Map(appointmentDto, existingAppointment);
            await _appointmentRepository.UpdateAsync(existingAppointment);
            return _mapper.Map<AppointmentDto>(existingAppointment);
        }

        public async Task DeleteAppointmentAsync(string id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");

            await _appointmentRepository.RemoveAsync(appointment);
        }

        public async Task<AppointmentDto> CancelAppointmentAsync(string id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");

            appointment.Status = 2; // Cancelled
            await _appointmentRepository.UpdateAsync(appointment);
            return _mapper.Map<AppointmentDto>(appointment);
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsForDoctorAsync(string doctorId, DateTime? startDate, DateTime? endDate, int? status, int pageNumber, int pageSize)
        {
            var appointments = await _appointmentRepository.GetAppointmentsForDoctorAsync(doctorId, startDate, endDate, status, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }
    }
}
