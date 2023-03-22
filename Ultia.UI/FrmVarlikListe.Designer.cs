namespace Ultia.UI
{
    partial class FrmVarlikListe
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
            this.lblTumVarlik = new System.Windows.Forms.Label();
            this.lblEkipVarlik = new System.Windows.Forms.Label();
            this.lblVarliklarim = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvVarliklar = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTumVarlik
            // 
            this.lblTumVarlik.AutoSize = true;
            this.lblTumVarlik.Enabled = false;
            this.lblTumVarlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTumVarlik.Location = new System.Drawing.Point(618, 63);
            this.lblTumVarlik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTumVarlik.Name = "lblTumVarlik";
            this.lblTumVarlik.Size = new System.Drawing.Size(113, 20);
            this.lblTumVarlik.TabIndex = 1;
            this.lblTumVarlik.Text = "Tüm Varlıklar";
            this.lblTumVarlik.Click += new System.EventHandler(this.lblTumVarlik_Click);
            // 
            // lblEkipVarlik
            // 
            this.lblEkipVarlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEkipVarlik.Location = new System.Drawing.Point(343, 63);
            this.lblEkipVarlik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEkipVarlik.Name = "lblEkipVarlik";
            this.lblEkipVarlik.Size = new System.Drawing.Size(228, 20);
            this.lblEkipVarlik.TabIndex = 2;
            this.lblEkipVarlik.Text = "Ekibimin Varlıkları";
            this.lblEkipVarlik.Click += new System.EventHandler(this.lblEkipVarlik_Click);
            // 
            // lblVarliklarim
            // 
            this.lblVarliklarim.AutoSize = true;
            this.lblVarliklarim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVarliklarim.Location = new System.Drawing.Point(184, 63);
            this.lblVarliklarim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVarliklarim.Name = "lblVarliklarim";
            this.lblVarliklarim.Size = new System.Drawing.Size(92, 20);
            this.lblVarliklarim.TabIndex = 3;
            this.lblVarliklarim.Text = "Varlıklarım";
            this.lblVarliklarim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVarliklarim.Click += new System.EventHandler(this.lblVarliklarim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(812, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Alarm";
            // 
            // lvVarliklar
            // 
            this.lvVarliklar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvVarliklar.FullRowSelect = true;
            this.lvVarliklar.GridLines = true;
            this.lvVarliklar.HideSelection = false;
            this.lvVarliklar.Location = new System.Drawing.Point(119, 114);
            this.lvVarliklar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvVarliklar.Name = "lvVarliklar";
            this.lvVarliklar.Size = new System.Drawing.Size(1033, 344);
            this.lvVarliklar.TabIndex = 5;
            this.lvVarliklar.UseCompatibleStateImageBehavior = false;
            this.lvVarliklar.View = System.Windows.Forms.View.Details;
            this.lvVarliklar.SelectedIndexChanged += new System.EventHandler(this.lvVarliklar_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kayıt Numarası";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Barkod";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ürün Tipi";
            this.columnHeader3.Width = 225;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ürünün Güncel Fiyatı";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Markası";
            this.columnHeader5.Width = 140;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Modeli";
            this.columnHeader6.Width = 140;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.Location = new System.Drawing.Point(992, 465);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(161, 34);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Guncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // FrmVarlikListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1300, 589);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.lvVarliklar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVarliklarim);
            this.Controls.Add(this.lblEkipVarlik);
            this.Controls.Add(this.lblTumVarlik);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmVarlikListe";
            this.Text = "Varlık Listesi";
            this.Load += new System.EventHandler(this.FrmVarlikListe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTumVarlik;
        private System.Windows.Forms.Label lblEkipVarlik;
        private System.Windows.Forms.Label lblVarliklarim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvVarliklar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnGuncelle;
    }
}