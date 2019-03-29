namespace GoogleBooksClient
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanelBookResults = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginInstallierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanelSortButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.textBoxSearchTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchTerm_KeyUp);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(552, 71);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(186, 34);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Suche";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanelBookResults
            // 
            this.flowLayoutPanelBookResults.AutoScroll = true;
            this.flowLayoutPanelBookResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelBookResults.Location = new System.Drawing.Point(64, 211);
            this.flowLayoutPanelBookResults.Name = "flowLayoutPanelBookResults";
            this.flowLayoutPanelBookResults.Size = new System.Drawing.Size(1205, 694);
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
            this.favoritenToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.favoritenToolStripMenuItem.Text = "Favoriten";
            this.favoritenToolStripMenuItem.Click += new System.EventHandler(this.favoritenToolStripMenuItem_Click);
            // 
            // pluginInstallierenToolStripMenuItem
            // 
            this.pluginInstallierenToolStripMenuItem.Name = "pluginInstallierenToolStripMenuItem";
            this.pluginInstallierenToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.pluginInstallierenToolStripMenuItem.Text = "Plugin installieren";
            this.pluginInstallierenToolStripMenuItem.Click += new System.EventHandler(this.pluginInstallierenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.beendenToolStripMenuItem.Text = "Beenden";
            // 
            // flowLayoutPanelSortButtons
            // 
            this.flowLayoutPanelSortButtons.AutoScroll = true;
            this.flowLayoutPanelSortButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.flowLayoutPanelSortButtons.Location = new System.Drawing.Point(64, 134);
            this.flowLayoutPanelSortButtons.Name = "flowLayoutPanelSortButtons";
            this.flowLayoutPanelSortButtons.Size = new System.Drawing.Size(1204, 54);
            this.flowLayoutPanelSortButtons.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(760, 70);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(191, 34);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 874);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.flowLayoutPanelSortButtons);
            this.Controls.Add(this.flowLayoutPanelBookResults);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearchTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchTerm;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBookResults;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoritenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginInstallierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSortButtons;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

