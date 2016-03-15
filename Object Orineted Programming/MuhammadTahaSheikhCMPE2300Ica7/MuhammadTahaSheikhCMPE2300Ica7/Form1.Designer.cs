namespace MuhammadTahaSheikhCMPE2300Ica7
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
            this.btn_Populate = new System.Windows.Forms.Button();
            this.btn_Color = new System.Windows.Forms.Button();
            this.btn_Width = new System.Windows.Forms.Button();
            this.btn_WidthDesc = new System.Windows.Forms.Button();
            this.btn_WColor = new System.Windows.Forms.Button();
            this.btn_bright = new System.Windows.Forms.Button();
            this.btn_longer = new System.Windows.Forms.Button();
            this.tb_scroll = new System.Windows.Forms.TrackBar();
            this.lbl_min = new System.Windows.Forms.Label();
            this.lbl_max = new System.Windows.Forms.Label();
            this.lbl_currentVal = new System.Windows.Forms.Label();
            this.tb_remove = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tb_scroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remove)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Populate
            // 
            this.btn_Populate.Location = new System.Drawing.Point(12, 12);
            this.btn_Populate.Name = "btn_Populate";
            this.btn_Populate.Size = new System.Drawing.Size(230, 23);
            this.btn_Populate.TabIndex = 0;
            this.btn_Populate.Text = "Populate";
            this.btn_Populate.UseVisualStyleBackColor = true;
            this.btn_Populate.Click += new System.EventHandler(this.btn_Populate_Click);
            // 
            // btn_Color
            // 
            this.btn_Color.Location = new System.Drawing.Point(12, 41);
            this.btn_Color.Name = "btn_Color";
            this.btn_Color.Size = new System.Drawing.Size(230, 23);
            this.btn_Color.TabIndex = 1;
            this.btn_Color.Text = "Color";
            this.btn_Color.UseVisualStyleBackColor = true;
            this.btn_Color.Click += new System.EventHandler(this.btn_Color_Click);
            // 
            // btn_Width
            // 
            this.btn_Width.Location = new System.Drawing.Point(12, 70);
            this.btn_Width.Name = "btn_Width";
            this.btn_Width.Size = new System.Drawing.Size(230, 23);
            this.btn_Width.TabIndex = 2;
            this.btn_Width.Text = "Width";
            this.btn_Width.UseVisualStyleBackColor = true;
            this.btn_Width.Click += new System.EventHandler(this.btn_Width_Click);
            // 
            // btn_WidthDesc
            // 
            this.btn_WidthDesc.Location = new System.Drawing.Point(12, 99);
            this.btn_WidthDesc.Name = "btn_WidthDesc";
            this.btn_WidthDesc.Size = new System.Drawing.Size(230, 23);
            this.btn_WidthDesc.TabIndex = 3;
            this.btn_WidthDesc.Text = "Width Desc";
            this.btn_WidthDesc.UseVisualStyleBackColor = true;
            this.btn_WidthDesc.Click += new System.EventHandler(this.btn_WidthDesc_Click);
            // 
            // btn_WColor
            // 
            this.btn_WColor.Location = new System.Drawing.Point(12, 128);
            this.btn_WColor.Name = "btn_WColor";
            this.btn_WColor.Size = new System.Drawing.Size(230, 23);
            this.btn_WColor.TabIndex = 4;
            this.btn_WColor.Text = "Width, Color";
            this.btn_WColor.UseVisualStyleBackColor = true;
            this.btn_WColor.Click += new System.EventHandler(this.btn_WColor_Click);
            // 
            // btn_bright
            // 
            this.btn_bright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bright.Location = new System.Drawing.Point(12, 157);
            this.btn_bright.Name = "btn_bright";
            this.btn_bright.Size = new System.Drawing.Size(230, 23);
            this.btn_bright.TabIndex = 5;
            this.btn_bright.Text = "Bright";
            this.btn_bright.UseVisualStyleBackColor = true;
            this.btn_bright.Click += new System.EventHandler(this.btn_bright_Click);
            // 
            // btn_longer
            // 
            this.btn_longer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_longer.Location = new System.Drawing.Point(12, 186);
            this.btn_longer.Name = "btn_longer";
            this.btn_longer.Size = new System.Drawing.Size(230, 23);
            this.btn_longer.TabIndex = 6;
            this.btn_longer.Text = "Longer than 0";
            this.btn_longer.UseVisualStyleBackColor = true;
            this.btn_longer.Click += new System.EventHandler(this.btn_longer_Click);
            // 
            // tb_scroll
            // 
            this.tb_scroll.LargeChange = 1;
            this.tb_scroll.Location = new System.Drawing.Point(12, 215);
            this.tb_scroll.Maximum = 0;
            this.tb_scroll.Name = "tb_scroll";
            this.tb_scroll.Size = new System.Drawing.Size(230, 45);
            this.tb_scroll.TabIndex = 7;
            this.tb_scroll.TickFrequency = 10;
            this.tb_scroll.Scroll += new System.EventHandler(this.tb_scroll_Scroll);
            // 
            // lbl_min
            // 
            this.lbl_min.AutoSize = true;
            this.lbl_min.Location = new System.Drawing.Point(12, 247);
            this.lbl_min.Name = "lbl_min";
            this.lbl_min.Size = new System.Drawing.Size(66, 13);
            this.lbl_min.TabIndex = 8;
            this.lbl_min.Text = "Minimum = 0";
            // 
            // lbl_max
            // 
            this.lbl_max.AutoSize = true;
            this.lbl_max.Location = new System.Drawing.Point(161, 247);
            this.lbl_max.Name = "lbl_max";
            this.lbl_max.Size = new System.Drawing.Size(69, 13);
            this.lbl_max.TabIndex = 9;
            this.lbl_max.Text = "Maximum = 0";
            // 
            // lbl_currentVal
            // 
            this.lbl_currentVal.AutoSize = true;
            this.lbl_currentVal.Location = new System.Drawing.Point(109, 247);
            this.lbl_currentVal.Name = "lbl_currentVal";
            this.lbl_currentVal.Size = new System.Drawing.Size(13, 13);
            this.lbl_currentVal.TabIndex = 10;
            this.lbl_currentVal.Text = "0";
            // 
            // tb_remove
            // 
            this.tb_remove.LargeChange = 1;
            this.tb_remove.Location = new System.Drawing.Point(15, 263);
            this.tb_remove.Maximum = 200;
            this.tb_remove.Name = "tb_remove";
            this.tb_remove.Size = new System.Drawing.Size(230, 45);
            this.tb_remove.TabIndex = 11;
            this.tb_remove.TickFrequency = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 318);
            this.Controls.Add(this.tb_remove);
            this.Controls.Add(this.lbl_currentVal);
            this.Controls.Add(this.lbl_max);
            this.Controls.Add(this.lbl_min);
            this.Controls.Add(this.tb_scroll);
            this.Controls.Add(this.btn_longer);
            this.Controls.Add(this.btn_bright);
            this.Controls.Add(this.btn_WColor);
            this.Controls.Add(this.btn_WidthDesc);
            this.Controls.Add(this.btn_Width);
            this.Controls.Add(this.btn_Color);
            this.Controls.Add(this.btn_Populate);
            this.Name = "Form1";
            this.Text = "ica07 - PrediBlocks";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.tb_scroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Populate;
        private System.Windows.Forms.Button btn_Color;
        private System.Windows.Forms.Button btn_Width;
        private System.Windows.Forms.Button btn_WidthDesc;
        private System.Windows.Forms.Button btn_WColor;
        private System.Windows.Forms.Button btn_bright;
        private System.Windows.Forms.Button btn_longer;
        private System.Windows.Forms.TrackBar tb_scroll;
        private System.Windows.Forms.Label lbl_min;
        private System.Windows.Forms.Label lbl_max;
        private System.Windows.Forms.Label lbl_currentVal;
        private System.Windows.Forms.TrackBar tb_remove;
    }
}

