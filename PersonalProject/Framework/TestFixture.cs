using PersonalProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonalProject.Framework
{
    public class TestFixture
    {
        public static string ProjectBasePath
        {
            get
            {
                var path = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Replace(@"file:\", "");

                var directoryInfo = new DirectoryInfo(path);
                return directoryInfo.FullName;
            }
        }


        [OneTimeSetUp, Retry(2)]
        public void CreateChromeDriver()
        {
            ChromeDriverClass.Driver = ChromeDriverClass.CreateDriver(MessengerClass.MessengerLink);
        }

        [SetUp]
        public void Setup()
        {

        }


        [TearDown]
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void CleanUp() 
        {
            ChromeDriverClass.EndDriver();
            ChromeDriverClass.RunCommandPrompt(@"taskkill /f /im chrome.exe & taskkill /f /im chromedriver.exe");

        }
    }
}
