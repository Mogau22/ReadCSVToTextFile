using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entities;

namespace Logic
{
    public class CSVLogic:ICSVLogic
    {
        public List<User> ReadCSV(string FullFilePath, char split)
        {
            //using (var stream = new FileStream(FullFilePath, FileMode.Open))
            //{
            try
            {
                var csvContents = File.ReadLines(FullFilePath).Select(f => f.Split(split)).Skip(1);

                var userList = new List<User>();
                foreach (var line in csvContents)
                {
                    var i = line[2].Substring(0, line[2].IndexOf(' '));
                    var s = line[2].Substring(line[2].IndexOf(' ') + 1, (line[2].Length - (line[2].IndexOf(' ') + 1)));
                    var currUser = new User()
                    {
                        FirstName = line[0],
                        LastName = line[1],
                        streetNumber = Convert.ToInt32(line[2].Substring(0, line[2].IndexOf(' '))),
                        streetName = line[2].Substring(line[2].IndexOf(' ') + 1, (line[2].Length - (line[2].IndexOf(' ') + 1))),
                        PhoneNumber = line[3]
                    };
                    userList.Add(currUser);
                }
                return userList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            //}
            
        }

        public int writeNamesTextFile(List<User> users, string outputPath)
        {
            var uu = users.GroupBy(s => s.FirstName).OrderByDescending(ss => ss.Count()).Select(r => r.Key);
            return writeTextFiles(uu,outputPath);
        }

        public int writeAddressesTextFile(List<User> users, string outputPath)
        {
            var u = users.OrderBy(a => a.streetName).Select(s => s.streetNumber + " " + s.streetName);
            return writeTextFiles(u, outputPath);
        }

        public int writeTextFiles(IEnumerable<string> users, string outputPath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (var u in users)
                    {
                        writer.WriteLine(u);
                    }
                }
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }


    }
}
