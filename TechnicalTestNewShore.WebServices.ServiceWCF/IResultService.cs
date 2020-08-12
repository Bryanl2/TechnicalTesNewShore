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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IResultService" en el código y en el archivo de configuración a la vez.
    
    //This is the interface that must be implementaded for obtaining the information from the database
    [ServiceContract]
    public interface IResultService
    {
            //Here is indicated the operation to implement in the service.
            [OperationContract]
            List<RESULT> GetResults();
        
    }
}
