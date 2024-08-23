using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email); // Retrieve the user by email
        void AddUser(User user); // Adding a user to the database
        void SaveChanges(); // Save changes to the context
    }
}
