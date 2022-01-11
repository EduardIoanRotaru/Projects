namespace Core.Entities.UserProfile
{
    public class ProfessionalSkill : BaseEntity
    {
        public int SkillId { get; set; }
        public Skills Skills { get; set; }
    }
}
