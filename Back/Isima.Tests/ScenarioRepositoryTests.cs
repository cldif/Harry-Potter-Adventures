using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using isima.DAL;
using Isima.Tests.Utilities;
using System.Collections.Generic;
using System.Linq;
using Isima.DTO;
using Isima.Tests.Utilities;

namespace Isima.Tests
{
    [TestClass]
    public class ScenarioRepositoryTests
    {
        [TestMethod]
        public void GetAllScenario()
        {
            var data = new List<Scenario>
            {
                new Scenario { Chaine = "BBB" },
                new Scenario { Chaine = "ZZZ" },
                new Scenario { Chaine = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Scenario>>();
            mockSet.As<IQueryable<Scenario>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Scenario>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Scenario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Scenario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IsimaEntities>();
            mockContext.Setup(c => c.Scenario).Returns(mockSet.Object);

            var repo = new ScenarioRepository(mockContext.Object);
            var scenarios = repo.GetAllScenario();

            Assert.AreEqual(3, scenarios.Count);
            Assert.AreEqual("AAA", scenarios[0].Chaine);
            Assert.AreEqual("BBB", scenarios[1].Chaine);
            Assert.AreEqual("ZZZ", scenarios[2].Chaine);
        }

        [TestMethod]
        public void AddScenario()
        {
            var data = new List<Scenario>
            {
                new Scenario {Id = 1, Chaine = "test"},
                new Scenario {Id = 2, Chaine = "test"},
                new Scenario {Id = 3, Chaine = "test"},
            };
            var mockSet = Tools.GetQueryableMockDbSet<Scenario>(data);
            var mockContext = new Mock<IsimaEntities>();
            mockContext.Setup(m => m.Scenario).Returns(mockSet.Object);
            var service = new ScenarioRepository(mockContext.Object);
            int initCount = data.Count();
            var result = service.AddScenario(new ScenarioDto { Chaine = "test" });
            int resultCount = data.Count();
            mockSet.Verify(m => m.Add(It.IsAny<Scenario>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(initCount + 1, resultCount);
        }
    }
}
