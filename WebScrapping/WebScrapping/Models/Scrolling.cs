using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebScrapping.Models
{
    public class Scrolling
    {
        public static string Scroll(string url)
        {

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"D:\GitHub_Projects\ASP.Net-Core-MVC\WebScrapping\WebScrapping\bin\Debug\netcoreapp2.1";
            ChromeDriver chromeDriver = new ChromeDriver(directory, chromeOptions);
            chromeDriver.Navigate().GoToUrl(url);

            long scrollHeight = 0;
            do
            {
                IJavaScriptExecutor js = chromeDriver;
                var newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");

                if (newScrollHeight == scrollHeight)
                {

                    break;
                }
                else
                {
                    scrollHeight = newScrollHeight;
                    Thread.Sleep(3000);
                }
            } while (true);

            string returnVaule = chromeDriver.PageSource;
            chromeDriver.Close();

            return returnVaule;
        }
    }
}
