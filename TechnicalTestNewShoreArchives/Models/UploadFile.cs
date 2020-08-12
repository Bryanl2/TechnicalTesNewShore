using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTestNewShoreArchives.Models
{
    public class UploadFile
    {
        public string ConfirmationUpload { get; set; }
        public Exception ErrorUpload { get; set; }

        //Method that uploads the files toward the route specified in the parameters.
        public void UploadFileMethod(String routeOne, String routeTwo, HttpPostedFileBase fileOne, HttpPostedFileBase fileTwo)
        {
            try
            {
                fileOne.SaveAs(routeOne);
                fileTwo.SaveAs(routeTwo);
                this.ConfirmationUpload = "Files saved successfuly"; //Helper
            }
            catch (Exception ex)
            {
                this.ErrorUpload = ex;
            }
        }
    }
}