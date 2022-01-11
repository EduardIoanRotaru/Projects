using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class Skills
    {
        public int Id { get; set; }
        public ICollection<PersonalSkill> PersonalSkill { get; set; }
        public ICollection<ProfessionalSkill> ProfessionalSkill { get; set; }
    }
}
