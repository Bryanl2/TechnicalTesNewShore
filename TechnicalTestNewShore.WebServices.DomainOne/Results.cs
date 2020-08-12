using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TechnicalTestNewShore.WebServices.DomainOne
{   
    /// <summary>
    /// This is the model that represents the table RESULT. This is going to be utilized by the client for requesting information to the Api Rest
    /// </summary>
    public class Results
    {
        public int Id { get; set; }
        public string PossibleClient { get; set; }
        public string State { get; set; }
    }
}
