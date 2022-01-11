using System;

namespace Core.Entities
{
    public class Job : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
