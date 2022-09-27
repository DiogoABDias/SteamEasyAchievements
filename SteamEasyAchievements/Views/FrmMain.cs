using SteamDlcShopping.Extensibility;
using SteamDlcShopping.Views;
using SteamEasyAchievements.Core.Controllers;
using SteamEasyAchievements.Core.ViewModels;
using SteamEasyAchievements.Properties;
using Timer = System.Threading.Timer;

namespace Views
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
                    //Location = grbLibrary.Location
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

        //////////////////////////////////////// GAME LIST ////////////////////////////////////////

        private void LoadGames()
        {
            //LibraryView library = LibraryController.GetGames();

            //if (library.Games is null)
            //{
            //    return;
            //}

            //lsvGame_Load(library.Games);
            //lsvGame.Sort();

            //lsvGame.Enabled = true;
            //txtGameSearch.Enabled = true;
            //chkHideGamesNotOnSale.Enabled = true;

            //lblGameCount.Text = $"Count: {lsvGame.Items.Count}";
            //lblLibraryCost.Text = $"Cost: {library.TotalCost}";
            //btnBlacklist.Visible = false;
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