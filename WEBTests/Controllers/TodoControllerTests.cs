using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

using WEB.Controllers;
using WEB.DAL;
using WEB.ViewModels;

namespace WEB.Controllers.Tests
{
    [TestClass()]
    public class TodoControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            ITaskRepository repo = new ObjectTaskRepository();
            TodoController controller = new TodoController(repo);

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual((result.Model as TodoIndexViewModel).Tasks.Count, repo.GetAll().Count);

            //Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ITaskRepository repo = new ObjectTaskRepository();
            TodoController controller = new TodoController(repo);

            controller.Delete(-1);
            repo.Delete(-1);

            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual((result.Model as TodoIndexViewModel).Tasks.Count, repo.GetAll().Count);

            controller.Delete(2);
            repo.Delete(2);
            result = controller.Index() as ViewResult;
            Assert.AreEqual((result.Model as TodoIndexViewModel).Tasks.Count, repo.GetAll().Count);


        }
    }
}