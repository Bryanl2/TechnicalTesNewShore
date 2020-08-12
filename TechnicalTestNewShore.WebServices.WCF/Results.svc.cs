using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TechnicalTestNewShore.WebServices.Data.Model;

namespace TechnicalTestNewShore.WebServices.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Results" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Results.svc o Results.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Results : IResults
    {
        ResultsConnection BD = new ResultsConnection();
        public List<RESULT> GetResults()
        {
            return BD.RESULT.ToList();
        }
    }
}
