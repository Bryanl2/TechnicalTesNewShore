using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using TechnicalTestNewShore.WebServices.DomainOne;

namespace TechnicalTestNewShore.WebServices.WebClient.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        //The connection between de api and database is done in the Index's action
        public ActionResult Index()
        {

            HttpClient clientOfHttp = new HttpClient();//Allows to create a object utilized to request information to the api
            clientOfHttp.BaseAddress = new Uri("https://localhost:44388/");// The base address where are situated the methods of the api (the direction of the localhost of my machine)

            var request = clientOfHttp.GetAsync("api/Results").Result;//Making the request by a GetAsyn Method (It is concatenaded to the api's base adress )

            if (request.IsSuccessStatusCode) //If connection between client and the API was successfull it returns true
            {
                var resultString = request.Content.ReadAsStringAsync().Result;//The result is converted into string
                var listing = JsonConvert.DeserializeObject<List<Results>>(resultString);//the string returned is written on Json so convert it to c# Object (List<Results>)

                return View(listing);//the information is sent towards the view
            }

            return View(new List<Results>()); //If there is no a successfull request, create a new list (without any information)

        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        //This method add new information in the database (table RESULT)
        [HttpPost]
        public ActionResult New(Results information)
        {
            HttpClient clientOfHttp = new HttpClient();
            clientOfHttp.BaseAddress = new Uri("https://localhost:44388/");

            //Formating Extension is instaled. It allows to work the PostAsyng Override. In Nuget's console:
            ////Install-Package System.Net.Http.Formatting.Extension -Version 5.2.3

            var request = clientOfHttp.PostAsync("api/Results", information, new JsonMediaTypeFormatter()).Result; //Se envía información de tipo Json

            if (request.IsSuccessStatusCode) // If connection between client and the API was successfull it returns true
            {
                var resultString = request.Content.ReadAsStringAsync().Result; //the result is read
                var correct = JsonConvert.DeserializeObject<bool>(resultString); //the api's returning is converted a c# type object

                if (correct)
                {
                    return RedirectToAction("Index");
                }

                return View(information); //If there is any error it returns the same view
            }

            return View(information);
        }

        //This method edit existing information of the database (table RESULT)
        [HttpGet]
        public ActionResult Update(int id)
        {
            HttpClient clientOfHttp = new HttpClient();
            clientOfHttp.BaseAddress = new Uri("https://localhost:44388/");


            var request = clientOfHttp.GetAsync("api/Results" + id).Result; //It gives us the information of a possible client with the id taken like parameter
            if (request.IsSuccessStatusCode) // If the request is successfull
            {
                var resultString = request.Content.ReadAsStringAsync().Result; //the result is read
                var information = JsonConvert.DeserializeObject<List<Results>>(resultString); //the api's returning is converted a c# type object (List<Results>)



                return View(information); //The information is sent to the View 
            }

            return View();
        }

        //This method edit existing information of the database (table RESULT)
        [HttpPost]
        public ActionResult Update(Results information)
        {
            HttpClient clientOfHttp = new HttpClient();
            clientOfHttp.BaseAddress = new Uri("https://localhost:44388/");

            //Formating Extension is instaled. It allows to work the PostAsyng Override. In Nuget's console:
            ////Install-Package System.Net.Http.Formatting.Extension -Version 5.2.3

            var request = clientOfHttp.PutAsync("api/Results", information, new JsonMediaTypeFormatter()).Result; //Se envía información de tipo Json

            if (request.IsSuccessStatusCode) // If the request is successfull
            {
                var resultString = request.Content.ReadAsStringAsync().Result; //the result is read
                var correct = JsonConvert.DeserializeObject<bool>(resultString); //the api's returning is converted a c# type object (bool)

                if (correct)
                {
                    return RedirectToAction("Index");
                }

                return View(information); //If there is any error returns the same View
            }

            return View(information);
        }

        //This method delete information of the database (table RESULT)
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HttpClient clientOfHttp = new HttpClient();
            clientOfHttp.BaseAddress = new Uri("https://localhost:44388/");


            var request = clientOfHttp.DeleteAsync("api/Results?id=" + id).Result; //It deletes the information of a possible client with the id taken like parameter

            if (request.IsSuccessStatusCode) // if the request is successfull
            {
                var resultString = request.Content.ReadAsStringAsync().Result; //The result is read
                var correct = JsonConvert.DeserializeObject<bool>(resultString);

                if (correct)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
