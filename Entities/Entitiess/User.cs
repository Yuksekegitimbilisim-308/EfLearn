namespace EfLearn.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
