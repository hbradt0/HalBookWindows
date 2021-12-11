using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PersonalProject.Framework;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Drawing.Imaging;
using OpenQA.Selenium.Interactions;

namespace PersonalProject.Pages
{
    public static class ChromeDriverClass
    {
        public static IWebDriver Driver;
        public static WebDriverWait Wait;
        public static readonly TimeSpan DefaultImplicitWait = TimeSpan.FromSeconds(12);
        public static readonly TimeSpan DefaultPageLoadTimeout = TimeSpan.FromSeconds(12);

        public static IWebDriver CreateDriver(String link)
        {
            ChromeOptions chromeOpts = new ChromeOptions();
            chromeOpts.AddArgument("--disable-infobars");
            chromeOpts.AddArgument("start-maximized");
            chromeOpts.AddArguments("--disable-gpu");

            //chromeOpts.AddArgument("--headless");

            var driver = new ChromeDriver(Framework.TestFixture.ProjectBasePath+@"\Resources");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(80);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(80);
            driver.Manage().Window.Position = new Point(1922, 0);
            driver.Manage().Window.Maximize();
            driver.Url = link;

            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            return driver;
        }

        public static IWebDriver CreateLanguageDriver(String link, String language = "zh")
        {
            ChromeOptions chromeOpts = new ChromeOptions();
            //chromeOpts.AddArgument("--disable-infobars");
            chromeOpts.AddArgument("--lang=" + language);

            var driver = new ChromeDriver(Framework.TestFixture.ProjectBasePath + @"\Resources\chromedriver.exe", chromeOpts);
            driver.Manage().Timeouts().PageLoad = DefaultPageLoadTimeout;
            driver.Manage().Timeouts().ImplicitWait = DefaultImplicitWait;
            driver.Manage().Window.Position = new Point(1922, 0);
            driver.Manage().Window.Maximize();
            driver.Url = link;

            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            return driver;
        }

        public static void EndDriver()
        {
            Driver.Dispose();
        }
        
        public static void SwitchToWindow(this IWebDriver driver, int windowIndex)
        {
               driver.SwitchTo().Window(driver.WindowHandles[windowIndex]);         
        }

        public static void RunCommandPrompt(String cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
           // startInfo.Verb = "runas";
            startInfo.Arguments = "/C " + cmd;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

    }   
}
