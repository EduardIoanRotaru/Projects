using System;
using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class Experience : BaseEntity
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }

        public _UserProfile UserProfile { get; set; }
    }
}
