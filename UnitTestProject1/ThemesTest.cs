using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem.Areas.Administration.Controllers;
using ForumSystem.Services.Contracts;
using System.Web.Services.Description;
using ForumSystem.Data;

namespace Forumsystem.Tests
{
    [TestClass]
    public class ThemeTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new RoleController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);

        }
    }
}
