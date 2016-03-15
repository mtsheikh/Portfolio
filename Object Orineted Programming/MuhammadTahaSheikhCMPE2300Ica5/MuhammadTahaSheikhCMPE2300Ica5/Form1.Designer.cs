namespace MuhammadTahaSheikhCMPE2300Ica5
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
            this.btn_addballs = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.pb_update = new System.Windows.Forms.ProgressBar();
            this.lbl_radius = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Color = new System.Windows.Forms.RadioButton();
            this.rb_distance = new System.Windows.Forms.RadioButton();
            this.rb_Radius = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_radius)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_radius
            // 
            this.tb_radius.Location = new System.Drawing.Point(12, 12);
            this.tb_radius.Maximum = 50;
            this.tb_radius.Minimum = -50;
            this.tb_radius.Name = "tb_radius";
            this.tb_radius.Size = new System.Drawing.Size(309, 45);
            this.tb_radius.TabIndex = 0;
            this.tb_radius.TickFrequency = 10;
            this.tb_radius.Scroll += new System.EventHandler(this.tb_radius_Scroll_1);
            // 
            // btn_addballs
            // 
            this.btn_addballs.Location = new System.Drawing.Point(12, 82);
            this.btn_addballs.Name = "btn_addballs";
            this.btn_addballs.Size = new System.Drawing.Size(169, 38);
            this.btn_addballs.TabIndex = 1;
            this.btn_addballs.Text = "Add Exclusive Balls";
            this.btn_addballs.UseVisualStyleBackColor = true;
            this.btn_addballs.Click += new System.EventHandler(this.btn_addballs_Click_1);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(200, 82);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(121, 38);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "Clear Balls";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // pb_update
            // 
            this.pb_update.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb_update.Location = new System.Drawing.Point(0, 211);
            this.pb_update.Maximum = 1000;
            this.pb_update.Name = "pb_update";
            this.pb_update.Size = new System.Drawing.Size(337, 23);
            this.pb_update.TabIndex = 3;
            // 
            // lbl_radius
            // 
            this.lbl_radius.AutoSize = true;
            this.lbl_radius.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_radius.Location = new System.Drawing.Point(126, 49);
            this.lbl_radius.Name = "lbl_radius";
            this.lbl_radius.Size = new System.Drawing.Size(79, 18);
            this.lbl_radius.TabIndex = 4;
            this.lbl_radius.Text = "Radius = 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Color);
            this.groupBox1.Controls.Add(this.rb_distance);
            this.groupBox1.Controls.Add(this.rb_Radius);
            this.groupBox1.Location = new System.Drawing.Point(13, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 67);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort Type";
            // 
            // rb_Color
            // 
            this.rb_Color.AutoSize = true;
            this.rb_Color.Location = new System.Drawing.Point(222, 16);
            this.rb_Color.Name = "rb_Color";
            this.rb_Color.Size = new System.Drawing.Size(49, 17);
            this.rb_Color.TabIndex = 2;
            this.rb_Color.Text = "Color";
            this.rb_Color.UseVisualStyleBackColor = true;
            this.rb_Color.Click += new System.EventHandler(this.rb_Radius_Click);
            // 
            // rb_distance
            // 
            this.rb_distance.AutoSize = true;
            this.rb_distance.Location = new System.Drawing.Point(116, 16);
            this.rb_distance.Name = "rb_distance";
            this.rb_distance.Size = new System.Drawing.Size(67, 17);
            this.rb_distance.TabIndex = 1;
            this.rb_distance.Text = "Distance";
            this.rb_distance.UseVisualStyleBackColor = true;
            this.rb_distance.Click += new System.EventHandler(this.rb_Radius_Click);
            // 
            // rb_Radius
            // 
            this.rb_Radius.AutoSize = true;
            this.rb_Radius.Checked = true;
            this.rb_Radius.Location = new System.Drawing.Point(3, 16);
            this.rb_Radius.Name = "rb_Radius";
            this.rb_Radius.Size = new System.Drawing.Size(58, 17);
            this.rb_Radius.TabIndex = 0;
            this.rb_Radius.TabStop = true;
            this.rb_Radius.Text = "Radius";
            this.rb_Radius.UseVisualStyleBackColor = true;
            this.rb_Radius.Click += new System.EventHandler(this.rb_Radius_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 234);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_radius);
            this.Controls.Add(this.pb_update);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_addballs);
            this.Controls.Add(this.tb_radius);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_radius)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tb_radius;
        private System.Windows.Forms.Button btn_addballs;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.ProgressBar pb_update;
        private System.Windows.Forms.Label lbl_radius;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Color;
        private System.Windows.Forms.RadioButton rb_distance;
        private System.Windows.Forms.RadioButton rb_Radius;
    }
}

