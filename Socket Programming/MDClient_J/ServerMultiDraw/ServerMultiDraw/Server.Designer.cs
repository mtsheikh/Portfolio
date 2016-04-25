namespace ServerMultiDraw
{
    partial class Server
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
            this.UI_LSB_Connections = new System.Windows.Forms.ListBox();
            this.UI_LBL_TFrames = new System.Windows.Forms.Label();
            this.UI_LBL_TBytes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_LSB_Connections
            // 
            this.UI_LSB_Connections.FormattingEnabled = true;
            this.UI_LSB_Connections.Location = new System.Drawing.Point(11, 31);
            this.UI_LSB_Connections.Margin = new System.Windows.Forms.Padding(2);
            this.UI_LSB_Connections.Name = "UI_LSB_Connections";
            this.UI_LSB_Connections.Size = new System.Drawing.Size(461, 290);
            this.UI_LSB_Connections.TabIndex = 0;
            // 
            // UI_LBL_TFrames
            // 
            this.UI_LBL_TFrames.AutoSize = true;
            this.UI_LBL_TFrames.Location = new System.Drawing.Point(11, 9);
            this.UI_LBL_TFrames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_LBL_TFrames.Name = "UI_LBL_TFrames";
            this.UI_LBL_TFrames.Size = new System.Drawing.Size(44, 13);
            this.UI_LBL_TFrames.TabIndex = 2;
            this.UI_LBL_TFrames.Text = "Frames:";
            // 
            // UI_LBL_TBytes
            // 
            this.UI_LBL_TBytes.AutoSize = true;
            this.UI_LBL_TBytes.Location = new System.Drawing.Point(242, 9);
            this.UI_LBL_TBytes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UI_LBL_TBytes.Name = "UI_LBL_TBytes";
            this.UI_LBL_TBytes.Size = new System.Drawing.Size(36, 13);
            this.UI_LBL_TBytes.TabIndex = 3;
            this.UI_LBL_TBytes.Text = "Bytes:";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 332);
            this.Controls.Add(this.UI_LBL_TBytes);
            this.Controls.Add(this.UI_LBL_TFrames);
            this.Controls.Add(this.UI_LSB_Connections);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.Name = "Server";
            this.Text = "MultiDrawLineServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UI_LSB_Connections;
        private System.Windows.Forms.Label UI_LBL_TFrames;
        private System.Windows.Forms.Label UI_LBL_TBytes;
    }
}

