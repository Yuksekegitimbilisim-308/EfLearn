using EfLearn.Entities;
using EfLearn.Models;
using System.Collections.Generic;

namespace EfLearn.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<StudentWithGrade> GetStudentsWithGrade();
        List<StudentWithGrade> GetStudentsWithGradeWhereLikeFullname(string fullname);
    }
}
