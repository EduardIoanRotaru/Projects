using System;

namespace Core.Entities
{
    public class JobDto : BaseEntityDto
    {
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
