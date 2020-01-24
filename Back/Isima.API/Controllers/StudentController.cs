using Isima.API.Models;
using Isima.Business;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Isima.API.Controllers
{
    /// <summary>
    /// Student Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class StudentController : ApiController
    {
        private readonly StudentService _studentService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        public StudentController()
        {
            _studentService = new StudentService();
        }


        /// <summary>
        /// Get list of all students 
        /// </summary>
        /// <remarks>
        /// Get list of all students from the database no filtered
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> List of student</response>
        [ResponseType(typeof(IEnumerable<StudentViewModel>))]
        public IHttpActionResult Get()
        {
            IList<StudentDto> students = _studentService.GetAllStudent();
            IEnumerable<StudentViewModel> studentList = students.Select(st => new StudentViewModel
            {
                Id = st.Id,
                DoB = st.DateofBirth ?? DateTime.MinValue,
                Name = st.Name,
                Surname = st.Surname,
                Gender = st.Gender
            });

            return Ok(studentList);

        }

        //public IHttpActionResult Get(int id)
        //{
        //   if(id <= 0)
        //    {
        //        return BadRequest("Student Id is required");
        //    }
        //   var student = _studentService.Gets
        //}

        /// <summary>
        /// Posts the specified student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <response code="200"> Created</response>
        /// <response code="400"> parameter issue</response>
        /// <response code="500">Other issues, see message included</response>
        public IHttpActionResult Post([FromBody]StudentViewModel student)
        {
            if(student == null)
            {
                return BadRequest("Student Id is required");
            }

            try
            {
                _studentService.AddStudent(new StudentDto
                {
                    DateofBirth = student.DoB, 
                    Gender = student.Gender,
                    Name = student.Name, 
                    Surname = student.Surname
                });

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        //// PUT: api/Student/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Student/5
        //public void Delete(int id)
        //{
        //}
    }
}
