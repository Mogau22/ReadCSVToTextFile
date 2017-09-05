using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Entities;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            ICSVLogic logic = new CSVLogic();
            var expectedResults = new List<User>();
            string inputFile = @"c\temp\data.csv";
            char inputCharSplit = ',';
            var users = logic.ReadCSV(inputFile, inputCharSplit);

            Assert.AreEqual(expectedResults, users);
        }
    }
}
