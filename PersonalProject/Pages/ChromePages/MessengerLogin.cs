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
    public class MessengerLogin
    {
        //Links and login
        private IWebElement LoginButton => ChromeDriverClass.Driver.FindElement(By.Id("loginbutton"));
        private IWebElement EmailBox => ChromeDriverClass.Driver.FindElement(By.Id("email"));
        private IWebElement PasswordBox => ChromeDriverClass.Driver.FindElement(By.Id("pass"));

        /// <summary>
        /// Login to the messenger page
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void Login(String email, String password)
        {
            ChromeDriverClass.Wait.Until(d => LoginButton.Displayed);

            ChromeDriverClass.Wait.Until(d => EmailBox.Enabled);
            EmailBox.Clear();
            EmailBox.SendKeys(email);

            ChromeDriverClass.Wait.Until(d => PasswordBox.Enabled);
            PasswordBox.Clear();
            PasswordBox.SendKeys(password);

            ChromeDriverClass.Wait.Until(d => LoginButton.Enabled);
            LoginButton.Click();
        }

    }
}
