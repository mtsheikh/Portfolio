namespace MuhammadTahaSheikhCMPE2300Assignment02
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
            this.components = new System.ComponentModel.Container();
            this.lbl_Opacity = new System.Windows.Forms.Label();
            this.lbl_X = new System.Windows.Forms.Label();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.tb_Y = new System.Windows.Forms.TrackBar();
            this.tb_X = new System.Windows.Forms.TrackBar();
            this.tb_Opacity = new System.Windows.Forms.TrackBar();
            this.chk_All = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tb_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Opacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Opacity
            // 
            this.lbl_Opacity.AutoSize = true;
            this.lbl_Opacity.Location = new System.Drawing.Point(12, 18);
            this.lbl_Opacity.Name = "lbl_Opacity";
            this.lbl_Opacity.Size = new System.Drawing.Size(55, 13);
            this.lbl_Opacity.TabIndex = 0;
            this.lbl_Opacity.Text = "Opacity: 0";
            this.lbl_Opacity.Click += new System.EventHandler(this.lbl_Opacity_Click);
            // 
            // lbl_X
            // 
            this.lbl_X.AutoSize = true;
            this.lbl_X.Location = new System.Drawing.Point(12, 66);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(29, 13);
            this.lbl_X.TabIndex = 1;
            this.lbl_X.Text = "X : 0";
            // 
            // lbl_Y
            // 
            this.lbl_Y.AutoSize = true;
            this.lbl_Y.Location = new System.Drawing.Point(12, 112);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(29, 13);
            this.lbl_Y.TabIndex = 2;
            this.lbl_Y.Text = "Y : 0";
            // 
            // tb_Y
            // 
            this.tb_Y.Location = new System.Drawing.Point(110, 112);
            this.tb_Y.Maximum = 15;
            this.tb_Y.Minimum = -15;
            this.tb_Y.Name = "tb_Y";
            this.tb_Y.Size = new System.Drawing.Size(384, 45);
            this.tb_Y.TabIndex = 3;
            this.tb_Y.Scroll += new System.EventHandler(this.tb_Y_Scroll);
            // 
            // tb_X
            // 
            this.tb_X.Location = new System.Drawing.Point(110, 63);
            this.tb_X.Maximum = 15;
            this.tb_X.Minimum = -15;
            this.tb_X.Name = "tb_X";
            this.tb_X.Size = new System.Drawing.Size(384, 45);
            this.tb_X.TabIndex = 4;
            this.tb_X.Scroll += new System.EventHandler(this.tb_X_Scroll);
            // 
            // tb_Opacity
            // 
            this.tb_Opacity.Location = new System.Drawing.Point(110, 12);
            this.tb_Opacity.Maximum = 255;
            this.tb_Opacity.Name = "tb_Opacity";
            this.tb_Opacity.Size = new System.Drawing.Size(384, 45);
            this.tb_Opacity.TabIndex = 5;
            this.tb_Opacity.TickFrequency = 10;
            this.tb_Opacity.Scroll += new System.EventHandler(this.tb_Opacity_Scroll);
            // 
            // chk_All
            // 
            this.chk_All.AutoSize = true;
            this.chk_All.Location = new System.Drawing.Point(262, 163);
            this.chk_All.Name = "chk_All";
            this.chk_All.Size = new System.Drawing.Size(37, 17);
            this.chk_All.TabIndex = 7;
            this.chk_All.Text = "All";
            this.chk_All.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 182);
            this.Controls.Add(this.chk_All);
            this.Controls.Add(this.tb_Opacity);
            this.Controls.Add(this.tb_X);
            this.Controls.Add(this.tb_Y);
            this.Controls.Add(this.lbl_Y);
            this.Controls.Add(this.lbl_X);
            this.Controls.Add(this.lbl_Opacity);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Opacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Opacity;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.TrackBar tb_Y;
        private System.Windows.Forms.TrackBar tb_X;
        private System.Windows.Forms.TrackBar tb_Opacity;
        private System.Windows.Forms.CheckBox chk_All;
        private System.Windows.Forms.Timer timer1;
    }
}

