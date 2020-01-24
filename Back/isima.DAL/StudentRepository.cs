using Isima.DAL;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class StudentRepository : IDisposable
    {

        private readonly IsimaEntities _dbcontext = null;

        public StudentRepository() 
            {
            _dbcontext = new IsimaEntities();
            }

        public StudentRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }



        public List<StudentDto> GetAllStudent()
        {
            try
            {
                //Get all student data line from database 
                List<Student> studentEntities = _dbcontext.Student.ToList();
                //transform to DTO, and send to upper layer
                return studentEntities.Select(x => new StudentDto
                {
                    Id = x.ID,
                    Name = x.Name,
                    Surname = x.Surname,
                    Gender = (Gender)x.Gender,
                    DateofBirth = x.DateOfBirth
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public StudentDto AddStudent(StudentDto student)
        {
            Student newStudent = student.ToEntity();
            var studentCreated = _dbcontext.Student.Add(newStudent);
            _dbcontext.SaveChanges();
            return studentCreated.ToDto();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
