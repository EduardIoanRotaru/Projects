using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class SkillsDto
    {
        public ICollection<PersonalSkillDto> PersonalSkill { get; set; }
        public ICollection<ProfessionalSkillDto> ProfessionalSkill { get; set; }
    }
}
