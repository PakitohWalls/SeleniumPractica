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
            this.SuspendLayout();
            // 
            // amazonCheck
            // 
            this.amazonCheck.AccessibleName = "amazonCheck";
            this.amazonCheck.AutoSize = true;
            this.amazonCheck.Location = new System.Drawing.Point(51, 97);
            this.amazonCheck.Name = "amazonCheck";
            this.amazonCheck.Size = new System.Drawing.Size(64, 17);
            this.amazonCheck.TabIndex = 0;
            this.amazonCheck.Text = "Amazon";
            this.amazonCheck.UseVisualStyleBackColor = true;
            this.amazonCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // fnacCheck
            // 
            this.fnacCheck.AccessibleName = "fnacCheck";
            this.fnacCheck.AutoSize = true;
            this.fnacCheck.Location = new System.Drawing.Point(51, 130);
            this.fnacCheck.Name = "fnacCheck";
            this.fnacCheck.Size = new System.Drawing.Size(54, 17);
            this.fnacCheck.TabIndex = 1;
            this.fnacCheck.Text = "FNAC";
            this.fnacCheck.UseVisualStyleBackColor = true;
            this.fnacCheck.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // PcComponentesCheck
            // 
            this.PcComponentesCheck.AutoSize = true;
            this.PcComponentesCheck.Location = new System.Drawing.Point(51, 165);
            this.PcComponentesCheck.Name = "PcComponentesCheck";
            this.PcComponentesCheck.Size = new System.Drawing.Size(104, 17);
            this.PcComponentesCheck.TabIndex = 2;
            this.PcComponentesCheck.Text = "PcComponentes";
            this.PcComponentesCheck.UseVisualStyleBackColor = true;
            // 
            // modelo
            // 
            this.modelo.AccessibleName = "inputModelo";
            this.modelo.Location = new System.Drawing.Point(206, 29);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(100, 20);
            this.modelo.TabIndex = 3;
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
            this.marcas.Location = new System.Drawing.Point(42, 28);
            this.marcas.Name = "marcas";
            this.marcas.Size = new System.Drawing.Size(121, 21);
            this.marcas.TabIndex = 4;
            // 
            // botonBuscar
            // 
            this.botonBuscar.AccessibleName = "botonBuscar";
            this.botonBuscar.Location = new System.Drawing.Point(348, 29);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 5;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 653);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.marcas);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.PcComponentesCheck);
            this.Controls.Add(this.fnacCheck);
            this.Controls.Add(this.amazonCheck);
            this.Name = "Form1";
            this.Text = "<";
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
    }
}

