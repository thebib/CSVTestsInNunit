using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit_CSV_Checker.Driver;

namespace NUnit_CSV_Checker
{

    public abstract class SeleniumTestBase
    {
        
        [OneTimeSetUp]
        public void Setup()
        {
            Browser browser = Browser.Chrome;
            DriverManager.Start(browser);
            DriverManager.NavigateToHomePage();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            DriverManager.Driver.Dispose();
        }
    }
}
