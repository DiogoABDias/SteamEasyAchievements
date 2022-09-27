using SteamEasyAchievements.Properties;

namespace SteamEasyAchievements.Extensibility
{
    public partial class ucCalculate : UserControl
    {
        public ucCalculate()
        {
            InitializeComponent();
        }

        private void ucLoading_Load(object sender, EventArgs e)
        {
            Control control = Parent.Controls["lsvAchievements"];
            Size = new Size(control.ClientSize.Width, control.ClientSize.Height);

            ptbLoading.Left = (ClientSize.Width - ptbLoading.Width) / 2;
            ptbLoading.Top = (ClientSize.Height - ptbLoading.Height) / 2;
            //ptbLoading.Image = Resources.defaultLoading;
        }
    }
}