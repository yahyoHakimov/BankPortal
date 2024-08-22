using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    namespace BankPortal.Domain.Entities
    {
        public class Role
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

            // Navigation Property
            public virtual ICollection<UserRole> UserRoles { get; set; }
        }
    }

}
