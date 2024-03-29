﻿using System;
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
        List<Telefono> resultPhones = new List<Telefono>();
        public Form1()
        {
            InitializeComponent();
        }

        public void populateGrid(List<Telefono> resultPhones)
        {
            resultGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (Telefono phone in resultPhones)
            {
                String[] row = {phone.Modelo, phone.Precio, phone.PrecioAnterior};
                resultGrid.Rows.Add(row);
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(resultGrid.Font, FontStyle.Bold);

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

            resultGrid.Rows.Clear();

            IWebDriver driver = new ChromeDriver("D:\\Escritorio\\IEI - Pract 2\\SeleniumPractica\\SeleniumPractica");
            //IWebDriver driver = new ChromeDriver("C:\\Users\\tomas\\Desktop\\SeleniumPractica\\SeleniumPractica");
            //IWebDriver driver = new ChromeDriver("C:\\Users\\Paco Paredes\\source\\repos\\SeleniumPractica\\SeleniumPractica");
            driver.Manage().Window.Maximize();
            String sMarca = marcas.SelectedItem.ToString();
            String sModelo = modelo.Text.Equals("Selecciona un modelo") ? "" : modelo.Text;

            if (amazonCheck.Checked)
            {
                AmazonSearch amazon = new AmazonSearch(driver);
                List<Telefono> telefonosAmazon = amazon.Search(sMarca, sModelo);
                if (telefonosAmazon != null)
                {
                    int row = resultGrid.Rows.Add("Resultados de Amazon:");
                    resultGrid.Rows[row].DefaultCellStyle = style;
                    populateGrid(telefonosAmazon);
                }
                else { resultGrid.Rows.Add("Sin resultados en Amazon"); }

            }

            if (fnacCheck.Checked)
            {
                FnacSearch fnac = new FnacSearch(driver);
                List<Telefono> telefonosFnac = fnac.Search(sMarca, sModelo);
                if (telefonosFnac.Count() != 0)
                {
                    int row = resultGrid.Rows.Add("Resultados de FNAC:");
                    resultGrid.Rows[row].DefaultCellStyle = style;
                    populateGrid(telefonosFnac);
                }
                else { resultGrid.Rows.Add("Sin resultados en FNAC"); }
            }

            if (PcComponentesCheck.Checked)
            {
                PcCompSearch pcc = new PcCompSearch(driver);
                List<Telefono> telefonosPcComp  = pcc.search(sMarca, sModelo);
                if (telefonosPcComp.Count() != 0)
                {
                    int row = resultGrid.Rows.Add("Resultados de PcComponentes:");
                    resultGrid.Rows[row].DefaultCellStyle = style;
                    populateGrid(telefonosPcComp);
                }
                else { resultGrid.Rows.Add("Sin resultados en PcComponentes"); }
            }
            driver.Quit();
        }
    }
}
