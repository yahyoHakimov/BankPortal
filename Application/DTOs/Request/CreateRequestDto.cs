﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class CreateRequestDto
    {
        public int EmployeeID { get; set; }
        public string RequestType { get; set; }
        public string Comments { get; set; }
    }
}
