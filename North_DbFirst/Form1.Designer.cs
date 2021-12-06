
namespace North_DbFirst
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvNorth = new System.Windows.Forms.DataGridView();
            this.btnGeri = new System.Windows.Forms.Button();
            this.butbtnIleriton2 = new System.Windows.Forms.Button();
            this.lblSayfa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNorth)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNorth
            // 
            this.dgvNorth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNorth.Location = new System.Drawing.Point(2, 52);
            this.dgvNorth.Name = "dgvNorth";
            this.dgvNorth.RowTemplate.Height = 25;
            this.dgvNorth.Size = new System.Drawing.Size(796, 394);
            this.dgvNorth.TabIndex = 0;
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(13, 5);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(75, 41);
            this.btnGeri.TabIndex = 1;
            this.btnGeri.Text = "<<<<<<<<<<<<<<<";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // butbtnIleriton2
            // 
            this.butbtnIleriton2.Location = new System.Drawing.Point(201, 5);
            this.butbtnIleriton2.Name = "butbtnIleriton2";
            this.butbtnIleriton2.Size = new System.Drawing.Size(75, 41);
            this.butbtnIleriton2.TabIndex = 2;
            this.butbtnIleriton2.Text = ">>>>>>>>>>>>>>>";
            this.butbtnIleriton2.UseVisualStyleBackColor = true;
            this.butbtnIleriton2.Click += new System.EventHandler(this.butbtnIleriton2_Click);
            // 
            // lblSayfa
            // 
            this.lblSayfa.AutoSize = true;
            this.lblSayfa.Location = new System.Drawing.Point(134, 18);
            this.lblSayfa.Name = "lblSayfa";
            this.lblSayfa.Size = new System.Drawing.Size(38, 15);
            this.lblSayfa.TabIndex = 3;
            this.lblSayfa.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSayfa);
            this.Controls.Add(this.butbtnIleriton2);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.dgvNorth);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNorth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNorth;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button butbtnIleriton2;
        private System.Windows.Forms.Label lblSayfa;
    }
}

