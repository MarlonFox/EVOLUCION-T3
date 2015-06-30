namespace CodigoBarras
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGeneraPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLlenaExcel = new System.Windows.Forms.Button();
            this.txtNombreHoja = new System.Windows.Forms.TextBox();
            this.BtnBuscaExcelPrincipal = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvContenedor = new System.Windows.Forms.DataGridView();
            this.txtruta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenedor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneraPdf
            // 
            this.btnGeneraPdf.Location = new System.Drawing.Point(661, 34);
            this.btnGeneraPdf.Name = "btnGeneraPdf";
            this.btnGeneraPdf.Size = new System.Drawing.Size(89, 23);
            this.btnGeneraPdf.TabIndex = 58;
            this.btnGeneraPdf.Text = "Genera PDF";
            this.btnGeneraPdf.UseVisualStyleBackColor = true;
            this.btnGeneraPdf.Click += new System.EventHandler(this.btnGeneraPdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Seleccione la Ruta del Excel:";
            // 
            // btnLlenaExcel
            // 
            this.btnLlenaExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLlenaExcel.ForeColor = System.Drawing.Color.Black;
            this.btnLlenaExcel.Location = new System.Drawing.Point(587, 31);
            this.btnLlenaExcel.Name = "btnLlenaExcel";
            this.btnLlenaExcel.Size = new System.Drawing.Size(41, 28);
            this.btnLlenaExcel.TabIndex = 52;
            this.btnLlenaExcel.Text = "OK";
            this.btnLlenaExcel.UseVisualStyleBackColor = true;
            this.btnLlenaExcel.Click += new System.EventHandler(this.btnLlenaExcel_Click);
            // 
            // txtNombreHoja
            // 
            this.txtNombreHoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreHoja.Location = new System.Drawing.Point(358, 33);
            this.txtNombreHoja.Name = "txtNombreHoja";
            this.txtNombreHoja.Size = new System.Drawing.Size(223, 24);
            this.txtNombreHoja.TabIndex = 54;
            this.txtNombreHoja.Text = "hoja1";
            // 
            // BtnBuscaExcelPrincipal
            // 
            this.BtnBuscaExcelPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscaExcelPrincipal.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscaExcelPrincipal.Location = new System.Drawing.Point(279, 31);
            this.BtnBuscaExcelPrincipal.Name = "BtnBuscaExcelPrincipal";
            this.BtnBuscaExcelPrincipal.Size = new System.Drawing.Size(55, 26);
            this.BtnBuscaExcelPrincipal.TabIndex = 53;
            this.BtnBuscaExcelPrincipal.Text = "...";
            this.BtnBuscaExcelPrincipal.UseVisualStyleBackColor = true;
            this.BtnBuscaExcelPrincipal.Click += new System.EventHandler(this.BtnBuscaExcelPrincipal_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(355, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "Nombre de Hoja:";
            // 
            // dgvContenedor
            // 
            this.dgvContenedor.AllowUserToAddRows = false;
            this.dgvContenedor.AllowUserToDeleteRows = false;
            this.dgvContenedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContenedor.Location = new System.Drawing.Point(12, 67);
            this.dgvContenedor.Name = "dgvContenedor";
            this.dgvContenedor.ReadOnly = true;
            this.dgvContenedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContenedor.Size = new System.Drawing.Size(738, 432);
            this.dgvContenedor.TabIndex = 56;
            // 
            // txtruta
            // 
            this.txtruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtruta.Location = new System.Drawing.Point(12, 33);
            this.txtruta.Name = "txtruta";
            this.txtruta.Size = new System.Drawing.Size(261, 21);
            this.txtruta.TabIndex = 51;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 511);
            this.Controls.Add(this.btnGeneraPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLlenaExcel);
            this.Controls.Add(this.txtNombreHoja);
            this.Controls.Add(this.BtnBuscaExcelPrincipal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvContenedor);
            this.Controls.Add(this.txtruta);
            this.Name = "FrmPrincipal";
            this.Text = "Generador de Codigos de Barras en PDF";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContenedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneraPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLlenaExcel;
        private System.Windows.Forms.TextBox txtNombreHoja;
        private System.Windows.Forms.Button BtnBuscaExcelPrincipal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvContenedor;
        private System.Windows.Forms.TextBox txtruta;
    }
}

