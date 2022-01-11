using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class Skills
    {
<<<<<<< HEAD
        public int Id { get; set; }
=======
>>>>>>> ToDoApp
        public ICollection<PersonalSkill> PersonalSkill { get; set; }
        public ICollection<ProfessionalSkill> ProfessionalSkill { get; set; }
    }
}
