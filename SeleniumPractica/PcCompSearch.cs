using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumPractica
{
    public class PcCompSearch
    {
        IWebDriver driver;
        List<Telefono> result = new List<Telefono>();

        public PcCompSearch(IWebDriver driver)
        {
            this.driver = driver;
            driver.Url = "https://www.pccomponentes.com/";

        }

        public IWebElement search4Smartphone (IReadOnlyCollection<IWebElement> list, String param)
        {
            foreach (IWebElement elem in list)
            {
                if (elem.Text.Contains(param))
                {
                    return elem;
                }
            }
            return null;
        }

        public IWebElement search5Smartphone(IReadOnlyCollection<IWebElement> list, String param)
        {
            foreach (IWebElement elem in list)
            {
                if (elem.Text.Contains(param))
                {
                    return elem;
                }
            }
            return null;
        }

        public List<Telefono> search(String marca, String modelo)
        {
            String name, currentPrice, beforePrice;
            try
            {
                //Botón de cookies
                IWebElement cookieButton = driver.FindElement(By.XPath("html/body/div[6]/div/div/div[2]/button"));
                cookieButton.Click();
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception)
            {
                driver.Quit();
            }
            //Barra de búsqueda
            IWebElement search = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[3]/div[1]/div/div[2]/div/form/input")));
            search.SendKeys(marca + " " + modelo);
            search.SendKeys(Keys.Enter);
            //Filtro
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IReadOnlyCollection<IWebElement> filter1 = driver.FindElements(By.ClassName("acc-block-title"));
            IWebElement filter1Found = search4Smartphone(filter1, "SMARTPHONES/GPS");
            try
            {
                String expanded = filter1Found.FindElement(By.CssSelector("a.collapsed")).GetAttribute("aria-expanded");
                if (expanded.Equals("false"))
                {
                    Console.WriteLine("Entra");
                    filter1Found.Click();
                }
            } catch (Exception) { }
           

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IReadOnlyCollection<IWebElement> filter2 = driver.FindElements(By.ClassName("acc-block-body")); 
            IWebElement filter2Found = search5Smartphone(filter2, "Smartphone/Móviles");
            IReadOnlyCollection<IWebElement> filter3 = filter2Found.FindElements(By.ClassName("filterMenuItem"));
            IWebElement filter3Found = search5Smartphone(filter3, "Smartphone/Móviles");
            Actions actions = new Actions(driver);
            actions.MoveToElement(filter3Found).Click().Build().Perform();

            System.Threading.Thread.Sleep(1000);
            IReadOnlyCollection<IWebElement> res = driver.FindElements(By.ClassName("tarjeta-articulo__elementos-basicos"));
            Console.WriteLine("Searching " + res.Count() + " phone results...");
            foreach (IWebElement elem in res) {
                IWebElement elemPrice = elem.FindElement(By.ClassName("tarjeta-articulo__precios"));
                try 
                {
                    beforePrice = elemPrice.FindElement(By.ClassName("tarjeta-articulo__pvp-y-dto")).FindElement(By.ClassName("tarjeta-articulo__pvp")).Text;
                } catch (Exception) { beforePrice = "Este artículo no tiene descuento"; }
                Telefono phone = new Telefono(name = elem.FindElement(By.ClassName("tarjeta-articulo__nombre")).Text, currentPrice = elemPrice.FindElement(By.ClassName("tarjeta-articulo__precio-actual")).Text, beforePrice);
                result.Add(phone);
            }
            return result;
        }
    }
}

//Código para la búsqueda sin descuentos sin entrar en la ventana de resultados

//Console.WriteLine("found: " + filter2Found.Text);
//IWebElement filter = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
//.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div[2]/div/div/div[10]/div/ul/li[1]")));

//IWebElement filt = search4Smartphone(filter1);
//filt.Click();
//IWebElement filter = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
//.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div[2]/div/div/div[9]")));
//IWebElement filter2 = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
//.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/div/div/div[1]/div[2]/div/div/div[10]/div/ul/li[1]")));
//filter2.Click();
//IReadOnlyCollection<IWebElement> filterList = driver.FindElements(By.XPath("/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/ul/li"));
//IWebElement phoneSelector = search4Smartphone(filterList);

//if (phoneSelector != null)
//{
//    phoneSelector.Click();
//}
//else
//{
//    driver.FindElement(By.XPath("/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/button")).Click();
//    IReadOnlyCollection<IWebElement> filterAlt = driver.FindElements(By.XPath("/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/ul/li"));
//    phoneSelector = search4Smartphone(filterAlt);
//    phoneSelector.Click();
//}

//System.Threading.Thread.Sleep(3000);
//IReadOnlyCollection<IWebElement> smartCollection = driver.FindElements(By.ClassName("pcc-search-card"));
//Console.WriteLine(smartCollection.Count);
//foreach (IWebElement elem in smartCollection)
//{
//    try
//    {
//        if (elem.Text.Contains(marca) && elem.Text.Contains(modelo))
//        {
//            Telefono current = new Telefono(elem.FindElement(By.ClassName("title")).Text, elem.FindElement(By.ClassName("price")).Text);
//            result.Add(current);
//        }
//    }
//    catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
//}