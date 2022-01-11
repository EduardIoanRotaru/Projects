using System.Collections.Generic;

namespace Core.Entities.UserProfile
{
    public class _UserProfile
    {
        public int Id { get; set; }

<<<<<<< HEAD
        public int ExperienceId { get; set; }
        public ICollection<Experience> Experience { get; set; }
        public int EducationId { get; set; }
        public ICollection<Education> Education { get; set; }
        public int HobbyId { get; set; }
        public ICollection<Hobbies> Hobbies { get; set; }
        public int LanguageId { get; set; }
        public ICollection<Languages> Languages { get; set; }
        public int SkillId { get; set; }
=======
        public ICollection<Experience> Experience { get; set; }
        public ICollection<Education> Education { get; set; }
        public ICollection<Hobbies> Hobbies { get; set; }
        public ICollection<Languages> Languages { get; set; }
>>>>>>> ToDoApp
        public Skills Skills { get; set; }
    }
}
