using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPractica
{
    public class AmazonSearch
    {
        IWebDriver driver;
        public AmazonSearch(IWebDriver driver) {
            this.driver = driver;
            driver.Url = "https://www.amazon.es/s/ref=s9_acss_bw_h1_CHANGEME_md1_w?node=934197031&pf_rd_m=A1AT7YVPFBWXBL&pf_rd_s=merchandised-search-1&pf_rd_r=1P1WDBFKZCHNZNJ7N95Z&pf_rd_t=101&pf_rd_p=044059da-6ec4-4e36-a7a5-9ac64ec8b02f&pf_rd_i=931491031";
        }

        public List<Telefono> Search(string marca, string modelo)
        {
            List<Telefono> list = new List<Telefono>();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/header/div/div[1]/div[3]/div/form/div[3]/div[1]/input"))).SendKeys(marca + " " + modelo);
            IWebElement searchButton = driver.FindElement(By.XPath("/html/body/div[2]/header/div/div[1]/div[3]/div/form/div[2]/div/input"));
            searchButton.Click();
            IReadOnlyCollection<IWebElement> listElements = driver.FindElements(By.XPath("html/body/div[1]/div[1]/div[1]/div[2]/div/span[4]/div[1]/div"));
            foreach (IWebElement elem in listElements)
            {
                try
                {
                    String precio = elem.FindElement(By.CssSelector(".a-price-whole")).Text;
                    String nombre = elem.FindElement(By.CssSelector("div.sg-col-4-of-12.sg-col-8-of-16.sg-col-16-of-24.sg-col-12-of-20.sg-col-24-of-32.sg-col.sg-col-28-of-36.sg-col-20-of-28 > div > div:nth-child(1) > div > div > div:nth-child(1) > h2 > a > span")).Text;
                    list.Add(new Telefono(nombre, precio));
                }
                catch (Exception e) { }
            }
            return list;
        }
    }
}
