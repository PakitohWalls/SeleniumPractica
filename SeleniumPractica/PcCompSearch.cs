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
    public class PcCompSearch
    {
        IWebDriver driver;
        List<Telefono> result = new List<Telefono>();

        public PcCompSearch(IWebDriver driver)
        {
            this.driver = driver;
            //driver.Manage().Window.Maximize();
            driver.Url = "https://www.pccomponentes.com/";

        }

        public IWebElement search4Smartphone (IReadOnlyCollection<IWebElement> list)
        {
            foreach (IWebElement elem in list)
            {
                if (elem.Text.Contains("Smartphone/"))
                {
                    return elem;
                }
            }
            return null;
        }

        public List<Telefono> search(String marca, String modelo)
        {
            try
            {
                IWebElement cookieButton = driver.FindElement(By.XPath("html/body/div[6]/div/div/div[2]/button"));
                cookieButton.Click();
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception)
            {
                driver.Quit();
            }
            IWebElement search = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[3]/div[1]/div/div[2]/div/form/input")));
            search.SendKeys(marca + " " + modelo);
            IWebElement filter = (new WebDriverWait(driver, TimeSpan.FromSeconds(20)))
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/ul/li[2]/div/div")));
            IReadOnlyCollection<IWebElement> filterList = driver.FindElements(By.XPath("/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/ul/li"));
            IWebElement phoneSelector = search4Smartphone(filterList);

            if (phoneSelector != null)
            {
                phoneSelector.Click();
            }
            else
            {
                driver.FindElement(By.XPath("/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/button")).Click();
                IReadOnlyCollection<IWebElement> filterAlt = driver.FindElements(By.XPath("/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/ul/li"));
                phoneSelector = search4Smartphone(filterAlt);
                phoneSelector.Click();
            }

                //"/html/body/header/div[3]/div[2]/aside/div[3]/div[2]/div/button"

            System.Threading.Thread.Sleep(3000);
            IReadOnlyCollection<IWebElement> smartCollection = driver.FindElements(By.ClassName("pcc-search-card"));
            Console.WriteLine(smartCollection.Count);
            foreach (IWebElement elem in smartCollection)
            {
                try
                {
                    if (elem.Text.Contains(marca) && elem.Text.Contains(modelo))
                    {
                        Telefono current = new Telefono(elem.FindElement(By.ClassName("title")).Text, elem.FindElement(By.ClassName("price")).Text);
                        result.Add(current);
                    }
                }
                catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
            }
            driver.Quit();
            return result;
        }
    }
}
