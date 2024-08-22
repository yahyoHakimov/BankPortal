using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class RequestDto
    {
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
    }
}
