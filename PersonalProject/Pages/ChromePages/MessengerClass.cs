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
    public class MessengerClass
    {
        //Links and login
        public static String MessengerLink = "http://messenger.com";

        //Friend search box
        private IWebElement SearchNameBox => ChromeDriverClass.Driver.FindElement(By.XPath("//input[@aria-label='Search Messenger']"));
        private int SearchElementCount(String name) => ChromeDriverClass.Driver.FindElements(By.XPath("//span[contains(text(),'" + name + "')]")).Count;
        private IWebElement SearchElement(String name) => ChromeDriverClass.Driver.FindElements(By.XPath("//span[contains(text(),'" + name + "')]"))[1];

        //New Message search box
        private IWebElement NewMessageButton => ChromeDriverClass.Driver.FindElement(By.XPath("//a[@aria-label='New Message']"));
        private IWebElement NewSearchNameBox => ChromeDriverClass.Driver.FindElement(By.XPath("//input[@aria-label='Search by name or group']"));
        private int UnorderedList => ChromeDriverClass.Driver.FindElements(By.XPath("//ul")).Count;

        //Message Box
        private IWebElement MessageBox => ChromeDriverClass.Driver.FindElement(By.XPath("//*[starts-with(@class,'notranslate _5rpu')]"));

        public MessengerClass(String email, String password)
        {
            MessengerLogin Login = new MessengerLogin();
            Login.Login(email, password);
        }

        //Sends the message to the box
        public void SendMessage(String text)
        {
            ChromeDriverClass.Wait.Until(d => MessageBox.Displayed);
            MessageBox.Clear();
            MessageBox.SendKeys(text + Keys.Enter);
            Thread.Sleep(3000);
        }

        //Searches for the name and gets a count of the total matches - Can be used for just search too
        public int SearchForNameCount(String name)
        {
            ChromeDriverClass.Wait.Until(d => SearchNameBox.Displayed);
            SearchNameBox.Clear();
            SearchNameBox.SendKeys(name);
            //Thread.Sleep(4000);
            ChromeDriverClass.Wait.Until(d => UnorderedList >= 1);
            return SearchElementCount(name);
        }

        //Searches for the name for a new person and gets a count of the total matches - Can be used for just search too
        public int SearchForNewNameCount(String name)
        {
            ChromeDriverClass.Wait.Until(d => NewMessageButton.Enabled);
            NewMessageButton.Click();

            ChromeDriverClass.Wait.Until(d => NewSearchNameBox.Enabled);
            NewSearchNameBox.Clear();
            NewSearchNameBox.SendKeys(name);
            ChromeDriverClass.Wait.Until(d => UnorderedList>=1);
            return SearchElementCount(name);
        }

        /// <summary>
        /// Send friend a message
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendFriendMessage(String name, String message)
        {
            try
            {
                ChromeDriverClass.Wait.Until(d => SearchForNameCount(name)>=1);
                SearchElement(name).Click();
                SendMessage(message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Send a message to someone random
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendMessage(String name, String message)
        {
            try
            {
                ChromeDriverClass.Wait.Until(d => SearchNameBox.Displayed);
                ChromeDriverClass.Wait.Until(d => SearchForNameCount(name) >= 1);
                SearchElement(name).Click();
                for (int index = 0; index < 20; index++)
                    SendMessage(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }



    }
}
