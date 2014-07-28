using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace FoxyDownloader.Forms
{
    public partial class FrmDownload : Form
    {
        bool _error404;
        private bool _canceled = false;
        /// <summary>
        /// This contains the urls that need to be added
        /// </summary>
        readonly List<string> _urlList = new List<string>();
        /// <summary>
        /// This contains the urls that will be downloaded
        /// </summary>
        private readonly Queue<string> _downloadUrls = new Queue<string>();
        /// <summary>
        /// The number of the file we're downloading
        /// </summary>
        private int _count;

        #region > Constructor

        public FrmDownload()
        {
            InitializeComponent();

            Text = "Downloader - " + Application.ProductVersion;

            // Set the sizes of the columns.
            clmName.Width = listviewDownloads.Width / 4 + 125;
            clmProgress.Width = listviewDownloads.Width / 4 - 50;
            clmSize.Width = listviewDownloads.Width / 4 - 50;
            clmStatus.Width = listviewDownloads.Width / 4 - 50;


            // Enable Double Buffer to prevent flickering
            Other.ListViewHelper.EnableDoubleBuffer(listviewDownloads);

            // This removes the rectangle outline when a ListViewItem is selected
            if (listviewDownloads.FocusedItem != null)
            {
                listviewDownloads.FocusedItem.Focused = false;
            }

            // The urls that need to be downloaded
            _urlList.Add("http://darkshadw.com/test/mods/1.6.4 DamageIndicatorsv2.9.2.3.zip");
            _urlList.Add("http://darkshadw.com/test/mods/1.6.4-SortFix-1.0.jar");
            _urlList.Add("http://darkshadw.com/test/mods/[1.6.4]ArmorStatusHUDv1.15.zi");
            _urlList.Add("http://darkshadw.com/test/mods/[1.6.4]bspkrsCorev5.2.zip");
            _urlList.Add("http://darkshadw.com/test/mods/[1.6.4]ReiMinimap_v3.4_01.zip.disabled");
            _urlList.Add("http://darkshadw.com/test/mods/[1.6.4]StatusEffectHUDv1.19.zip");
            _urlList.Add("http://darkshadw.com/test/mods/advancedGenetics_v1.4.1.jar");
        }

        #endregion

        #region > Events

        #region Form

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Resize the columns when the form/listview gets resized.
            clmName.Width = listviewDownloads.Width / 4 + 125;
            clmProgress.Width = listviewDownloads.Width / 4 - 50;
            clmSize.Width = listviewDownloads.Width / 4 - 50;
            clmStatus.Width = listviewDownloads.Width / 4 - 50;
        }

        #endregion

        #region Buttons

        private void btnStart_Click(object sender, EventArgs e)
        {
            DownloadInitialize(_urlList);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _canceled = true;
            _downloadUrls.Clear();
            _urlList.Clear();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Open the download directory
            Process.Start(@"C:\temp");
        }

        #endregion

        #endregion


        #region > Download stuff

        #region Initialize downloads

        /// <summary>
        /// This method adds the downloads to the download queue and it also adds all the listview items
        /// </summary>
        /// <param name="urls">The urls that need to be downloaded</param>
        private void DownloadInitialize(IEnumerable<string> urls)
        {
            // Search through the urls
            foreach (var url in urls)
            {
                _error404 = false;

                // Skip empty urls
                if (url == "")
                {
                    continue;
                }

                // Make a new uri so we can extact the filename
                Uri uri = new Uri(url);
                // Extract the filename
                string fileName = Path.GetFileName(uri.LocalPath);
                // Define the string size
                string size = "";
                // Here we are going to create a webrequest to get the filesize
                WebRequest req = WebRequest.Create(url);
                req.Method = "GET";
                try
                {
                    using (WebResponse resp = req.GetResponse())
                    {
                        int contentLength;
                        if (int.TryParse(resp.Headers.Get("Content-Length"), out contentLength))
                        {
                            // Convert the filesize to a readable text
                            size = Other.Helper.BytesToString(Convert.ToInt64(resp.Headers.Get("Content-Length")));
                        }
                        else
                        {
                            size = "?";
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e.Message == "The remote server returned an error: (404) Not Found.")
                    {
                        _error404 = true;
                        size = "0.00 KB";
                        Console.WriteLine("File not found.");
                    }

                    Console.WriteLine(e);
                }
                finally
                {
                    // Add the urls to a queue
                    _downloadUrls.Enqueue(url);
                    // The progressbar we're going to add
                    ProgressBar pb = new ProgressBar();
                    // The file name
                    listviewDownloads.Items.Add(fileName);
                    // An empty place for the progressbar
                    listviewDownloads.Items[listviewDownloads.Items.Count - 1].SubItems.Add("");
                    // Add the size
                    listviewDownloads.Items[listviewDownloads.Items.Count - 1].SubItems.Add(size);
                    // Change the icon to the blue stripes (waiting) or red cross (error)
                    if (_error404) listviewDownloads.Items[listviewDownloads.Items.Count - 1].ImageIndex = 3;
                    else listviewDownloads.Items[listviewDownloads.Items.Count - 1].ImageIndex = 2;
                    // Add the status code
                    if (_error404) listviewDownloads.Items[listviewDownloads.Items.Count - 1].SubItems.Add("404");
                    else listviewDownloads.Items[listviewDownloads.Items.Count - 1].SubItems.Add("OK!");
                    // Add the progressbar
                    listviewDownloads.AddEmbeddedControl(pb, 1, listviewDownloads.Items.Count - 1);
                }

                // This code makes it scroll down automatically
                Application.DoEvents();
            }

            // Starts the download
            DownloadStart();
        }

        #endregion

        #region Start Download

        /// <summary>
        /// This method downloads the files
        /// </summary>
        private void DownloadStart()
        {
            // Check if there are any downloads left to download (check if the queue isnt empty)
            if (_downloadUrls.Any())
            {
                // Create the webclient
                WebClient webClient = new WebClient();
                // Create the ProgressChanges event
                webClient.DownloadProgressChanged += client_DownloadProgressChanged;
                // Create the DownloadFileCompleted event
                webClient.DownloadFileCompleted += client_DownloadFileCompleted;

                // Get the next url
                var url = _downloadUrls.Dequeue();

                Uri uri = new Uri(url);
                string fileName = Path.GetFileName(uri.LocalPath);

                // Change the icon to the orange arrows (busy) or a red cross (error)
                if (listviewDownloads.Items[_count].ImageIndex == 3)
                {
                    ((ProgressBar)listviewDownloads.GetEmbeddedControl(1, _count)).Value = 100;
                    Other.Helper.ModifyProgressBarColor.SetState(((ProgressBar)listviewDownloads.GetEmbeddedControl(1, _count)), 2);
                }
                else
                {
                    listviewDownloads.Items[_count].ImageIndex = 1;
                }

                webClient.DownloadFileAsync(new Uri(url), "C:\\temp\\" + fileName);
                return;
            }

            // End of the download
            MessageBox.Show("Download Complete");
        }

        #endregion

        #region Progress

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // This code makes it scroll down automatically
            try
            {
                listviewDownloads.Items[_count].EnsureVisible();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            // This will update our progressbars
            ((ProgressBar)listviewDownloads.GetEmbeddedControl(1, _count)).Value = e.ProgressPercentage;
        }

        #endregion

        #region Completed

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!_canceled)
            {
                if (listviewDownloads.Items[_count].ImageIndex == 3)
                {
                    //ModifyProgressBarColor.SetState(((ProgressBar)listviewDownloads.GetEmbeddedControl(1, _count)), 2);
                }
                else
                {
                    listviewDownloads.Items[_count].ImageIndex = 0;
                }
                // Change the icon to the green check mark (finished)
                _count++;
                DownloadStart();
            }
            else
            {
                MessageBox.Show("Canceled");
                listviewDownloads.Items.Clear();
                Close();
            }
        }

        #endregion

        #endregion
    }
}
