using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TechnicalTestNewShoreArchives.Models
{
    public class WriteFile
    {
        //Method that creates a file in specified route with the keys and values from the Dictionary
        public void WriteFileMethod(Dictionary<string,string> result, string route)
        {
            using (FileStream resultFile = File.Create(route))
            {
                foreach (KeyValuePair<string, string> registryCondition in result)
                {
                    Byte[] informationToWrite = new UTF8Encoding(true).GetBytes($"{registryCondition.Key}  ------->  {registryCondition.Value}\n");
                    resultFile.Write(informationToWrite, 0, informationToWrite.Length);
                }
            }

        }
    }
}