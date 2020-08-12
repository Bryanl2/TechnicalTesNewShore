using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechnicalTestNewShore.WebServices.Data;
using TechnicalTestNewShore.WebServices.Data.Model;

namespace TechnicalTesNewShore.WebServices.WebApiRest.Controllers
{
    public class ResultsController : ApiController
    {
        ResultsConnection BD = new ResultsConnection();

        /// <summary>
        /// Allows to query the information RESULTS, give names and their condition of Exist or No Exist like New Shore's Clients
        /// The results are based on the archives "CONTENIDO.txt" and "REGISTRADOS.txt" 
        /// </summary>
        /// <returns></returns>

        //Allows to query the information by the GET method, returning a Generic for Colections (especifically returns a list)
        [HttpGet]
        public IEnumerable<RESULT> Get()
        {
            var listing = BD.RESULT.ToList();

            return listing;

        }

        //Allows to query the information by GET method , returning a partircular element
        [HttpGet]
        public RESULT Get(int id)
        {
            var resultPerRow = BD.RESULT.FirstOrDefault(x => x.Id == id);

            return resultPerRow;

        }

        //Allows add new information in the database. Utilize the Post method
        [HttpPost]
        public bool Post(RESULT results)
        {
            BD.RESULT.Add(results);
            var compare = BD.SaveChanges();

            return compare > 0;
        }

        //Allows alter existing information in the database. Utilize the Put method

        [HttpPut]
        public bool Put(RESULT results)
        {
            var updateTable = BD.RESULT.FirstOrDefault(x => x.Id == results.Id);
            updateTable.PossibleClient = results.PossibleClient;
            updateTable.State = results.State;

            var compare = BD.SaveChanges();

            return compare > 0;
        }

        //Allows delete information in the database. Utilize the Delete method

        [HttpDelete]
        public bool Delete(int id)
        {
            var deletePossibleClient = BD.RESULT.FirstOrDefault(x => x.Id == id);
            BD.RESULT.Remove(deletePossibleClient);
            var compare = BD.SaveChanges();

            return compare > 0;

        }
    }
}
