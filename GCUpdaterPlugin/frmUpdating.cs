using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using GlobalCommand;

namespace GCUpdaterPlugin
{
    public partial class frmUpdating : Form
    {

        int stage = 0;
        WebClient myClient = null;

        string repostr = "";


        Queue<string> files = new Queue<string>();
        string currentfile = "";
        int updateNum = 0;

        public frmUpdating()
        {
            InitializeComponent();
        }

        private void frmUpdating_Load(object sender, EventArgs e)
        {
            lsvUpdates.Location = new Point(10, 21);
            lsvUpdates.Visible = false;
            pDownload.Visible = false;
            
            gDL.Visible = false;

            spinner.AutoIncrement = false;
            spinner.Enabled = false;

            

            lblStatus.Visible = true;
            lblStatus.Text = "Select Next to begin the update process.  You must be directly connected to the Internet in order to download updates for GlobalCommand.";

            btnInstall.Text = "&Next >";
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Enabled = false;
            btnCancel.Enabled = false;
            stage++;

            switch (stage)
            {
                case 1:

                    lblStatus.Text = "Downloading Package Information...";
                    pDownload.Value = 0;
                    pDownload.Maximum = 100;
                     myClient = new WebClient();

                    Uri url;

                    try
                    {
                        url = new Uri(Settings.Strings[0]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This URL is not a valid reference to an update server.  Please fix it on the Settings dialog", "Error");
                        this.Close();
                        return;
                    }

                    repostr = Settings.Strings[0].Substring(0,Settings.Strings[0].Length - ("update.xml").Length);


                    
                    myClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                    myClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFinished);
                    
                    myClient.DownloadFileAsync(url,"update.xml");

                    spinner.Visible = true;
                    spinner.Enabled = true;
                    spinner.AutoIncrement = true;
                    spinner.AutoIncrementFrequency = 1;
                    //btnInstall.Text = "&Next >";

                    return;
                case 2:

                    // process treeview

                    foreach (ListViewItem cmd in lsvUpdates.Items)
                    {
                        if (cmd.Checked)
                        {


                            

                            if (cmd.Text.EndsWith(".dll") ||
                            cmd.Text.EndsWith(".exe"))
                            {
                                files.Enqueue(cmd.Text + "._new");
                            }
                            else
                            {
                                files.Enqueue(cmd.Text);
                            }

                        }
                    }

                    updateNum = files.Count;

                    lsvUpdates.Visible = false;
                    spinner.Visible = false;

                    string d = "";


                    // 3sec delay (3)000

                    d += "taskkill /F /IM GlobalCommand.exe\n";
                    d += "SET NonExist=1.1.1.1\n" +
                        "PING %NonExist% -n 1 -w 3000 >NUL\n";
                    foreach (string f in files)
                    {
                        if (f.EndsWith("._new"))
                        {
                            d += "del " + f.Replace("._new", "") + "\n ";
                            d += "rename " + f + " " + f.Replace("._new", "") + "\n";
                        }
                    }



                    d += "start GlobalCommand.exe\n";
                    d += "exit 0";
                    

                    try
                    {
                        try
                        {
                            File.Delete("restart.bat");
                            File.Delete("out1.txt");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        File.WriteAllText("restart.bat", d);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    
                    DownloadFiles();

                    break;
                case 3:
                    spinner.Visible = true;
                    spinner.Enabled = true;
                    lblStatus.Text = "Restarting and Updating GlobalCommand...";
                    // done, restart gc
                    System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo("restart.bat","");
                    si.CreateNoWindow = true;
                    si.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                    
                    // FIXME delete the plugin security file.

                    System.Diagnostics.Process.Start(si);
                    Application.DoEvents();

                    //System.Threading.Thread.Sleep(200);


                    //Application.Exit();
                    //Application.ExitThread();
                    break;
                case -1:
                    this.Close();
                    break;
            }
        }

        private void DownloadFiles()
        {

            if (currentfile != "")
            {
                if (System.IO.Path.GetExtension(currentfile) == "_new")
                {
                    try
                    {
                        if (File.Exists(System.IO.Path.GetFileNameWithoutExtension(currentfile)))
                        {
                            File.Delete(System.IO.Path.GetFileNameWithoutExtension(currentfile));
                        }
                        File.Move(currentfile, System.IO.Path.GetFileNameWithoutExtension(currentfile));

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            if (files.Count > 0)
            {
                string f = files.Dequeue();
                lblStatus.Text = "Downloading: " + f;
                pDownload.Visible = true;
                gDL.Visible = true;
                Uri url = null;
                try {
                    if (f.EndsWith("._new"))
                    {
                        url = new Uri(repostr + f.Replace("._new","") );
                    }
                    else
                    {
                        url = new Uri(repostr + f);
                    }
                } catch (Exception e) {
                    MessageBox.Show("Error: " + e.Message);
                    DownloadFiles();
                }

                currentfile = f;
                myClient.DownloadFileAsync(url, f);
               


            }
            else
            {
                gDL.Visible = false;
                pDownload.Visible = false;
                spinner.Enabled = false;
                
                btnCancel.Enabled = false;
                btnInstall.Enabled = true;

                if (updateNum > 0)
                {
                    // downloaded all files.
                    lblStatus.Text = "Updates Downloaded Successfully!  Restart GlobalCommand for new features.";
                    btnInstall.Text = "&Re-Launch";
                }
                else
                {
                    lblStatus.Text = "You did not select any updates.  No changes have been made";
                    btnInstall.Text = "&Close";
                    stage = -2;
                }
            }
        }

        void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.BytesReceived > 0)
            {
                spinner.Visible = false;
                spinner.AutoIncrement = false;
                gDL.Visible = true;
                pDownload.Visible = true;


                pDownload.Value = e.ProgressPercentage;

                lblSpeed.Text = "Downloading"; // should really show speed.
                string s = FriendlySize (e.BytesReceived) + " of " + FriendlySize( e.TotalBytesToReceive );
                lblSize.Text = s;


            }


        }

        string FriendlySize(long size)
        {
            if (size < 1024)
            {
                return size + "bytes";
            }
            else if (size < (1024 * 1024))
            {
                return Math.Round((double)size / 1024,1) + "Kb";
            } else if(size < 1024 * 1024*1024 ) {

                return Math.Round((double)size / 1024 / 1024) + "Mb";

            } else {
                return Math.Round((double)size / 1024 / 1024 / 1024) + "Gb";
            }
        }

        void DownloadFinished(object sender, AsyncCompletedEventArgs c)
        {
            switch(stage) {
                case 1:
                    if (c.Error != null)
                    {
                        lblStatus.Text = c.Error.Message;
                        spinner.Enabled = false;
                        pDownload.Visible = false;
                        gDL.Visible = false;
                    }
                    else
                    {
                        spinner.Visible = true;
                        spinner.AutoIncrement = true;
                        pDownload.Visible = false;
                        gDL.Visible = false;
                        lblStatus.Text = "Checking package list against local files...";


                        MD5Files m =(MD5Files) Serializer.Load<MD5Files>("update.xml");

                        foreach (MD5Files.KeyCollection kp in m.data)
                        {
                            if (File.Exists(kp.key))
                            {

                                try
                                {

                                    if (File.Exists("temp"))
                                    {
                                        File.Delete("temp");
                                    }
                                }
                                catch (Exception)
                                {

                                }

                                string hash = "";
                                File.Copy(kp.key, "temp");
                                try
                                {
                                     hash = GetMD5("temp");
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Error computing hash: " + e.Message);
                                }
                                File.Delete("temp");
                                if (hash == kp.value)
                                {
                                    // no action
                                }
                                else
                                {
                                    // add this file to list UPDATE
                                    ListViewItem li = new ListViewItem();

                                    li.Text = kp.key;
                                    li.Tag = kp;
                                    li.SubItems.Add(kp.value2);
                                    li.SubItems.Add("Update");
                                    //li.SubItems.Add("L: " + hash + " R: " + kp.value);
                                    li.Checked = true;
                                    lsvUpdates.Items.Add(li);
                                }

                            }
                            else
                            {
                                // file doesn't exist on client
                                bool d = false;
                                try
                                {
                                    d = bool.Parse(Settings.Strings[1]);
                                }
                                catch (Exception)
                                {

                                }

                                if (d)
                                {
                                    // add this file to list UPDATE
                                    ListViewItem li = new ListViewItem();

                                    li.Text = kp.key;
                                    li.Tag = kp;
                                    li.SubItems.Add(kp.value2);
                                    li.SubItems.Add("New");
                                    //li.SubItems.Add(" ");
                                    lsvUpdates.Items.Add(li);
                                }

                            }
                        }

                        if (lsvUpdates.Items.Count == 0)
                        {
                            lblStatus.Text = "GlobalCommand is already fully updated.";
                            lblStatus.Visible = true;
                            spinner.Enabled = false;
                            btnInstall.Text = "&Close";
                            stage = -2;
                            lsvUpdates.Visible = false;


                        }
                        else
                        {
                            spinner.Visible = false;
                            lsvUpdates.Visible = true;
                        }

                        btnInstall.Enabled = true;

                    }
                    break;
                case 2:
                    // new files downloading
                    
                    if (c.Error == null)
                    {

                        DownloadFiles();
                    }
                    else
                    {
                        MessageBox.Show(c.Error.Message);
                    }
                    break;
              }
        }


        private static string GetMD5(string filename)
        {
            StringBuilder sb = new StringBuilder();
            FileStream fs = new FileStream(filename, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(fs);
            fs.Close();
            foreach (byte hex in hash)
            {
                sb.Append(hex.ToString("x2"));
            }
            return sb.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (myClient != null)
            {
                try
                {
                    myClient.CancelAsync();
                }
                catch (Exception) { }
            }


            this.Close();

        }


    }
}
