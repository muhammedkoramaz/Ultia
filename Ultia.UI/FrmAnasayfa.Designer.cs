namespace Ultia.UI
{
    partial class FrmAnasayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnasayfa));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDepo = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.panelBaslik = new System.Windows.Forms.Panel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.btnDuyuru = new System.Windows.Forms.Button();
            this.btnSss = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelBaslik.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(83)))), ((int)(((byte)(201)))));
            this.btnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEkle.FlatAppearance.BorderSize = 0;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Image = global::Ultia.UI.Properties.Resources.icons8_add_new_50;
            this.btnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkle.Location = new System.Drawing.Point(2, 87);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(0);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(150, 58);
            this.btnEkle.TabIndex = 1;
            this.btnEkle.Text = "Yeni Ekle";
            this.btnEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEkle.UseVisualStyleBackColor = false;
            // 
            // btnDepo
            // 
            this.btnDepo.Location = new System.Drawing.Point(27, 205);
            this.btnDepo.Name = "btnDepo";
            this.btnDepo.Size = new System.Drawing.Size(107, 23);
            this.btnDepo.TabIndex = 2;
            this.btnDepo.Text = "Depo Yonetimi";
            this.btnDepo.UseVisualStyleBackColor = true;
            this.btnDepo.Click += new System.EventHandler(this.btnDepo_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.btnSss);
            this.panelMenu.Controls.Add(this.btnDuyuru);
            this.panelMenu.Controls.Add(this.btnDepo);
            this.panelMenu.Controls.Add(this.btnEkle);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(156, 728);
            this.panelMenu.TabIndex = 0;
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanici.Location = new System.Drawing.Point(863, 40);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(52, 18);
            this.lblKullanici.TabIndex = 2;
            this.lblKullanici.Text = "label1";
            // 
            // panelBaslik
            // 
            this.panelBaslik.Controls.Add(this.lblKullanici);
            this.panelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBaslik.Location = new System.Drawing.Point(156, 0);
            this.panelBaslik.Name = "panelBaslik";
            this.panelBaslik.Size = new System.Drawing.Size(1052, 100);
            this.panelBaslik.TabIndex = 3;
            // 
            // panelForm
            // 
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(156, 100);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1052, 628);
            this.panelForm.TabIndex = 4;
            // 
            // btnDuyuru
            // 
            this.btnDuyuru.Location = new System.Drawing.Point(27, 304);
            this.btnDuyuru.Name = "btnDuyuru";
            this.btnDuyuru.Size = new System.Drawing.Size(107, 23);
            this.btnDuyuru.TabIndex = 3;
            this.btnDuyuru.Text = "Duyuru";
            this.btnDuyuru.UseVisualStyleBackColor = true;
            this.btnDuyuru.Click += new System.EventHandler(this.btnDuyuru_Click);
            // 
            // btnSss
            // 
            this.btnSss.Location = new System.Drawing.Point(27, 256);
            this.btnSss.Name = "btnSss";
            this.btnSss.Size = new System.Drawing.Size(107, 23);
            this.btnSss.TabIndex = 4;
            this.btnSss.Text = "Sık Sorulan Sorular";
            this.btnSss.UseVisualStyleBackColor = true;
            this.btnSss.Click += new System.EventHandler(this.btnSss_Click);
            // 
            // FrmAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 728);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelBaslik);
            this.Controls.Add(this.panelMenu);
            this.Name = "FrmAnasayfa";
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelBaslik.ResumeLayout(false);
            this.panelBaslik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnDepo;
        private System.Windows.Forms.Panel panelMenu;
        public System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.Panel panelBaslik;
        public System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnSss;
        private System.Windows.Forms.Button btnDuyuru;
    }
}