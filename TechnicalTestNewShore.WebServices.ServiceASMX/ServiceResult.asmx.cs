using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TechnicalTestNewShore.WebServices.Data;
using TechnicalTestNewShore.WebServices.Data.Model;

namespace TechnicalTestNewShore.WebServices.ServiceASMX
{
    /// <summary>
    /// Allows request information from a database
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceResult : System.Web.Services.WebService
    {
        ResultsConnection BD = new ResultsConnection();//This is the connection to the database. This is the Data that used entity framework
        
        //Service Get result that shows the information of the table RESULT.
        [WebMethod]
        public List<RESULT> GetResult()
        {
            var listing = BD.RESULT.ToList();
            return listing;
        }
    }
}
