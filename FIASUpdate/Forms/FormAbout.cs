using System.Diagnostics;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            L_Version.Text = $"v{Application.ProductVersion}";
        }

        private static void OpenURL(string url) => Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

        private void LL_Control_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_Control.LinkVisited = true;
            OpenURL("https://github.com/Virenbar/FIAS_GAR");
        }

        private void LL_Icons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_Icons.LinkVisited = true;
            OpenURL("https://icons8.ru");
        }

        private void LL_Manual_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_Manual.LinkVisited = true;
            OpenURL("https://virenbar.ru/FIAS_GAR/fias-update/");
        }
    }
}