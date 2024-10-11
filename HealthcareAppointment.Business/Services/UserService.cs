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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllPatientsAsync()
        {
            var patients = await _userRepository.GetPatientsAsync();
            return _mapper.Map<IEnumerable<UserDto>>(patients);
        }

        public async Task<IEnumerable<UserDto>> GetAllDoctorsAsync()
        {
            var doctors = await _userRepository.GetDoctorsAsync();
            return _mapper.Map<IEnumerable<UserDto>>(doctors);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid().ToString();
            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(string id, UserDto userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found");

            _mapper.Map(userDto, existingUser);
            await _userRepository.UpdateAsync(existingUser);
            return _mapper.Map<UserDto>(existingUser);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            await _userRepository.RemoveAsync(user);
        }
    }
}
