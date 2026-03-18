using OpsATM.Application.DTOs;
using OpsATM.Application.Interface;
using OpsATM.Application.Interfaces;
using OpsATM.Domain.Entities;
using OpsATM.Infrastructure.Data;
using OpsATM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsATM.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(AppDbContext context,IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> RegisterUser(RegisterUserDto dto)
        {

            var existingUser = _context.Users.FirstOrDefault(x => x.EmpId == dto.EmpId);

            if (existingUser != null)
                return "User Already Exists";
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                EmpId = dto.EmpId,
                Phone = dto.Phone,
                PasswordHash = _passwordHasher.HashPassword(dto.Password) // Implement a proper password hashing mechanism
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "User Created Successfully";
        }

        public async Task<string> Login(LoginDto dto)
        {
            dto.Password = _passwordHasher.HashPassword(dto.Password);
            var user = _context.Users
                .FirstOrDefault(x => x.EmpId == dto.EmpId && x.PasswordHash == dto.Password);

            if (user == null)
                return "Invalid";

            var isValid = _passwordHasher.VerifyPassword(dto.Password, user.PasswordHash);
            if (!isValid)
                return "Invalid";

            return "Success";
        }
    }
}
