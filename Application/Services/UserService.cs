using Application.Interfaces;
using BCrypt.Net;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository; // Assuming you have a user repository in the Infrastructure Layer

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User ValidateUser(string email, string password)
        {
            // Password hashing and validation logic (assuming hashed password)
            var user = _userRepository.GetUserByEmail(email);
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
