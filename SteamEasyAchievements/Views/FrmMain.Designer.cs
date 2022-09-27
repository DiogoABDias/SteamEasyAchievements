namespace SteamEasyAchievements.Views
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.smiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.smiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lsvAchievements = new System.Windows.Forms.ListView();
            this.colPercentage = new System.Windows.Forms.ColumnHeader();
            this.colGame = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.lblAchievementCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(82, 42);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(82, 24);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 15);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "lblUsername";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(82, 42);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(82, 68);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("ptbAvatar.InitialImage")));
            this.ptbAvatar.Location = new System.Drawing.Point(12, 27);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(64, 64);
            this.ptbAvatar.TabIndex = 6;
            this.ptbAvatar.TabStop = false;
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiSettings,
            this.smiAbout});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(484, 24);
            this.mnuMenu.TabIndex = 9;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // smiSettings
            // 
            this.smiSettings.Name = "smiSettings";
            this.smiSettings.Size = new System.Drawing.Size(61, 20);
            this.smiSettings.Text = "Settings";
            this.smiSettings.Click += new System.EventHandler(this.smiSettings_Click);
            // 
            // smiAbout
            // 
            this.smiAbout.Name = "smiAbout";
            this.smiAbout.Size = new System.Drawing.Size(52, 20);
            this.smiAbout.Text = "About";
            this.smiAbout.Click += new System.EventHandler(this.smiAbout_Click);
            // 
            // lsvAchievements
            // 
            this.lsvAchievements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPercentage,
            this.colGame,
            this.colName});
            this.lsvAchievements.FullRowSelect = true;
            this.lsvAchievements.GridLines = true;
            this.lsvAchievements.Location = new System.Drawing.Point(12, 121);
            this.lsvAchievements.Name = "lsvAchievements";
            this.lsvAchievements.Size = new System.Drawing.Size(460, 352);
            this.lsvAchievements.TabIndex = 10;
            this.lsvAchievements.UseCompatibleStateImageBehavior = false;
            this.lsvAchievements.View = System.Windows.Forms.View.Details;
            // 
            // colPercentage
            // 
            this.colPercentage.Text = "Percentage";
            this.colPercentage.Width = 75;
            // 
            // colGame
            // 
            this.colGame.Text = "Game";
            this.colGame.Width = 200;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 164;
            // 
            // lblAchievementCount
            // 
            this.lblAchievementCount.AutoSize = true;
            this.lblAchievementCount.Location = new System.Drawing.Point(12, 103);
            this.lblAchievementCount.Name = "lblAchievementCount";
            this.lblAchievementCount.Size = new System.Drawing.Size(38, 15);
            this.lblAchievementCount.TabIndex = 11;
            this.lblAchievementCount.Text = "label1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 485);
            this.Controls.Add(this.lblAchievementCount);
            this.Controls.Add(this.lsvAchievements);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.ptbAvatar);
            this.Controls.Add(this.mnuMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMenu;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Easy Achievements";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLogin;
        private Label lblUsername;
        private Button btnLogout;
        private Button btnCalculate;
        private PictureBox ptbAvatar;
        private MenuStrip mnuMenu;
        private ToolStripMenuItem smiAbout;
        private ToolStripMenuItem smiSettings;
        private ListView lsvAchievements;
        private Label lblAchievementCount;
        private ColumnHeader colPercentage;
        private ColumnHeader colGame;
        private ColumnHeader colName;
    }
}