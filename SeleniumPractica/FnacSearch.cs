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

            WebDriverWait busqueda = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            busqueda.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/header/div[2]/div[1]/form/div[2]/div/input[1]"))).SendKeys(marca + " " + modelo);

            IWebElement searchButton = driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div[1]/form/div[2]/div/button"));
            searchButton.Click();

            WebDriverWait moviles = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            moviles.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[1]/div/div[1]/div[2]/ul/li[1]/ul/li[1]/span"))).Click();

            WebDriverWait lista = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            lista.Until(ExpectedConditions.ElementIsVisible(By.ClassName("Article-item")));

            List<IWebElement> elementos = driver.FindElements(By.ClassName("Article-item")).ToList();

            foreach (IWebElement elem in elementos)
            {
                string nombre = elem.FindElement(By.ClassName("Article-title")).Text;
                string precio = elem.FindElement(By.ClassName("userPrice")).Text;
                Console.WriteLine(nombre);
                //list.Add(new Telefono(nombre, precio));
            }
            return list;
        }
    }
}
