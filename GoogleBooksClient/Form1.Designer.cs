﻿namespace GoogleBooksClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchTerm = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanelBookResults = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginInstallierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suchbegriff:";
            // 
            // textBoxSearchTerm
            // 
            this.textBoxSearchTerm.Location = new System.Drawing.Point(360, 71);
            this.textBoxSearchTerm.Name = "textBoxSearchTerm";
            this.textBoxSearchTerm.Size = new System.Drawing.Size(158, 26);
            this.textBoxSearchTerm.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Suche";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanelBookResults
            // 
            this.flowLayoutPanelBookResults.AutoScroll = true;
            this.flowLayoutPanelBookResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelBookResults.Location = new System.Drawing.Point(67, 137);
            this.flowLayoutPanelBookResults.Name = "flowLayoutPanelBookResults";
            this.flowLayoutPanelBookResults.Size = new System.Drawing.Size(1205, 717);
            this.flowLayoutPanelBookResults.TabIndex = 3;
            this.flowLayoutPanelBookResults.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1309, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoritenToolStripMenuItem,
            this.pluginInstallierenToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // favoritenToolStripMenuItem
            // 
            this.favoritenToolStripMenuItem.Name = "favoritenToolStripMenuItem";
            this.favoritenToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.favoritenToolStripMenuItem.Text = "Favoriten";
            this.favoritenToolStripMenuItem.Click += new System.EventHandler(this.favoritenToolStripMenuItem_Click);
            // 
            // pluginInstallierenToolStripMenuItem
            // 
            this.pluginInstallierenToolStripMenuItem.Name = "pluginInstallierenToolStripMenuItem";
            this.pluginInstallierenToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.pluginInstallierenToolStripMenuItem.Text = "Plugin installieren";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.beendenToolStripMenuItem.Text = "Beenden";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 874);
            this.Controls.Add(this.flowLayoutPanelBookResults);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSearchTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchTerm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBookResults;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoritenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginInstallierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    }
}
