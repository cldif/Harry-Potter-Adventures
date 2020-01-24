using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class StudentService
    {

        public IList<StudentDto> GetAllStudent()
        {
            using(StudentRepository _studentRepo = new StudentRepository())
            {
                return _studentRepo.GetAllStudent();
            }
        }

        public StudentDto AddStudent(StudentDto student)
        {
            if(student !=null)
            {
                using (StudentRepository _studentRepo = new StudentRepository())
                {
                    return _studentRepo.AddStudent(student);
                }
            }
           else
            {
                throw new ArgumentNullException(nameof(student), "Student can't be null");
            }
        }


        
    }
}
