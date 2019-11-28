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
    class FnacSearch
    {
        IWebDriver driver;
        public FnacSearch(IWebDriver driver)
        {
            this.driver = driver;
            driver.Url = "https://www.fnac.es/";
        }

        public List<Telefono> Search(string marca, string modelo)
        {
            List<Telefono> list = new List<Telefono>();

            WebDriverWait initWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            initWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/header/div[2]/div[1]/form/div[2]/div/input[1]"))).SendKeys(marca + " " + modelo);

            IWebElement searchButton = driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div[1]/form/div[2]/div/button"));
            searchButton.Click();

            WebDriverWait lateWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            lateWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[1]/div/div[1]/div[2]/ul/li[1]/ul/li[1]/span"))).Click();

            IReadOnlyCollection<IWebElement> listaElementos = driver.FindElements(By.XPath("/html/body/div[3]/div/div[7]/div"));

            foreach(IWebElement elem in listaElementos)
            {
                string precio = elem.FindElement(By.ClassName(".userPrice")).Text;
                string nombre = elem.FindElement(By.ClassName(".Article-title")).Text;
                list.Add(new Telefono(nombre, precio));
            }

            return list;
        }
    }
}
