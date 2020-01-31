using isima.DAL;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Tools
{
    public static class Extensions
    {
        public static Student ToEntity(this StudentDto dto)
        {
            return new Student
            {
                Name = dto.Name,
                Surname = dto.Surname,
                DateOfBirth = dto.DateofBirth,
                Gender = (int)dto.Gender
            };
        }

        public static StudentDto ToDto(this Student entity)
        {
            return new StudentDto
            {
                Name = entity.Name,
                Surname = entity.Surname,
                DateofBirth = entity.DateOfBirth,
                Gender = (Gender)entity.Gender
            };
        }
    }
}
