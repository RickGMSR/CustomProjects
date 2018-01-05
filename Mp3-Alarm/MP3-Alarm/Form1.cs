using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using CreateWMList;

namespace MP3_Alarm
{


    public partial class Main : Form
    {
     
        public static ArrayList searchAudio = new ArrayList();
        public const string Separator = ",";
     
        //string[] audioSearch = new string[MAX_AUDIOTYPES] { ".wma", ".wax", ".cda", ".wav", ".mp3", ".m3u", ".mid", ".midi", ".rmi", ".aif", ".aifc", ".aiff", ".au", ".snd", ".ra", ".rm", ".ram", ".rpm", ".rmm", ".rnx" };
        //string[] videoSearch = new string[MAX_VIDEOTYPES] { ".asf", ".asx", ".wpl", ".wm", ".wmx", ".wmd", ".wmz", ".wmv", ".wvx", ".avi", ".mpeg", ".mpg", ".mpe", ".m1v", ".mp2", ".mpv2", ".mp2v", ".mpa", ".dvr-ms", ".rm", ".ram", ".rpm", ".rmm", ".rnx" };

        public static StreamWriter sw;


        public Main()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private System.Threading.Timer timer;
        private void SetUpTimer(TimeSpan alertTime)
        {
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                return;//time already passed
            }
            this.timer = new System.Threading.Timer(x =>
            {
                this.ShowMessageToUser();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

       

        private void ShowMessageToUser()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.ShowMessageToUser));
            }
            else
            {

                //PlaylistMidday(@"D:\Music\wakeup\", "*.mp3");
                toolStripStatusLabel2.Text = "Alarm playing";
                PlaylistMidday(musicfolder.Text, "*.mp3");

            }
        }

        private void setAlarm_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text= "Alarm Waiting to Fire";
            SetUpTimer(new TimeSpan(DateTimeClock.Value.Hour, DateTimeClock.Value.Minute, 00));
        }


  

        private void buttonDir_Click(object sender, EventArgs e)
        {
            // New FolderBrowserDialog instance
            FolderBrowserDialog Fld = new FolderBrowserDialog();

            // Set initial selected folder
            Fld.SelectedPath = musicfolder.Text;

            // Show the "Make new folder" button
            Fld.ShowNewFolderButton = true;

            if (Fld.ShowDialog() == DialogResult.OK)
            {
                // Select successful
                //   MessageBox.Show("The folder you selected is : " + Fld.SelectedPath);
                MP3List.Items.Clear();
                musicfolder.Text = Fld.SelectedPath;
            }
            else
            {
                // Selection canceled
                //      MessageBox.Show("Operation canceled.");
            }


        }
       

        private void Main_Load(object sender, EventArgs e)
        {

            var filepath = musicfolder.Text;
            musicfolder.Text = filepath.ToString();

            loadsongs();
           DateTimeClock.Value =  Convert.ToDateTime("7:30 AM");
         
        }



        private void loadsongs()
        {
            DirectoryInfo dinfo = new DirectoryInfo(musicfolder.Text);
            FileInfo[] Files = dinfo.GetFiles("*.MP3");
            foreach (FileInfo file in Files)
            {
                MP3List.Items.Add(file.Name);
                
            }

        }
        private void btnLoadSongs_Click(object sender, EventArgs e)
        {
            MP3List.Items.Clear();
            loadsongs();
        }

  
        private void PlaylistMidday(String folder, string extendsion)
        {
            WMPLib.WindowsMediaPlayer wplayer1 = new WMPLib.WindowsMediaPlayer();
             WMPLib.IWMPPlaylist pl;
             WMPLib.IWMPPlaylistArray plItems;


            string myPlaylist = txtPlaylistname.Text;
            ListView musicList = new ListView();
            plItems = wplayer1.playlistCollection.getByName(myPlaylist);

            if (plItems.count == 0)

                pl = wplayer1.playlistCollection.newPlaylist(myPlaylist);

            else
                pl = plItems.Item(0);

            DirectoryInfo dir = new DirectoryInfo(folder);
            FileInfo[] files = dir.GetFiles(extendsion, SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                string musicFile01 = file.FullName;
                string mName = file.Name;
                ListViewItem item = new ListViewItem(mName);
                musicList.Items.Add(item);
                WMPLib.IWMPMedia m1 = wplayer1.newMedia(musicFile01);
                pl.appendItem(m1);

            }

            wplayer1.currentPlaylist = pl;
            wplayer1.settings.setMode("shuffle", true); // this does the trick
            wplayer1.controls.play();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCreateWMList Form = new frmCreateWMList();
            Form.Show();

        }
    }
}






