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
    public class MapRepositoryTests
    {
        [TestMethod]
        public void GetAllMap()
        {
            var data = new List<Map>
            {
                new Map { Configuration = "BBB" },
                new Map { Configuration = "ZZZ" },
                new Map { Configuration = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Map>>();
            mockSet.As<IQueryable<Map>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Map>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Map>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Map>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IsimaEntities>();
            mockContext.Setup(c => c.Map).Returns(mockSet.Object);

            var repo = new MapRepository(mockContext.Object);
            var Maps = repo.GetAllMap();

            Assert.AreEqual(3, Maps.Count);
            Assert.AreEqual("AAA", Maps[0].Configuration);
            Assert.AreEqual("BBB", Maps[1].Configuration);
            Assert.AreEqual("ZZZ", Maps[2].Configuration);
        }

        [TestMethod]
        public void AddMap()
        {
            var data = new List<Map>
            {
                new Map { ID =1,Configuration = "test"},
                new Map {ID =2  ,Configuration = "test"},
                new Map {ID =3,Configuration = "test" },
            };
            var mockSet = Tools.GetQueryableMockDbSet<Map>(data);
            var mockContext = new Mock<IsimaEntities>();
            mockContext.Setup(m => m.Map).Returns(mockSet.Object);
            var service = new MapRepository(mockContext.Object);
            int initCount = data.Count();
            var result = service.AddMap(new MapDto { Configuration = "test"});
            int resultCount = data.Count();
            mockSet.Verify(m => m.Add(It.IsAny<Map>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(initCount + 1, resultCount);
        }
    }
}
