using EfLearn.AbstractEntityRepository;
using EfLearn.Entities;

namespace EfLearn.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        //ORM
        //Object Relational Mapper
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
