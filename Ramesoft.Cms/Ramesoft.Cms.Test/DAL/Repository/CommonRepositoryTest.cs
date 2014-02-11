using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ramesoft.Cms.Common.DAL.Implementation;
using Ramesoft.Cms.Common.DAL.Implementation.Fakes;
using Ramesoft.Cms.Common.Entity.Fakes;
using System;
using System.Data.Entity.Fakes;

namespace Ramesoft.Cms.Test.DAL.Repository
{
    [TestClass]
    public class CommonRepositoryTest
    {
        private static IDisposable shimContext;
        private StubIEntityContext db;
        private CommonRepositories cr;

        [ClassInitialize]
        public static void ClassSetup(TestContext test)
        {
            shimContext = ShimsContext.Create();
        }

        [TestInitialize]
        public void TestSetup()
        {
            db = new StubIEntityContext();
            var database = new ShimDatabase();
            database.ExecuteSqlCommandStringObjectArray = (a, b) =>
                {
                    return 0;
                };
            db.DatabaseGet = () =>
                {
                    return database;
                };

            cr = new CommonRepositories(db);
        }

        [TestCleanup]
        public void CleanTest()
        {
            cr.Dispose();
        }

        [ClassCleanup]
        public static void CleanClass()
        {
            shimContext.Dispose();
        }

        [TestMethod]
        public void EcTest()
        {
            Assert.AreEqual(0, cr.ExecuteCommand("cmd"));
        }
    }
}
