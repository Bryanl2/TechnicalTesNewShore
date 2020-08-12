using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TechnicalTestNewShoreArchives.Models;

namespace TechnicalTestNewShoreArchives.Models
{
    public class ReadFile
    {
        //Two lists are created for saving the information from the archives uploaded
        //One Dictionary is created for saving two elements: word and condition. Later is going to be used for writing on a new file.
        
        List<string> ListContent = new List<string>();
        List<string> ListRegistered = new List<string>();
        Dictionary<string, string> DictionaryResults = new Dictionary<string, string>();

        //Helpers
        public string ConfirmationRead { get; set; }
        public Exception ErrorRead { get; set; }

        public bool exc { get; set; }

        //Is created a object from the class WriteFile to invoke the method and perform the writing of the results
        WriteFile Object=new WriteFile();

        //Method created for reading the files uploaded. Receive like parameters the files's routes
        public void ReadFileMethod(string routeOne, string routeTwo, string routeThree)
        {
           
            try
            {
                //StremReader is used to read the routes of the files.
                //Elements from routeOne are saved in ListContent (the letters which are going to form the names of the possible clients)
                //Elements from routeTwo are saved in ListRegisted(the names of the possible clients from New Shore)

                using (StreamReader readContent = File.OpenText(routeOne))
                {
                    string letters = "";
                    while ((letters = readContent.ReadLine()) != null)
                    {
                        ListContent.Add(letters);
                    }
                }
                using (StreamReader readRegistered = File.OpenText(routeTwo))
                {
                    string letters = "";
                    while ((letters = readRegistered.ReadLine()) != null)
                    {
                        ListRegistered.Add(letters);
                    }
                }


                //The loops needed to perfom the analysis
                //On the loop "for" it is going to iterate the names of the possibles clients
                //On the first "while" it is going to iterate the letters that forms the names.
                //On the second "while" it is goint to iterate the letters from copiedListContent and compare them with the letter from the names

                for (var i = 0; i < ListRegistered.Count; i++)
                {
                    //Each letter can be read only one time per iteration (test's rule)
                    //copiedListContent is created to remove a letter that match the name of the possible client
                    //On each iteration the copiedListContent restored the initial values from the ListContent

                    var copiedListContent = (ListContent as IEnumerable<string>).ToList();
                    string wordToAnalyze = ListRegistered.ElementAt(i);
                    bool interruptor = true; //It is used to finish the iteration if a letter from the name and the copiedListContent match
                    int indexCopiedListContent = 0;
                    string condition = "";//It tells if the possible client exist or no
                    int counter = 0;

                    //the variable registry is used for determining the condition of the possible client
                    //If the client exists the registry's value is going to be equal to the number of letter from the word analyzed
                    int registry = 0;

                    while (counter < wordToAnalyze.Length)
                    {
                        while (interruptor == true && indexCopiedListContent < copiedListContent.Count)
                        {
                            if (wordToAnalyze.Substring(counter, 1) == copiedListContent[indexCopiedListContent])
                            {
                                copiedListContent.RemoveAt(indexCopiedListContent);
                                interruptor = false;
                                registry++;
                            }
                            indexCopiedListContent++;
                        }

                        //If the registry's value and the length of wordAnalyze match it means the possible client exists
                        if (registry == wordToAnalyze.Length)
                        {
                            condition = "Exist";
                            DictionaryResults.Add(wordToAnalyze, condition);
                        }
                        counter++;
                        interruptor = true;
                        indexCopiedListContent = 0;
                    }
                    if (registry != wordToAnalyze.Length)
                    {
                        condition = "No Exist";
                        DictionaryResults.Add(wordToAnalyze, condition);
                    }
                }

                Object.WriteFileMethod(DictionaryResults, routeThree);

                this.ConfirmationRead = "The comparation between the archives were perfomed.\n The result archive was done successfully";
                
            }
            catch (Exception ex)
            {
                this.ErrorRead= ex;
            }
        }
    }
}
