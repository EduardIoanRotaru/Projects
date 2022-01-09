using System;

namespace Core.Entities
{
    public class AppliedJobs
    {
        public int Id { get; set; }
        public DateTime DateApplied { get; set; }
        public Job JobApplied { get; set; }
    }
}
