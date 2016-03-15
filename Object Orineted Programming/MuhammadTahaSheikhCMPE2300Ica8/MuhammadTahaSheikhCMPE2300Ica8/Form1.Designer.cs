namespace MuhammadTahaSheikhCMPE2300Ica8
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
            this.btn_simulate = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lb_sheepleWaiting = new System.Windows.Forms.ListBox();
            this.timer_tick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_simulate
            // 
            this.btn_simulate.Location = new System.Drawing.Point(12, 12);
            this.btn_simulate.Name = "btn_simulate";
            this.btn_simulate.Size = new System.Drawing.Size(75, 23);
            this.btn_simulate.TabIndex = 0;
            this.btn_simulate.Text = "Simulate";
            this.btn_simulate.UseVisualStyleBackColor = true;
            this.btn_simulate.Click += new System.EventHandler(this.btn_simulate_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(113, 12);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // lb_sheepleWaiting
            // 
            this.lb_sheepleWaiting.FormattingEnabled = true;
            this.lb_sheepleWaiting.Location = new System.Drawing.Point(12, 46);
            this.lb_sheepleWaiting.Name = "lb_sheepleWaiting";
            this.lb_sheepleWaiting.Size = new System.Drawing.Size(139, 277);
            this.lb_sheepleWaiting.TabIndex = 2;
            // 
            // timer_tick
            // 
            this.timer_tick.Tick += new System.EventHandler(this.timer_tick_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 340);
            this.Controls.Add(this.lb_sheepleWaiting);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btn_simulate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_simulate;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox lb_sheepleWaiting;
        private System.Windows.Forms.Timer timer_tick;
    }
}

