using System.Collections.Generic;

namespace EfLearn.Entities
{
    public class Grade :IBaseEntity
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public List<Student> Students{ get; set; }
    }
}
