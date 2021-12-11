using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PersonalProject.Pages
{
    public class Calculator
    {
        //Links and login
        private IWebElement PlayButton => ChromeDriverClass.Driver.FindElement(By.XPath("//button[@aria-label='Play']"));
        private IWebElement Pri => ChromeDriverClass.Driver.FindElement(By.XPath("//paper-button[text()='No thanks']"));

        public static String YoutubeURL = "https://www.youtube.com/watch?v=PLksKWlUgzk+Check+my+video%21%21%21";

        public void ClickPlayButton()
        {
                ChromeDriverClass.Wait.Until(d => PlayButton.Enabled);
                PlayButton.Click();

        }
        /// <summary>
        /// Login to the messenger page
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void View(int times, String URL = "")
        {
            for(int ti = 0; ti < times; ti++)
            {
                ChromeDriverClass.Driver = ChromeDriverClass.CreateDriver(URL);

                ClickPlayButton();
                Thread.Sleep(2 * 1000);
            }
            Thread.Sleep(30 * 1000);
        }

    }
}
