using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class _UserProfileDto
    {
        public int Id { get; set; }

        public ICollection<ExperienceDto> Experience { get; set; }
        public ICollection<EducationDto> Education { get; set; }
        public ICollection<HobbiesDto> Hobbies { get; set; }
        public ICollection<LanguagesDto> Languages { get; set; }
        public SkillsDto Skills { get; set; }
    }
}
