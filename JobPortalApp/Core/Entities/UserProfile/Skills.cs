using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class Skills
    {
        public ICollection<PersonalSkill> PersonalSkill { get; set; }
        public ICollection<ProfessionalSkill> ProfessionalSkill { get; set; }
    }
}
