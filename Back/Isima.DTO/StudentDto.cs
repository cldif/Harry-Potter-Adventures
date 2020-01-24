using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        /// <summary>
        /// Gender is a enum
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Nullable DoB
        /// </summary>
        public DateTime? DateofBirth { get; set; }
    }
}
