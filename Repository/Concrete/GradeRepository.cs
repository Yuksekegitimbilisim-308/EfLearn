using EfLearn.AbstractEntityRepository;
using EfLearn.Entities;

namespace EfLearn.Repository
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {

        public GradeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
