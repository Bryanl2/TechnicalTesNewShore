using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnicalTestNewShoreArchives.Models;

namespace TechnicalTestNewShoreArchives.Controllers
{
    public class ArchivesInterfaceController : Controller
    {
        // GET: ArchivesInterface
        public ActionResult Index()
        {
            return View();
        }

        //Action GET View UploadFiles
        [HttpGet]
        public ActionResult UploadFiles()
        {
            
            return View();
        }

        //Action POST vista UploadFiles
        //Receive the files uploaded
        //The carpet Temp was created in the project
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase fileOne, HttpPostedFileBase fileTwo)
        {
            UploadFile model = new UploadFile(); // It created a object from the class UploadFile that allows apply its method

            if (fileOne != null && fileTwo != null) //If they aren't null create variables with the routes and add their name
            {
                string routeOne = Server.MapPath("~/Temp/");
                string routeTwo = Server.MapPath("~/Temp/");
                routeOne += fileOne.FileName;
                routeTwo += fileTwo.FileName;
                model.UploadFileMethod(routeOne, routeTwo, fileOne, fileTwo);
                ViewBag.ErrorUpload = model.ErrorUpload;            //Helper
                ViewBag.CorrectUpload = model.ConfirmationUpload;   
            }
            return View();
        }

        //Action GET View ReadFile
        [HttpGet]
        public ActionResult ReadFile()
        {
            return View();
        }

        //Action POST View ReadFile
        //Receive a object of ReadFile's Class that allows apply its method
        [HttpPost]
        public ActionResult ReadFile(ReadFile model)
        {
            //Create the routes which save the names of the files to read at that location.
            string routeOne = Server.MapPath("~/Temp/CONTENIDO.txt");
            string routeTwo = Server.MapPath("~/Temp/REGISTRADOS.txt");
            string roteThree = Server.MapPath("~/Temp/RESULTADOS.txt");

            model.ReadFileMethod(routeOne, routeTwo, roteThree);
            return RedirectToAction("UploadFiles");
        }

        //Action GET View ResultFile
        //take the file from the route specified and download it with the name "RESULTS"
        [HttpGet]
        public ActionResult ResultFile()
        {
            string route = Server.MapPath("~/Temp/RESULTADOS.txt");
            return File(route, "application/txt", "RESULTS.txt");

        }
    }
}