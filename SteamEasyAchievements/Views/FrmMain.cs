using SteamEasyAchievements.Core.Controllers;
using SteamEasyAchievements.Core.ViewModels;
using SteamEasyAchievements.Extensibility;
using SteamEasyAchievements.Properties;
using Timer = System.Threading.Timer;

namespace SteamEasyAchievements.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //////////////////////////////////////// FORM ////////////////////////////////////////

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ucLoad ucLoad = new()
            {
                Name = "ucLoad",
                Location = new Point(0, 0)
            };

            Controls.Add(ucLoad);
            ucLoad.BringToFront();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            SteamProfileController.Login(Settings.Default.SteamApiKey, Settings.Default.SessionId, Settings.Default.SteamLoginSecure);
            SetControlsState();

            Controls["ucLoad"].Visible = false;
        }

        private void tmrLibrary_Tick()
        {
            Invoke(new Action(() =>
            {
                smiSettings.Enabled = false;
                btnLogout.Enabled = false;
                btnCalculate.Enabled = false;

                ucCalculate ucCalculate = new()
                {
                    Name = "ucCalculate",
                    Location = lsvAchievements.Location
                };

                Controls.Add(ucCalculate);
                ucCalculate.BringToFront();
            }));

            LibraryController.Calculate(Settings.Default.SteamApiKey, Settings.Default.SessionId, Settings.Default.SteamLoginSecure);

            Invoke(new Action(() =>
            {
                LoadGames();

                smiSettings.Enabled = true;
                btnLogout.Enabled = true;
                btnCalculate.Enabled = true;
                Controls["ucCalculate"].Dispose();
            }));
        }

        //////////////////////////////////////// MENU BAR ////////////////////////////////////////

        private void smiSettings_Click(object sender, EventArgs e)
        {
            FrmSettings form = new();
            form.ShowDialog();
            form.Dispose();
        }

        private void smiAbout_Click(object sender, EventArgs e)
        {
            FrmAbout form = new();
            form.ShowDialog();
            form.Dispose();
        }

        //////////////////////////////////////// BUTTONS ////////////////////////////////////////

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogin form = new();
            form.ShowDialog();
            form.Dispose();

            Controls["ucLoad"].Visible = true;

            SteamProfileController.Login(Settings.Default.SteamApiKey, Settings.Default.SessionId, Settings.Default.SteamLoginSecure);
            SetControlsState();

            Controls["ucLoad"].Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Settings.Default.SessionId = null;
            Settings.Default.SteamLoginSecure = null;
            Settings.Default.Save();

            SteamProfileController.Logout();
            SetControlsState();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Set a timer worker thread
            Timer tmrLibrary = new(_ => tmrLibrary_Tick(), null, 0, Timeout.Infinite);
        }

        //////////////////////////////////////// ACHIEVEMENT LIST ////////////////////////////////////////

        private void LoadGames()
        {
            List<AchievementView> dlcList = LibraryController.GetAchievements();

            lsvAchievements_Load(dlcList);

            lsvAchievements.Enabled = true;

            lblAchievementCount.Text = $"Count: {lsvAchievements.Items.Count}";
        }

        private void lsvAchievements_Load(List<AchievementView> achievements)
        {
            lsvAchievements.Items.Clear();

            lsvAchievements.BeginUpdate();

            foreach (AchievementView achievement in achievements)
            {
                ListViewItem item;
                ListViewItem.ListViewSubItem subItem;

                //Percentage
                item = new() { Tag = achievement.AppId, Text = $"{achievement.Percentage}%" };

                //Game
                subItem = new() { Text = achievement.AppId.ToString() };
                item.SubItems.Add(subItem);

                //Name
                subItem = new() { Text = achievement.Name };
                item.SubItems.Add(subItem);

                lsvAchievements.Items.Add(item);
            }

            lsvAchievements.EndUpdate();
        }

        //////////////////////////////////////// METHODS ////////////////////////////////////////

        private void SetControlsState()
        {
            bool session = SteamProfileController.IsSessionActive();

            if (session)
            {
                SteamProfileView steamProfile = SteamProfileController.GetSteamProfile();

                ptbAvatar.LoadAsync(steamProfile.AvatarUrl);
                lblUsername.Text = steamProfile.Username;
            }
            else
            {
                ptbAvatar.Image = ptbAvatar.InitialImage;
                lblUsername.Text = null;
            }

            btnLogin.Visible = !session;
            btnLogout.Visible = session;
            btnCalculate.Enabled = session;
        }
    }
}