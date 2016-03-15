namespace MuhammadTahaSheikhCMPE2300Ica09
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
            this.nud_Divisor = new System.Windows.Forms.NumericUpDown();
            this.btn_top = new System.Windows.Forms.Button();
            this.btn_bottom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Divisor)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_Divisor
            // 
            this.nud_Divisor.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Divisor.Location = new System.Drawing.Point(12, 12);
            this.nud_Divisor.Name = "nud_Divisor";
            this.nud_Divisor.Size = new System.Drawing.Size(252, 20);
            this.nud_Divisor.TabIndex = 0;
            // 
            // btn_top
            // 
            this.btn_top.Location = new System.Drawing.Point(12, 38);
            this.btn_top.Name = "btn_top";
            this.btn_top.Size = new System.Drawing.Size(252, 32);
            this.btn_top.TabIndex = 1;
            this.btn_top.Text = "Make List";
            this.btn_top.UseVisualStyleBackColor = true;
            this.btn_top.Click += new System.EventHandler(this.btn_top_Click);
            // 
            // btn_bottom
            // 
            this.btn_bottom.Location = new System.Drawing.Point(12, 76);
            this.btn_bottom.Name = "btn_bottom";
            this.btn_bottom.Size = new System.Drawing.Size(252, 32);
            this.btn_bottom.TabIndex = 2;
            this.btn_bottom.Text = "Populate Linked List";
            this.btn_bottom.UseVisualStyleBackColor = true;
            this.btn_bottom.Click += new System.EventHandler(this.btn_bottom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 122);
            this.Controls.Add(this.btn_bottom);
            this.Controls.Add(this.btn_top);
            this.Controls.Add(this.nud_Divisor);
            this.Name = "Form1";
            this.Text = "ica09";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Divisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_Divisor;
        private System.Windows.Forms.Button btn_top;
        private System.Windows.Forms.Button btn_bottom;
    }
}

