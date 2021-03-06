namespace North_DbFirst
{
    partial class UrunForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.nUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cbDiscontinued = new System.Windows.Forms.CheckBox();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUnitPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProducts
            // 
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 15;
            this.lstProducts.Location = new System.Drawing.Point(12, 42);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(228, 229);
            this.lstProducts.TabIndex = 0;
            this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(256, 42);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(249, 23);
            this.txtProductName.TabIndex = 1;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(257, 100);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(248, 23);
            this.cmbCategory.TabIndex = 2;
            // 
            // nUnitPrice
            // 
            this.nUnitPrice.DecimalPlaces = 2;
            this.nUnitPrice.Location = new System.Drawing.Point(258, 71);
            this.nUnitPrice.Name = "nUnitPrice";
            this.nUnitPrice.Size = new System.Drawing.Size(247, 23);
            this.nUnitPrice.TabIndex = 3;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(258, 129);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(247, 23);
            this.cmbSupplier.TabIndex = 4;
            // 
            // cbDiscontinued
            // 
            this.cbDiscontinued.AutoSize = true;
            this.cbDiscontinued.Location = new System.Drawing.Point(259, 159);
            this.cbDiscontinued.Name = "cbDiscontinued";
            this.cbDiscontinued.Size = new System.Drawing.Size(132, 19);
            this.cbDiscontinued.TabIndex = 5;
            this.cbDiscontinued.Text = "Satışı devan etmiyor";
            this.cbDiscontinued.UseVisualStyleBackColor = true;
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(12, 11);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(228, 23);
            this.txtAra.TabIndex = 6;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(260, 196);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 69);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(346, 196);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 69);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(430, 196);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 69);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // UrunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 286);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.cbDiscontinued);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.nUnitPrice);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lstProducts);
            this.Name = "UrunForm";
            this.Text = "UrunForm";
            this.Load += new System.EventHandler(this.UrunForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUnitPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.NumericUpDown nUnitPrice;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.CheckBox cbDiscontinued;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
    }
}