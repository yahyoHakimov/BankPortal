﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Announcement
{
    public class CreateAnnouncementDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorID { get; set; }
    }
}
