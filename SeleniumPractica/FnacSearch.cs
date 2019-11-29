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

            IWebElement search = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/header/div[2]/div[1]/form/div[2]/div/input[1]")));
            search.SendKeys(marca + " " + modelo);

            IWebElement searchButton = driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/div[1]/form/div[2]/div/button"));
            searchButton.Click();

            try
            {
                //#col_gauche > div > div.nav > div.content > ul > li > ul > li:nth-child(1) > span
                IWebElement movilesFilter = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#col_gauche > div > div.nav > div.content > ul > li > ul > li:nth-child(1) > span")));
                movilesFilter.Click();
            }
            catch(Exception e) { Console.WriteLine("No se pudo encontrar cateogia"); }
                        

            System.Threading.Thread.Sleep(3000);

            WebDriverWait lista = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            lista.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("Article-item")));

            List<IWebElement> elementos = driver.FindElements(By.ClassName("Article-item")).ToList();
            Console.WriteLine(elementos.Count);

            foreach (IWebElement elem in elementos)
            {
                string nombre = elem.FindElement(By.ClassName("Article-title")).Text;
                string precio = string.Empty;
                string precioAnterior = string.Empty;
                Console.WriteLine(nombre);

                try
                {
                    precio = elem.FindElement(By.ClassName("price'")).Text;
                } 
                catch (Exception) 
                {
                    try
                    {
                        precio = elem.FindElement(By.ClassName("userPrice")).Text;
                    } 
                    catch (Exception) { }
                }

                try
                {
                    precioAnterior = elem.FindElement(By.ClassName("oldPrice")).Text;
                }
                catch (Exception)
                {
                    precioAnterior = "Este artículo no tiene descuento";
                }

                list.Add(new Telefono(modelo, precio, precioAnterior));
                //list.Add(new Telefono(nombre, precio));
            }
            return list;
        }  
    }
}
