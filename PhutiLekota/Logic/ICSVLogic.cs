using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic
{
    public interface ICSVLogic
    {
        List<User> ReadCSV(string FullFilePath, char split);
        int writeAddressesTextFile(List<User> users, string outputPath);
        int writeNamesTextFile(List<User> users, string outputPath);
    }
}
