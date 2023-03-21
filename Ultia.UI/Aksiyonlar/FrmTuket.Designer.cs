namespace Ultia.UI.AksiyonEkranlar
{
    partial class FrmTuket
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
            this.btnDosyaEkle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGaranti = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDosyaEkle
            // 
            this.btnDosyaEkle.Location = new System.Drawing.Point(169, 292);
            this.btnDosyaEkle.Name = "btnDosyaEkle";
            this.btnDosyaEkle.Size = new System.Drawing.Size(95, 31);
            this.btnDosyaEkle.TabIndex = 20;
            this.btnDosyaEkle.Text = "> Tüket";
            this.btnDosyaEkle.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Açıklama";
            // 
            // cmbGaranti
            // 
            this.cmbGaranti.FormattingEnabled = true;
            this.cmbGaranti.Location = new System.Drawing.Point(48, 108);
            this.cmbGaranti.Name = "cmbGaranti";
            this.cmbGaranti.Size = new System.Drawing.Size(216, 21);
            this.cmbGaranti.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Abone No";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(47, 178);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(217, 52);
            this.txtAciklama.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tüket";
            // 
            // FrmTuket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDosyaEkle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGaranti);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAciklama);
            this.Name = "FrmTuket";
            this.Text = "FrmTuket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDosyaEkle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGaranti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label1;
    }
}