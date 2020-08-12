using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TechnicalTestNewShore.WebServices.Data;
using TechnicalTestNewShore.WebServices.Data.Model;

namespace TechnicalTestNewShore.WebServices.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IResults" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IResults
    {
        [OperationContract]
        List<RESULT> GetResults();
    }
}
