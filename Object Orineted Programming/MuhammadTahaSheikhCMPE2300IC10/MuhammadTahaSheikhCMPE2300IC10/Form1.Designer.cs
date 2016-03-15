namespace MuhammadTahaSheikhCMPE2300IC10
{
    partial class Form1
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
            this.btn_load = new System.Windows.Forms.Button();
            this.lv_box = new System.Windows.Forms.ListView();
            this.hd_keyword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hd_frequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_load.Location = new System.Drawing.Point(0, 0);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(383, 47);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "Load File";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lv_box
            // 
            this.lv_box.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hd_keyword,
            this.hd_frequency});
            this.lv_box.Location = new System.Drawing.Point(0, 44);
            this.lv_box.Name = "lv_box";
            this.lv_box.Size = new System.Drawing.Size(383, 330);
            this.lv_box.TabIndex = 1;
            this.lv_box.UseCompatibleStateImageBehavior = false;
            this.lv_box.View = System.Windows.Forms.View.Details;
            // 
            // hd_keyword
            // 
            this.hd_keyword.Text = "KeyWord";
            this.hd_keyword.Width = 150;
            // 
            // hd_frequency
            // 
            this.hd_frequency.Text = "Frequency";
            this.hd_frequency.Width = 400;
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 375);
            this.Controls.Add(this.lv_box);
            this.Controls.Add(this.btn_load);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "ica10 - Keyword-o-tron";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ListView lv_box;
        private System.Windows.Forms.ColumnHeader hd_keyword;
        private System.Windows.Forms.ColumnHeader hd_frequency;
        private System.Windows.Forms.OpenFileDialog ofdFile;
    }
}

