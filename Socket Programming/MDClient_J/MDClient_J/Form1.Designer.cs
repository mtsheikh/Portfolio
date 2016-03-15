﻿namespace MDClient_J
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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSetIP = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbIP = new System.Windows.Forms.ToolStripTextBox();
            this.tsmSetPort = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbPort = new System.Windows.Forms.ToolStripTextBox();
            this.tsmColour = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmThickness = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_thickness = new System.Windows.Forms.ToolStripComboBox();
            this.cdPenColour = new System.Windows.Forms.ColorDialog();
            this.lblError = new System.Windows.Forms.Label();
            this.byteCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.framesRecievedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentsRecievedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmColour,
            this.tsmThickness,
            this.byteCountToolStripMenuItem,
            this.framesRecievedToolStripMenuItem,
            this.fragmentsRecievedToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.msMainMenu.Size = new System.Drawing.Size(838, 28);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConnect,
            this.tsmSetIP,
            this.tsmSetPort});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(44, 24);
            this.tsmFile.Text = "File";
            // 
            // tsmConnect
            // 
            this.tsmConnect.Name = "tsmConnect";
            this.tsmConnect.Size = new System.Drawing.Size(138, 26);
            this.tsmConnect.Text = "Connect";
            this.tsmConnect.Click += new System.EventHandler(this.tsmConnect_Click);
            // 
            // tsmSetIP
            // 
            this.tsmSetIP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbIP});
            this.tsmSetIP.Name = "tsmSetIP";
            this.tsmSetIP.Size = new System.Drawing.Size(138, 26);
            this.tsmSetIP.Text = "Set IP";
            // 
            // tstbIP
            // 
            this.tstbIP.Name = "tstbIP";
            this.tstbIP.Size = new System.Drawing.Size(100, 27);
            this.tstbIP.Text = "bits.net.nait.ca";
            // 
            // tsmSetPort
            // 
            this.tsmSetPort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbPort});
            this.tsmSetPort.Name = "tsmSetPort";
            this.tsmSetPort.Size = new System.Drawing.Size(138, 26);
            this.tsmSetPort.Text = "Set Port";
            // 
            // tstbPort
            // 
            this.tstbPort.Name = "tstbPort";
            this.tstbPort.Size = new System.Drawing.Size(100, 27);
            this.tstbPort.Text = "1666";
            // 
            // tsmColour
            // 
            this.tsmColour.Name = "tsmColour";
            this.tsmColour.Size = new System.Drawing.Size(65, 24);
            this.tsmColour.Text = "Colour";
            this.tsmColour.Click += new System.EventHandler(this.tsmColour_Click);
            // 
            // tsmThickness
            // 
            this.tsmThickness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cb_thickness});
            this.tsmThickness.Name = "tsmThickness";
            this.tsmThickness.Size = new System.Drawing.Size(83, 24);
            this.tsmThickness.Text = "Thickness";
            // 
            // cb_thickness
            // 
            this.cb_thickness.Items.AddRange(new object[] {
            "Tiny",
            "Small",
            "Normal",
            "Large",
            "Huge"});
            this.cb_thickness.Name = "cb_thickness";
            this.cb_thickness.Size = new System.Drawing.Size(121, 28);
            this.cb_thickness.Text = "Tiny";
            this.cb_thickness.SelectedIndexChanged += new System.EventHandler(this.cb_thickness_SelectedIndexChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(13, 425);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 1;
            // 
            // byteCountToolStripMenuItem
            // 
            this.byteCountToolStripMenuItem.Name = "byteCountToolStripMenuItem";
            this.byteCountToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.byteCountToolStripMenuItem.Text = "Byte Count";
            // 
            // framesRecievedToolStripMenuItem
            // 
            this.framesRecievedToolStripMenuItem.Name = "framesRecievedToolStripMenuItem";
            this.framesRecievedToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.framesRecievedToolStripMenuItem.Text = "Frames Recieved";
            // 
            // fragmentsRecievedToolStripMenuItem
            // 
            this.fragmentsRecievedToolStripMenuItem.Name = "fragmentsRecievedToolStripMenuItem";
            this.fragmentsRecievedToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.fragmentsRecievedToolStripMenuItem.Text = "Fragments Recieved";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 454);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Draw";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ColorDialog cdPenColour;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmSetIP;
        private System.Windows.Forms.ToolStripMenuItem tsmSetPort;
        private System.Windows.Forms.ToolStripMenuItem tsmColour;
        private System.Windows.Forms.ToolStripMenuItem tsmThickness;
        private System.Windows.Forms.ToolStripComboBox cb_thickness;
        private System.Windows.Forms.ToolStripTextBox tstbIP;
        private System.Windows.Forms.ToolStripTextBox tstbPort;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ToolStripMenuItem byteCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem framesRecievedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fragmentsRecievedToolStripMenuItem;
    }
}

