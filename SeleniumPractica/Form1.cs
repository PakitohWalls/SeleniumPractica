using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPractica
{
    public partial class Form1 : Form
    {
        List<String> result = new List<String>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (marcas.SelectedItem is null)
            {
                modelErrorLabel.Text = "Debes seleccionar una marca";
                return;
            }
            else { modelErrorLabel.Text = ""; }

            if (!fnacCheck.Checked && !PcComponentesCheck.Checked && !amazonCheck.Checked)
            {
                checkboxErrorLabel.Text = "Selecciona al menos una tienda";
                return;
            }
            else { checkboxErrorLabel.Text = ""; }

            resultList.DataSource = null;
            result.Clear();

            //IWebDriver driver = new ChromeDriver("D:\\Escritorio\\IEI - Pract 2\\SeleniumPractica\\SeleniumPractica");
            IWebDriver driver = new ChromeDriver("D:\\Escritorio\\IEI - Pract 2\\SeleniumPractica\\SeleniumPractica");
            driver.Manage().Window.Maximize();
            String sMarca = marcas.SelectedItem.ToString();
            String sModelo = modelo.Text.Equals("Selecciona un modelo") ? "" : modelo.Text;

            if (amazonCheck.Checked)
            {
                AmazonSearch amazon = new AmazonSearch(driver);
                List<Telefono> telefonosAmazon = amazon.Search(sMarca, sModelo);

            }

            if (fnacCheck.Checked)
            { 
                 //Va Tomás hostiaa
            }

            if (PcComponentesCheck.Checked)
            {
                PcCompSearch pcc = new PcCompSearch(driver);
                List<Telefono> telefonosPcComp  = pcc.search(sMarca, sModelo);
                if (telefonosPcComp.Count() != 0)
                {
                    foreach (Telefono telf in telefonosPcComp)
                    {
                        result.Add(telf.ToString());
                    }
                }
                else { result.Add("Sin resultados en PcComponentes"); }
               
            }
            resultList.DataSource = result;
        }
    }
}
