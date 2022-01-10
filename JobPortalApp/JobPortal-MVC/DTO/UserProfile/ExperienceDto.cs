﻿using System;

namespace Core.Entities.UserProfile
{
    public class ExperienceDto : BaseEntityDto
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }

        public _UserProfileDto UserProfile { get; set; }
    }
}
