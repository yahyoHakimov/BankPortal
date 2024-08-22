using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Department
{
    public class CreateDepartmentDto
    {
        public string DepartmentName { get; set; }
        public int ManagerID { get; set; }
    }
}
