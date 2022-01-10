using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class _UserProfile
    {
        public int Id { get; set; }

        public ICollection<Experience> Experience { get; set; }
        public ICollection<Education> Education { get; set; }
        public ICollection<Hobbies> Hobbies { get; set; }
        public ICollection<Languages> Languages { get; set; }
        public Skills Skills { get; set; }
    }
}
