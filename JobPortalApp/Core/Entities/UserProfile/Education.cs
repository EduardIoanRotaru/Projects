using System;

namespace Core.Entities.UserProfile
{
    public class Education : BaseEntity
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public string SchoolName { get; set; }

        public _UserProfile UserProfile { get; set; }
    }
}
