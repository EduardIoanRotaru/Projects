namespace Core.Entities.UserProfile
{
    public class PersonalSkill : BaseEntity
    {
        public int SkillId { get; set; }
        public Skills Skills { get; set; }
    }
}
