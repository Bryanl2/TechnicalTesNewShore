using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TechnicalTestNewShore.WebServices.Data;
using TechnicalTestNewShore.WebServices.Data.Model;

namespace TechnicalTestNewShore.WebServices.ServiceWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ResultService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ResultService.svc o ResultService.svc.cs en el Explorador de soluciones e inicie la depuración.

    //ResultService must implement the interface IResultService 
    public class ResultService : IResultService
    {
        ResultsConnection BD = new ResultsConnection(); //Connection to the Database
        public List<RESULT> GetResults()
        {
            return BD.RESULT.ToList(); //This is returning the table RESULT.
            
        }
    }
}
