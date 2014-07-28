using System;
using System.Windows.Forms;

namespace FoxyDownloader.Forms
{
    public partial class FrmDownload : Form
    {
        #region > Constructor

        public FrmDownload()
        {
            InitializeComponent();

            // Enable Double Buffer to prevent flickering
            Other.ListViewHelper.EnableDoubleBuffer(listviewDownloads);

            // Set the sizes of the columns.
            clmName.Width = listviewDownloads.Width / 3 + 150;
            clmProgress.Width = listviewDownloads.Width / 3 - 75;
            clmSize.Width = listviewDownloads.Width / 3 - 96;
        }

        #endregion

        #region > Events

        #region Form

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Resize the columns when the form/listview gets resized.
            clmName.Width = listviewDownloads.Width/3 + 150;
            clmProgress.Width = listviewDownloads.Width/3 - 75;
            clmSize.Width = listviewDownloads.Width/3 - 96;
        }

        #endregion

        #region Buttons

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion
    }
}
