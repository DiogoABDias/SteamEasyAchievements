using SteamEasyAchievements.Properties;
using System.Diagnostics;

namespace SteamEasyAchievements.Views
{
    public partial class FrmSettings : Form
    {
        readonly ErrorProvider _erpSteamApiKey;

        public FrmSettings()
        {
            InitializeComponent();
            _erpSteamApiKey = new();
        }

        //////////////////////////////////////// FORM ////////////////////////////////////////

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            //Controls
            txtSteamApiKey.Text = Settings.Default.SteamApiKey;

            //Errors
            _erpSteamApiKey.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _erpSteamApiKey.SetIconAlignment(txtSteamApiKey, ErrorIconAlignment.MiddleRight);
            _erpSteamApiKey.SetIconPadding(txtSteamApiKey, 5);

            //Help icons
            pbtSteamApiKey.Image = SystemIcons.Information.ToBitmap();

            //Tooltips
            ToolTip toolTip = new();
            toolTip.SetToolTip(pbtSteamApiKey, "This key is required in order to retrieve the owned games information.");
        }

        //////////////////////////////////////// STEAM API KEY ////////////////////////////////////////

        private void txtSteamApiKey_TextChanged(object sender, EventArgs e)
        {
            _erpSteamApiKey.Clear();
        }

        private void lnkGetSteamApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new()
            {
                StartInfo = new()
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    Arguments = "/c start https://steamcommunity.com/dev/apikey"
                }
            };

            process.Start();
        }

        //////////////////////////////////////// BUTTONS ////////////////////////////////////////

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSteamApiKey.Text))
            {
                _erpSteamApiKey.SetError(txtSteamApiKey, "Steam API Key is required!");
                return;
            }

            Settings.Default.SteamApiKey = txtSteamApiKey.Text;
            Settings.Default.Save();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}