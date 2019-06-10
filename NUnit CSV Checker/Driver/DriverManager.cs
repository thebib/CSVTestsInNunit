using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;

namespace NUnit_CSV_Checker.Driver
{
    public static class DriverManager
    {
        #region Properties
        public static IWebDriver Driver { get; set; }
        #endregion

        #region Public Methods
        public static void Start(Browser browser)
        {
            switch (browser)
            {
                case Browser.InternetExplorer:
                    Driver = SetupIEWebDriver();
                    break;
                case Browser.Chrome:
                    Driver = SetupChromeDriver();
                    break;
                case Browser.Firefox:
                    Driver = SetupFirefoxDriver();
                    break;
                case Browser.Opera:
                    Driver = SetupOperaDriver();
                    break;
                default:
                    throw new System.Exception("The Browser Specified is not supported");
            }
        }

        
        public static void NavigateToHomePage()
        {
           
        }

        public static void NavigateToInputPage()
        {
        }

        public static void PerformInputAction(string input)
        {

        }

        public static string ReadOutput()
        {
            return "in";
        }
        #endregion

        #region Private Methods
        private static IWebDriver SetupChromeDriver()
        {
            return new ChromeDriver();
        }

        private static IWebDriver SetupIEWebDriver()
        {
            return new InternetExplorerDriver();
        }

        private static IWebDriver SetupFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        private static IWebDriver SetupOperaDriver()
        {
            return new OperaDriver();
        }
        #endregion
    }

    public enum Browser
    {
        InternetExplorer,
        Chrome,
        Firefox,
        Opera
    }
}