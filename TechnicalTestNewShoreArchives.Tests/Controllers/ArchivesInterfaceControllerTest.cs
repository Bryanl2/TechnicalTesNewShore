using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalTestNewShoreArchives.Controllers;
using TechnicalTestNewShoreArchives.Models;
using System.Collections.Generic;
using System.Linq;


namespace TechnicalTestNewShoreArchives.Tests.Controllers
{
    [TestClass]
    public class ArchivesInterfaceControllerTest
    {
        [TestMethod]
        public void ReadFiles_NullContent_ReturnNull()
        {
            // Arrange
            ArchivesInterfaceController ArchivesController = new ArchivesInterfaceController();
            string routeOne = "~/Temp/CONTENIDO.txt";
            string routeTwo = "~/Temp/REGISTRADOS.txt";
            string routeThree = "~/Temp/RESULTADOS.txt";
            ReadFile element = new ReadFile();

            //Act
            ViewResult result = ArchivesController.ReadFile(element) as ViewResult;
            

        }
    }
}
