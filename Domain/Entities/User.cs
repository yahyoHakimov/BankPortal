using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    namespace BankPortal.Domain.Entities
    {
        public class User
        {
            public int UserID { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
            public string PhoneNumber { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public int RoleID { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

            // Navigation Property
            public virtual Employee Employee { get; set; }
            public virtual ICollection<UserRole> UserRoles { get; set; }
        }
    }

}
