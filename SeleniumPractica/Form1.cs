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
            String sModelo = modelo.Text;
            String sMarca = marcas.SelectedItem.ToString();
            Console.WriteLine(fnacCheck.Checked);
            Console.WriteLine(PcComponentesCheck.Checked);
            Console.WriteLine(marcas.SelectedItem);
            IWebDriver driver = new ChromeDriver("D:\\Escritorio\\IEI - Pract 2\\SeleniumPractica\\SeleniumPractica");
            if (amazonCheck.Checked)
            {
                AmazonSearch amazon = new AmazonSearch(driver);
                amazon.search("", "" );

            }

            if (fnacCheck.Checked)
            { 
            
            }

            if (PcComponentesCheck.Checked)
            {
                PcCompSearch pcc = new PcCompSearch(driver);
                pcc.search(sMarca, sModelo);
            }

        }
    }
}
