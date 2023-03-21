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
            this.SuspendLayout();
            // 
            // lblTumVarlik
            // 
            this.lblTumVarlik.AutoSize = true;
            this.lblTumVarlik.Enabled = false;
            this.lblTumVarlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTumVarlik.Location = new System.Drawing.Point(386, 43);
            this.lblTumVarlik.Name = "lblTumVarlik";
            this.lblTumVarlik.Size = new System.Drawing.Size(113, 20);
            this.lblTumVarlik.TabIndex = 1;
            this.lblTumVarlik.Text = "Tüm Varlıklar";
            this.lblTumVarlik.Click += new System.EventHandler(this.lblTumVarlik_Click);
            // 
            // lblEkipVarlik
            // 
            this.lblEkipVarlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEkipVarlik.Location = new System.Drawing.Point(180, 43);
            this.lblEkipVarlik.Name = "lblEkipVarlik";
            this.lblEkipVarlik.Size = new System.Drawing.Size(171, 20);
            this.lblEkipVarlik.TabIndex = 2;
            this.lblEkipVarlik.Text = "Ekibimin Varlıkları";
            this.lblEkipVarlik.Click += new System.EventHandler(this.lblEkipVarlik_Click);
            // 
            // lblVarliklarim
            // 
            this.lblVarliklarim.AutoSize = true;
            this.lblVarliklarim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVarliklarim.Location = new System.Drawing.Point(61, 43);
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
            this.label1.Location = new System.Drawing.Point(532, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Alarm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.lvVarliklar.Location = new System.Drawing.Point(12, 94);
            this.lvVarliklar.Name = "lvVarliklar";
            this.lvVarliklar.Size = new System.Drawing.Size(776, 344);
            this.lvVarliklar.TabIndex = 5;
            this.lvVarliklar.UseCompatibleStateImageBehavior = false;
            this.lvVarliklar.View = System.Windows.Forms.View.Details;
            this.lvVarliklar.SelectedIndexChanged += new System.EventHandler(this.lvVarliklar_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kayıt Numarası";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Barkod";
            this.columnHeader2.Width = 192;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ürün Tipi";
            this.columnHeader3.Width = 91;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ürünün Güncel Fiyatı";
            this.columnHeader4.Width = 131;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Markası";
            this.columnHeader5.Width = 94;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Modeli";
            this.columnHeader6.Width = 118;
            // 
            // FrmVarlikListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvVarliklar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVarliklarim);
            this.Controls.Add(this.lblEkipVarlik);
            this.Controls.Add(this.lblTumVarlik);
            this.Name = "FrmVarlikListe";
            this.Text = "VarlikListe";
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
    }
}