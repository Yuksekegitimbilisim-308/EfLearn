using EfLearn.Entities;
using EfLearn.Models;
using System.Collections.Generic;
using System.Linq;

namespace EfLearn.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        AppDbContext _context;
        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<StudentWithGrade> GetStudentsWithGrade()
        {
            var query = _context.Students.Include("Grade").Select(student => new StudentWithGrade
            {
                Id = student.Id,
                LessonName = student.Grade.LessonName,
                StudentName = student.Fullname,
                IsActive = student.IsActive,
                PhoneNumber=student.PhoneNumber
            }).ToList();
            return query;
        }

        public List<StudentWithGrade> GetStudentsWithGradeWhereLikeFullname(string fullname)
        {
            var query = _context.Students.Include("Grade").Where(x => x.Fullname.Contains(fullname)).Select(x => new StudentWithGrade
            {
                Id=x.Id,
                LessonName=x.Grade.LessonName,
                StudentName=x.Fullname,
                IsActive = x.IsActive,
                PhoneNumber = x.PhoneNumber
            }).ToList();
            return query;
        }
    }
}
