using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit_CSV_Checker.Driver;
using Shouldly;

namespace NUnit_CSV_Checker
{
    class CSVSeleniumTest : SeleniumTestBase
    {
        private static readonly string csvPath = "C:\\Users\\pinea\\Documents\\file.csv";
        private static Dictionary<string, string> LoadTestData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string[] lines = File.ReadAllLines(csvPath);
            foreach (string line in lines)
            {
                string[] splitdata = line.Split(',');
                string input = splitdata[0];
                string output = splitdata[1];

                data.Add(input, output);
            }
            return data;
        }
        /// <summary>
        /// Uses LoadTestData Dictionary to populate test data and creates a NUnitTestCase for each one
        /// </summary>
        /// <param name="data"></param>
        [TestCaseSource(nameof(LoadTestData))]
        public void RunCSVTest(KeyValuePair<string, string> data)
        {
            //Arrange 
            DriverManager.NavigateToInputPage();

            //Act
            DriverManager.PerformInputAction(data.Key);
            var actualoutput = DriverManager.ReadOutput();

            //Assert
            actualoutput.ShouldBe(data.Value);
        }

    }
}
