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
    public class Stocks
    {
	    public static String GoogleLink = "http://google.com";
        public static String FileName = @"C:\Stocks\Stocks.txt";
        public static String DirectoryName = @"C:\Stocks";

        //Links and login
        private IWebElement GoogleSearchBar => ChromeDriverClass.Driver.FindElement(By.XPath("//input[@aria-label='Search']"));
        private IWebElement StockPrice => ChromeDriverClass.Driver.FindElement(By.Id("knowledge-finance-wholepage__entity-summary"));

        public void GetStock(String stock)
        {
            ChromeDriverClass.Driver.Url = GoogleLink;
            ChromeDriverClass.Wait.Until(d => GoogleSearchBar.Displayed);

            ChromeDriverClass.Wait.Until(d => GoogleSearchBar.Enabled);
            GoogleSearchBar.Clear();
            GoogleSearchBar.SendKeys(stock + Keys.Enter);

            ChromeDriverClass.Wait.Until(d => StockPrice.Displayed);
            String text = stock + " - " + DateTime.Now.ToString() + "\n" + StockPrice.Text + "\n\n";
            WriteToFile(text, FileName);
        }

        public void GetListOfStocks(String [] stocks)
        {
            foreach(String stock in stocks)
            {
                String temporarySearch = stock;
                if(!temporarySearch.Contains(" stock"))
                {
                    temporarySearch = temporarySearch + " stock";
                }
                GetStock(temporarySearch);
            }
        }

        public void WriteToFile(String text, String file)
	    {
            file = file + DateTime.Now.ToString("MMddyyyy");
            if (!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
            }
            if (File.Exists(file))
            {
                File.AppendAllText(file, text);
            }
            else
            {
                File.WriteAllText(file, text);
            }
	    }


    }
}
