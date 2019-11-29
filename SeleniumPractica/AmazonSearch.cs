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
                    String PrecioAnterior = "";
                    try
                    {//div/span/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div[1]/div[1]/div/a/span[2]/span[2] //Precio original (de catalogo) normal
                        PrecioAnterior = elem.FindElement(By.CssSelector("div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > a:nth-child(1) > span:nth-child(2) > span:nth-child(2)")).Text;
                    }
                    catch(Exception e) {
                        try
                        { //Oferta black friday
                          //"span[class='a-price a-text-price']"
                          ////*[@id="search"]/div[1]/div[2]/div/span[4]/div[1]/div[1]/div/span/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div[1]/div[2]/div/a/span[2]/span[1]
                          // span:nth-child(5) > div.s-result-list.s-search-results.sg-row > div:nth-child(1) > div > span > div > div > div:nth-child(2) > div.sg-col-4-of-12.sg-col-8-of-16.sg-col-16-of-24.sg-col-12-of-20.sg-col-24-of-32.sg-col.sg-col-28-of-36.sg-col-20-of-28 > div > div:nth-child(2) > div.sg-col-4-of-24.sg-col-4-of-12.sg-col-4-of-36.sg-col-4-of-28.sg-col-4-of-16.sg-col.sg-col-4-of-20.sg-col-4-of-32 > div > div.a-section.a-spacing-none.a-spacing-top-small > div.a-row.a-size-base.a-color-base > div > a > span.a-price.a-text-price > span.a-offscreen
                          //#search > div.sg-row > div.sg-col-20-of-24.sg-col-28-of-32.sg-col-16-of-20.sg-col.s-right-column.sg-col-32-of-36.sg-col-8-of-12.sg-col-12-of-16.sg-col-24-of-28 > div > span:nth-child(5) > div.s-result-list.s-search-results.sg-row > div:nth-child(1) > div > span > div > div > div:nth-child(2) > div.sg-col-4-of-12.sg-col-8-of-16.sg-col-16-of-24.sg-col-12-of-20.sg-col-24-of-32.sg-col.sg-col-28-of-36.sg-col-20-of-28 > div > div:nth-child(2) > div.sg-col-4-of-24.sg-col-4-of-12.sg-col-4-of-36.sg-col-4-of-28.sg-col-4-of-16.sg-col.sg-col-4-of-20.sg-col-4-of-32 > div > div.a-section.a-spacing-none.a-spacing-top-small > div.a-row.a-size-base.a-color-base > div > a > span.a-price.a-text-price > span:nth-child(2)
                          //#search > div.sg-row > div.sg-col-20-of-24.sg-col-28-of-32.sg-col-16-of-20.sg-col.s-right-column.sg-col-32-of-36.sg-col-8-of-12.sg-col-12-of-16.sg-col-24-of-28 > div > span:nth-child(5) > div.s-result-list.s-search-results.sg-row > div:nth-child(1) > div > span > div > div > div:nth-child(2) > div.sg-col-4-of-12.sg-col-8-of-16.sg-col-16-of-24.sg-col-12-of-20.sg-col-24-of-32.sg-col.sg-col-28-of-36.sg-col-20-of-28 > div > div:nth-child(2) > div.sg-col-4-of-24.sg-col-4-of-12.sg-col-4-of-36.sg-col-4-of-28.sg-col-4-of-16.sg-col.sg-col-4-of-20.sg-col-4-of-32 > div > div.a-section.a-spacing-none.a-spacing-top-small > div.a-row.a-size-base.a-color-base > div > a > span.a-price.a-text-price > span:nth-child(2)
                            PrecioAnterior = elem.FindElement(By.CssSelector("span[class='a-price a-text-price']")).Text;
                        } catch(Exception ex) { }
                    }
                    Console.WriteLine(PrecioAnterior);
                    String precio = elem.FindElement(By.CssSelector(".a-price-whole")).Text;
                    String nombre = elem.FindElement(By.CssSelector("div.sg-col-4-of-12.sg-col-8-of-16.sg-col-16-of-24.sg-col-12-of-20.sg-col-24-of-32.sg-col.sg-col-28-of-36.sg-col-20-of-28 > div > div:nth-child(1) > div > div > div:nth-child(1) > h2 > a > span")).Text;
                    list.Add(new Telefono(nombre, precio, PrecioAnterior));
                }
                catch (Exception e) { }
            }
            return list;
            //.index\=3 > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > a:nth-child(1) > span:nth-child(2) > span:nth-child(2)
        }
    }
}
