using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using isima.DAL;
using Isima.Tests.Utilities;
using System.Collections.Generic;
using System.Linq;
using Isima.DTO;
using Isima.DTO.Enum;
using Isima.Tests.Utilities;

namespace Isima.Tests
{
    [TestClass]
    public class StudentRepositoryTests
    {
        [TestMethod]
        public void GetAllStudent()
        {
            var data = new List<Student>
            {
                new Student { Name = "BBB" },
                new Student { Name = "ZZZ" },
                new Student { Name = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Student>>();
            mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IsimaEntities>();
            mockContext.Setup(c => c.Student).Returns(mockSet.Object);

            var repo = new StudentRepository(mockContext.Object);
            var students = repo.GetAllStudent();

            Assert.AreEqual(3, students.Count);
            Assert.AreEqual("AAA", students[0].Name);
            Assert.AreEqual("BBB", students[1].Name);
            Assert.AreEqual("ZZZ", students[2].Name);
        }

        [TestMethod]
        public void AddStudent()
        {
            var data = new List<Student>
            {
                new Student { ID =1,Name = "test",Surname = "test",Gender = (int)Gender.Male },
                new Student {ID =2  ,Name = "test",Surname = "test",Gender = (int)Gender.Male },
                new Student {ID =3,Name = "test",Surname = "test",Gender = (int)Gender.Female },
            };
            var mockSet = Tools.GetQueryableMockDbSet<Student>(data);
            var mockContext = new Mock<IsimaEntities>();
            mockContext.Setup(m => m.Student).Returns(mockSet.Object);
            var service = new StudentRepository(mockContext.Object);
            int initCount = data.Count();
            var result = service.AddStudent(new StudentDto { Name = "test", Surname = "test", Gender = Gender.Male });
            int resultCount = data.Count();
            mockSet.Verify(m => m.Add(It.IsAny<Student>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(initCount + 1, resultCount);
        }
    }
}
