using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ramesoft.Cms.Common.Config;
using Ramesoft.Cms.Common.DAL.Implementation;
using Ramesoft.Cms.Common.DAL.Repository;
using Ramesoft.Cms.Common.Entity;
using Ramesoft.Cms.Common.Services.Contract;
using Ramesoft.Cms.Controllers;
using System;
using System.Collections;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace Ramesoft.Cms.Test.Controllers
{
    [Binding]
    public class HomeControllerTestSteps : IDisposable
    {
        Queue stack = new Queue();
        bool disposed;
        HomeController home = new HomeController(
            UnityConfig.Resolve<IUnitOfWork>(),
            UnityConfig.Resolve<IProductService>(),
            UnityConfig.Resolve<CommonRepositories>());
        
        [When(@"I call Index of Home")]
        public void WhenICallIndexOfHome()
        {
            var res = home.Index() as ViewResult;
            stack.Enqueue(res.ViewName);
            stack.Enqueue(res.Model);
        }

        [When(@"I call Logs of Home")]
        public void WhenICallLogsOfHome()
        {
            var res = home.Logs() as ViewResult;
            stack.Enqueue(res.ViewName);
            stack.Enqueue(res.Model);
        }

        [Then(@"It Should return ""(.*)"" View")]
        public void ThenItShouldReturnView(string p0)
        {
            Assert.AreEqual(p0, stack.Dequeue());
        }

        [Then(@"Its Model type should be ""(.*)""")]
        public void ThenItsModelTypeShouldBe(string p0)
        {
            Assert.IsInstanceOfType(stack.Dequeue(), Type.GetType(p0));
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            this.home.Dispose();
            this.stack.Clear();
            this.disposed = true;
        }
    }
}
