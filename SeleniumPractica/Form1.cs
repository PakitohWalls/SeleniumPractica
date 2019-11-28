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
            String sMarca = marcas.SelectedItem.ToString();
            String sModelo = modelo.Text.Equals("Selecciona un modelo") ? "" : marcas.SelectedItem.ToString();
            IWebDriver driver = new ChromeDriver("D:\\Escritorio\\IEI - Pract 2\\SeleniumPractica\\SeleniumPractica");
            if (amazonCheck.Checked)
            {
                AmazonSearch amazon = new AmazonSearch(driver);
                List<Telefono> telefonosAmazon = amazon.Search(sMarca, sModelo);

            }

            if (fnacCheck.Checked)
            { 
            
            }

            if (PcComponentesCheck.Checked)
            {
                PcCompSearch pcc = new PcCompSearch(driver);
                List<Telefono> telefonosPcComp  = pcc.search(sMarca, sModelo);
                foreach (Telefono telf in telefonosPcComp) {
                    result.Add(telf.ToString());
                }
            }
            resultList.DataSource = result;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void marcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
