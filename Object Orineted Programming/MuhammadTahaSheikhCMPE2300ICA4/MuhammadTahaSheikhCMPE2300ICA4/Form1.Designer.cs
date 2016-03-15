namespace MuhammadTahaSheikhCMPE2300ICA4
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
            this.tb_radius = new System.Windows.Forms.TrackBar();
            this.lbl_radius = new System.Windows.Forms.Label();
            this.pb_update = new System.Windows.Forms.ProgressBar();
            this.btn_addballs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_radius)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_radius
            // 
            this.tb_radius.Location = new System.Drawing.Point(9, 23);
            this.tb_radius.Maximum = 50;
            this.tb_radius.Minimum = -50;
            this.tb_radius.Name = "tb_radius";
            this.tb_radius.Size = new System.Drawing.Size(417, 45);
            this.tb_radius.TabIndex = 0;
            this.tb_radius.TickFrequency = 10;
            this.tb_radius.Scroll += new System.EventHandler(this.tb_radius_Scroll);
            // 
            // lbl_radius
            // 
            this.lbl_radius.AutoSize = true;
            this.lbl_radius.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_radius.Location = new System.Drawing.Point(166, 59);
            this.lbl_radius.Name = "lbl_radius";
            this.lbl_radius.Size = new System.Drawing.Size(90, 25);
            this.lbl_radius.TabIndex = 1;
            this.lbl_radius.Text = "Size = 0";
            // 
            // pb_update
            // 
            this.pb_update.Location = new System.Drawing.Point(0, 145);
            this.pb_update.Maximum = 1000;
            this.pb_update.Name = "pb_update";
            this.pb_update.Size = new System.Drawing.Size(426, 29);
            this.pb_update.TabIndex = 2;
            this.pb_update.Click += new System.EventHandler(this.pb_update_Click);
            // 
            // btn_addballs
            // 
            this.btn_addballs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addballs.Location = new System.Drawing.Point(12, 99);
            this.btn_addballs.Name = "btn_addballs";
            this.btn_addballs.Size = new System.Drawing.Size(407, 40);
            this.btn_addballs.TabIndex = 3;
            this.btn_addballs.Text = "Add Balls";
            this.btn_addballs.UseVisualStyleBackColor = true;
            this.btn_addballs.Click += new System.EventHandler(this.btn_addballs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 173);
            this.Controls.Add(this.btn_addballs);
            this.Controls.Add(this.pb_update);
            this.Controls.Add(this.lbl_radius);
            this.Controls.Add(this.tb_radius);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_radius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tb_radius;
        private System.Windows.Forms.Label lbl_radius;
        private System.Windows.Forms.ProgressBar pb_update;
        private System.Windows.Forms.Button btn_addballs;
    }
}

