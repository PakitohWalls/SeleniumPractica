using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumPractica
{
    public class AmazonSearch
    {
        IWebDriver driver;
        public AmazonSearch(IWebDriver driver) {
            //driver.Manage().Window.Maximize();
            driver.Url = "https://www.amazon.es/Moviles-Telefonia/b?ie=UTF8&node=931491031";
            
        }

        public void search(String marca, String modelo)
        {
            //left_nav browseBox > ul > li > text
            IReadOnlyCollection<IWebElement> listElements = driver.FindElements(By.XPath("//*[@id=\"a - page\"]/div[3]/div/div[2]/div/div[1]/div[1]/ul[1]"));
            foreach (IWebElement elem in listElements)
            {
                Console.WriteLine(elem.ToString());
            }
        }
    }
}
