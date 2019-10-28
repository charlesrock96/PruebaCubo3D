using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matriz3D;
using Matriz3D.Controllers;

namespace Matriz3D.Tests.Controllers
{
    [TestClass]
    public class PrincipalControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PrincipalController controller = new PrincipalController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
       
    }
}
