namespace EfLearn.Entities
{
    public class Student : IBaseEntity
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
