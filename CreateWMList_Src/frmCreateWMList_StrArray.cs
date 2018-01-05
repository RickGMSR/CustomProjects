/**********************************************************************
 * Project:         CreaeWMList
 * Author:          Suneel Piduguralla
 * Date Created:    21 August 2006
 * Copyright:       You can copy, modify and even change author name.
 * 
 * Description: 
 * Create a Windows Media Palyer 10 playlist from a selected directory
 * 
 * ********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

/*
// Windows Media Player 10 List Format
<?wpl version="1.0"?>
<smil>
    <head>
        <meta name="Generator" content="Microsoft Windows Media Player -- 10.0.0.4036"/>
        <author/>
        <title>telugu_all</title>
    </head>
    <body>
        <seq>
            <media src="Filename1"/>
            ...........
            
        </seq>
    </body>
</smil>
*/

namespace CreateWMList
{
    public partial class frmCreateWMList : Form
    {
        #region Global Variables

        public static string sFileExt = "";

        public static string[] searchPattern = new string[44];
        string[] audioSearch = new string[20] { ".wma", ".wax", ".cda", ".wav", ".mp3", ".m3u", ".mid", ".midi", ".rmi", ".aif", ".aifc", ".aiff", ".au", ".snd", ".ra", ".rm", ".ram", ".rpm", ".rmm", ".rnx" };
        string[] videoSearch = new string[24] { ".asf", ".asx", ".wpl", ".wm", ".wmx", ".wmd", ".wmz", ".wmv", ".wvx", ".avi", ".mpeg", ".mpg", ".mpe", ".m1v", ".mp2", ".mpv2", ".mp2v", ".mpa", ".dvr-ms", ".rm", ".ram", ".rpm", ".rmm", ".rnx" };

        public static StreamWriter sw;

        #endregion
        
        public frmCreateWMList()
        {
            InitializeComponent();
        }

        private void frmCreateWMList_Load(object sender, EventArgs e)
        {
            // Set default values
            cmbType.SelectedIndex = 0;
            chkIncSubDir.Checked = true;

            txtDir.Text = "e:\\songs\\tamil\\jeans";
            txtFilename.Text = "C:\\PlayList1.wpl";
        }

        #region CreatePlayList
        private void CreatePlayList()
        {
            // Open a file to write
            string sFileName = txtFilename.Text;
            FileStream fs = File.Create(sFileName);
            sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine("<?wpl version=\"1.0\"?>");    // File Header
                sw.WriteLine("<smil>");                     // Start of File Tag

                sw.WriteLine("\t<head>");                     // Playlist File Header Information Start Tag
                sw.WriteLine("\t\t<meta name=\"Generator\" content=\"Microsoft Windows Media Player -- 10.0.0.4036\"/>");
                sw.WriteLine("\t\t<author>" + txtAuthor.Text + "</author>");
                sw.WriteLine("\t\t<title>" + txtTitle.Text + "</title>");
                sw.WriteLine("\t</head>");                    // Playlist File Header Information End Tag

                sw.WriteLine("\t<body>");                     // Start of body Tag
                sw.WriteLine("\t\t<seq>");                      // Start of filelist Tag


                // Get Directory's File list and Add files
                DirectoryListing(txtDir.Text);

                sw.WriteLine("\t\t</seq>");                      // End of filelist Tag
                sw.WriteLine("\t</body>");                    // End of body Tag
                sw.WriteLine("</smil>");                    // End of File Tag

                sFileName = sFileName + " Successfully created.";

                MessageBox.Show(sFileName, "Create Playlis");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Playlist: Error");

                sFileName = sFileName + " Unsuccessful.";

                MessageBox.Show(sFileName, "Create Playlis");
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        
        #endregion

        #region Get File List
        private int DirectoryListing(string sPath)
        {
            int iFileCount = 0;

            if (string.IsNullOrEmpty(sPath) == true)
            {
                MessageBox.Show("Directory not specified. Please select Valid directory.");
                return iFileCount;
            }

//            if (Directory.Exists(sPath) == false)
//            {
//                MessageBox.Show("Directory not exist. Please select Valid directory.");
//                return iFileCount;
//            }

            switch (cmbType.SelectedIndex)
            {
                case 0:                                         // Audio files
                    audioSearch.CopyTo(searchPattern, 0);
                    break;
                case 1:                                         // Video files
                    videoSearch.CopyTo(searchPattern, 0);
                    break;
                case 2:                                         // All Audio Video Files
                    audioSearch.CopyTo(searchPattern, 0);
                    videoSearch.CopyTo(searchPattern,19);
                    break;
                case 3:                                         // All files
                    break;
                default:
                    audioSearch.CopyTo(searchPattern, 0);
                    videoSearch.CopyTo(searchPattern,19);
                    break;
            }

            if(File.Exists(sPath)) 
            {
                //FileInfo fileInfo = new FileInfo(sPath);
                //iFileCount = ProcessFile(fileInfo);
                // This path is a file
                iFileCount = ProcessFile(sPath, cmbType.SelectedIndex);
            }               
            else if(Directory.Exists(sPath)) 
            {
                // This path is a directory
                iFileCount = ProcessDirectory(sPath, cmbType.SelectedIndex);
                //ProcessDirectory(sPath, cmbType.SelectedIndex);
            }
            else 
            {
                MessageBox.Show(sPath + " is not a valid file or directory.");
            }        

            return iFileCount;

        }

        // Search predicate returns true if a string ends in "sFileExt".
        public static bool SearchFileExtension(string sVar)
        {
            //                (sVar.Substring(sVar.Length - sFileExt.Length).ToLower() == sFileExt))

            if ((sVar.Length >= sFileExt.Length) &&
                (sVar.ToLower() == sFileExt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Insert logic for processing found files here.
        public static int ProcessFile(string fileName, int iIndex)
        {
            string fileLine;
            int iFileCount = 0;

            if (string.IsNullOrEmpty(fileName) == true)
                return iFileCount;

            if (iIndex != 3)                     // If it's not All files
            {
                sFileExt = fileName.Substring(fileName.IndexOf('.'));
                //sFileExt = fileInfo.Extension;      
                if (Array.FindIndex(searchPattern, SearchFileExtension) == -1)
                    return iFileCount;
            }

            fileLine = "\t\t\t<media src=\"";
//            fileLine = fileLine + fileInfo.FullName + "\"/>";
            fileLine = fileLine + fileName + "\"/>";
            sw.WriteLine(fileLine);

            return ( ++iFileCount);
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static int ProcessDirectory(string targetDirectory, int iIndex)
        {
            int iFileCount = 0;

            if (string.IsNullOrEmpty(targetDirectory) == true)
                return iFileCount;

            // Process the list of files found in the directory.
//            foreach (FileInfo fileInfo in DirectoryInfo.GetFiles(targetDirectory))
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            if (fileEntries.Length > 0)
            {
                foreach (string fileInfo in fileEntries)
                    iFileCount += ProcessFile(fileInfo, iIndex);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            if (subdirectoryEntries.Length > 0)
            {
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory, iIndex);
            }
            return iFileCount;
        }

        #endregion

        #region Open Directory
        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog();
            FolderBrowserDialog1.Description = "Select Folder to Create Playlist for...";

            // Show the FolderBrowserDialog.
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDir.Text = FolderBrowserDialog1.SelectedPath;
            }

            FolderBrowserDialog1.Dispose();
        } 
        #endregion

        #region Get Filename
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();

            SaveFileDialog1.Title = "Save Windows Playlist As...";
            SaveFileDialog1.Filter = "wpl files (*.wpl)|*.wpl|All files (*.*)|*.*";
            SaveFileDialog1.FilterIndex = 1;
            SaveFileDialog1.RestoreDirectory = true;
            SaveFileDialog1.DefaultExt = "wpl";
            SaveFileDialog1.InitialDirectory = "C:\\Documents and Settings\\All Users\\My Documents\\My Music\\My Playlists";
            SaveFileDialog1.FileName = "Playlist1";
            SaveFileDialog1.CreatePrompt = false;       // Don't prompt the user for permission to Create a file 
            
            // if the user specifies a file that does not exist
            SaveFileDialog1.OverwritePrompt = true;     // prompt the user for permission to Overwtire a file    

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(SaveFileDialog1.FileName) == false)
                {
                    txtFilename.Text = SaveFileDialog1.FileName;
                }
            }

            SaveFileDialog1.Dispose();
        }

        #endregion

        #region Button Controls
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Get Directory Name
            if (Directory.Exists(txtDir.Text) == false)      // if directory doesn't exist
            {
                MessageBox.Show(txtDir.Text + " does not exist.");
                return;
            }

            // Get Filename
            if (string.IsNullOrEmpty(txtFilename.Text) == true)
            {
                MessageBox.Show("Filename field can not be empty.");
                return;
            }

            // Get Author Name
            if (string.IsNullOrEmpty(txtAuthor.Text) == true)
            {
                txtAuthor.Text = "Suneel Piduguralla";
            }

            // Get Title Name
            if (string.IsNullOrEmpty(txtTitle.Text) == true)
            {
                txtTitle.Text = "My Playlist";
            }

            // Create List
            CreatePlayList();
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region About form
        private void btnAbout_Click(object sender, EventArgs e)
        {
            Form frmAbout1 = new frmAbout();

            frmAbout1.ShowDialog();
        }
        #endregion

    }
}