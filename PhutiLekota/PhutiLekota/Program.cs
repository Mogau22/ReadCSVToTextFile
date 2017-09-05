using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using System.Configuration;
using Entities;

namespace PhutiLekota
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string dirPath = Path.Combine(ConfigurationManager.AppSettings["FullFilePath"].ToString());
            string outPutFileNames = Path.Combine(ConfigurationManager.AppSettings["outputFileNames"].ToString());
            string outPutFileAddresses = Path.Combine(ConfigurationManager.AppSettings["outputFileAddresses"].ToString());
            char charSplit = Convert.ToChar(ConfigurationManager.AppSettings["charSplit"]);

            ICSVLogic logic = new CSVLogic();

            var users = logic.ReadCSV(dirPath, charSplit);
            int firstResult = logic.writeNamesTextFile(users, outPutFileNames);
            int secondResult = logic.writeAddressesTextFile(users, outPutFileAddresses);

            Console.WriteLine("First file {0}", firstResult == 1 ? "Created Successfully" : "Failed");
            Console.WriteLine("Second file {0}", secondResult == 1 ? "Created Successfully" : "Failed");
            Console.ReadKey();
        }
    }
}
