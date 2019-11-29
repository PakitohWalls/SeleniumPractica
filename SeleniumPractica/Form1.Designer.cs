namespace SeleniumPractica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.amazonCheck = new System.Windows.Forms.CheckBox();
            this.fnacCheck = new System.Windows.Forms.CheckBox();
            this.PcComponentesCheck = new System.Windows.Forms.CheckBox();
            this.modelo = new System.Windows.Forms.TextBox();
            this.marcas = new System.Windows.Forms.ComboBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.modelErrorLabel = new System.Windows.Forms.Label();
            this.checkboxErrorLabel = new System.Windows.Forms.Label();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.nombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noDiscountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // amazonCheck
            // 
            this.amazonCheck.AccessibleName = "amazonCheck";
            this.amazonCheck.AutoSize = true;
            this.amazonCheck.Location = new System.Drawing.Point(273, 36);
            this.amazonCheck.Margin = new System.Windows.Forms.Padding(4);
            this.amazonCheck.Name = "amazonCheck";
            this.amazonCheck.Size = new System.Drawing.Size(81, 21);
            this.amazonCheck.TabIndex = 0;
            this.amazonCheck.Text = "Amazon";
            this.amazonCheck.UseVisualStyleBackColor = true;
            // 
            // fnacCheck
            // 
            this.fnacCheck.AccessibleName = "fnacCheck";
            this.fnacCheck.AutoSize = true;
            this.fnacCheck.Location = new System.Drawing.Point(273, 65);
            this.fnacCheck.Margin = new System.Windows.Forms.Padding(4);
            this.fnacCheck.Name = "fnacCheck";
            this.fnacCheck.Size = new System.Drawing.Size(66, 21);
            this.fnacCheck.TabIndex = 1;
            this.fnacCheck.Text = "FNAC";
            this.fnacCheck.UseVisualStyleBackColor = true;
            // 
            // PcComponentesCheck
            // 
            this.PcComponentesCheck.AutoSize = true;
            this.PcComponentesCheck.Location = new System.Drawing.Point(362, 36);
            this.PcComponentesCheck.Margin = new System.Windows.Forms.Padding(4);
            this.PcComponentesCheck.Name = "PcComponentesCheck";
            this.PcComponentesCheck.Size = new System.Drawing.Size(133, 21);
            this.PcComponentesCheck.TabIndex = 2;
            this.PcComponentesCheck.Text = "PcComponentes";
            this.PcComponentesCheck.UseVisualStyleBackColor = true;
            // 
            // modelo
            // 
            this.modelo.AccessibleName = "inputModelo";
            this.modelo.Location = new System.Drawing.Point(56, 68);
            this.modelo.Margin = new System.Windows.Forms.Padding(4);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(192, 22);
            this.modelo.TabIndex = 3;
            this.modelo.Text = "Selecciona un modelo";
            // 
            // marcas
            // 
            this.marcas.FormattingEnabled = true;
            this.marcas.Items.AddRange(new object[] {
            "Samsung",
            "LG",
            "Sony",
            "Huawei",
            "Motorola",
            "Apple",
            "OnePlus",
            "Lenovo",
            "Xiaomi"});
            this.marcas.Location = new System.Drawing.Point(56, 33);
            this.marcas.Margin = new System.Windows.Forms.Padding(4);
            this.marcas.Name = "marcas";
            this.marcas.Size = new System.Drawing.Size(192, 24);
            this.marcas.TabIndex = 4;
            this.marcas.Text = "Selecciona una marca";
            // 
            // botonBuscar
            // 
            this.botonBuscar.AccessibleName = "botonBuscar";
            this.botonBuscar.Location = new System.Drawing.Point(56, 98);
            this.botonBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(100, 28);
            this.botonBuscar.TabIndex = 5;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // modelErrorLabel
            // 
            this.modelErrorLabel.AutoSize = true;
            this.modelErrorLabel.Location = new System.Drawing.Point(1063, 38);
            this.modelErrorLabel.Name = "modelErrorLabel";
            this.modelErrorLabel.Size = new System.Drawing.Size(0, 17);
            this.modelErrorLabel.TabIndex = 7;
            this.modelErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkboxErrorLabel
            // 
            this.checkboxErrorLabel.AutoSize = true;
            this.checkboxErrorLabel.Location = new System.Drawing.Point(1063, 71);
            this.checkboxErrorLabel.Name = "checkboxErrorLabel";
            this.checkboxErrorLabel.Size = new System.Drawing.Size(0, 17);
            this.checkboxErrorLabel.TabIndex = 8;
            this.checkboxErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultGrid
            // 
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreCol,
            this.precioCol,
            this.noDiscountCol});
            this.resultGrid.Location = new System.Drawing.Point(56, 183);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.RowHeadersWidth = 51;
            this.resultGrid.RowTemplate.Height = 24;
            this.resultGrid.Size = new System.Drawing.Size(894, 313);
            this.resultGrid.TabIndex = 9;
            // 
            // nombreCol
            // 
            this.nombreCol.HeaderText = "Nombre";
            this.nombreCol.MinimumWidth = 6;
            this.nombreCol.Name = "nombreCol";
            this.nombreCol.Width = 125;
            // 
            // precioCol
            // 
            this.precioCol.HeaderText = "Precio";
            this.precioCol.MinimumWidth = 6;
            this.precioCol.Name = "precioCol";
            this.precioCol.Width = 125;
            // 
            // noDiscountCol
            // 
            this.noDiscountCol.HeaderText = "Sin descuento";
            this.noDiscountCol.MinimumWidth = 6;
            this.noDiscountCol.Name = "noDiscountCol";
            this.noDiscountCol.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 804);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.checkboxErrorLabel);
            this.Controls.Add(this.modelErrorLabel);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.marcas);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.PcComponentesCheck);
            this.Controls.Add(this.fnacCheck);
            this.Controls.Add(this.amazonCheck);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "<";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox amazonCheck;
        private System.Windows.Forms.CheckBox fnacCheck;
        private System.Windows.Forms.CheckBox PcComponentesCheck;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.ComboBox marcas;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Label modelErrorLabel;
        private System.Windows.Forms.Label checkboxErrorLabel;
        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDiscountCol;
    }
}

