/**********************************************************************
 * Project:         CreaeWMList
 * Author:          Suneel Piduguralla
 * Date Created:    21 August 2006
 * Copyright:       You can distribute, copy, modify and  
 *                  even put your name as author.
 *                  
 * Description: 
 * Create a Windows Media Palyer 10 playlist from a selected directory
 * 
 * ********************************************************************/
using System;
using System.Collections;
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

        public const string Separator = ",";

        public static ArrayList searchAudio = new ArrayList();
        public static ArrayList searchVideo = new ArrayList();

        //public const int MAX_AUDIOTYPES = 20;
        //public const int MAX_VIDEOTYPES = 24;

        //string[] audioSearch = new string[MAX_AUDIOTYPES] { ".wma", ".wax", ".cda", ".wav", ".mp3", ".m3u", ".mid", ".midi", ".rmi", ".aif", ".aifc", ".aiff", ".au", ".snd", ".ra", ".rm", ".ram", ".rpm", ".rmm", ".rnx" };
        //string[] videoSearch = new string[MAX_VIDEOTYPES] { ".asf", ".asx", ".wpl", ".wm", ".wmx", ".wmd", ".wmz", ".wmv", ".wvx", ".avi", ".mpeg", ".mpg", ".mpe", ".m1v", ".mp2", ".mpv2", ".mp2v", ".mpa", ".dvr-ms", ".rm", ".ram", ".rpm", ".rmm", ".rnx" };

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

            LoadFormats();

            /*
             * Set Default formats
            int iIndex;
            for (iIndex = 0; iIndex < MAX_AUDIOTYPES; iIndex++)
                searchAudio.Add(audioSearch[iIndex]);

            for (iIndex = 0; iIndex < MAX_VIDEOTYPES; iIndex++)
                searchVideo.Add(videoSearch[iIndex]);

            txtDir.Text = "e:\\songs\\tamil\\jeans";
            */

            txtFilename.Text = "PlayList1.wpl";
        }

        #region Load Formats from formats.ini

        #region Parser
        private string Parse(string line, ref int index)
        {
            if (index == -1)
            {
                return "";
            }

            //Bypass the very first separator and start the string at the start of the data
            //if (index == 0)
            //{
            //    index = line.IndexOf(Separator, 0);
            //    index += Separator.Length;
            //}

            //Get the next separator position
            int tempNo = line.IndexOf(Separator, index);

            string sTemp = string.Empty;
            //Get the data in between the separators
            if (tempNo == -1)
            {
                sTemp = line.Substring(index);
                index = tempNo;
            }
            else
            {
                sTemp = line.Substring(index, tempNo - index);
                //Set the index to the start of the next set of data
                index = tempNo + Separator.Length;
            }

            // Remove Double quotes in a string.
            sTemp = sTemp.Trim('"', ' ');

            return sTemp.Trim();
        }
        #endregion

        private void LoadFormats()
        {
            string sFormatIni = "formats.ini";
            string sTemp;
            int index;

            FileStream fs = new FileStream(sFormatIni, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            using (fs)
            {
                string fileLine = string.Empty;

                try
                {
                    while ((fileLine = sr.ReadLine()) != null)
                    {
                        if (fileLine == string.Empty)
                            continue;

                        if (fileLine[0] == '#')     // Process only uncommented lines
                            continue;

                        index = 0;
                        sTemp = Parse(fileLine, ref index);
                        switch (sTemp.ToUpper())
                        {
                            case "AF":
                                sTemp = Parse(fileLine, ref index);
                                while (string.IsNullOrEmpty(sTemp) == false)
                                {
                                    searchAudio.Add(sTemp);

                                    sTemp = Parse(fileLine, ref index);
                                }
                                break;
                            case "VF":
                                sTemp = Parse(fileLine, ref index);
                                while (string.IsNullOrEmpty(sTemp) == false)
                                {
                                    searchVideo.Add(sTemp);

                                    sTemp = Parse(fileLine, ref index);
                                }
                                break;
                            default:
                                break;

                        }   // End switch
                    }       // End while
                }           // End Try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                }
                finally
                {
                    // Close File handles
                    sr.Close();
                    fs.Close();
                }
            }           // End Using
        }
        
        #endregion

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

            ArrayList searchList = new ArrayList();

            switch (cmbType.SelectedIndex)
            {
                case 0:                                         // Audio files
                    searchList = searchAudio;
                    break;
                case 1:                                         // Video files
                    searchList = searchVideo;
                    break;
                case 2:                                         // All Audio Video Files
                    searchList = searchAudio;
                    searchList.AddRange(searchVideo);
                    break;
                case 3:                                         // All files
                    //searchList = null;
                    break;
                default:
                    //searchList = null;
                    break;
            }

            if(File.Exists(sPath)) 
            {
                // This path is a file
                iFileCount = ProcessFile(sPath, searchList);
            }               
            else if(Directory.Exists(sPath)) 
            {
                // This path is a directory
                iFileCount = ProcessDirectory(sPath, searchList);
            }
            else 
            {
                MessageBox.Show(sPath + " is not a valid file or directory.");
            }        

            return iFileCount;

        }

        // Insert logic for processing found files here.
        public static int ProcessFile(string fileName, ArrayList searchList)
        {
            string fileLine;
            string sFileExt;
            int iFileCount = 0;

            if (string.IsNullOrEmpty(fileName) == true)
                return iFileCount;

            if (searchList.Count != 0)                     // If it's not All files
            {
                sFileExt = fileName.Substring(fileName.IndexOf('.'));
                if (searchList.IndexOf(sFileExt) == -1)
                    return iFileCount;
            }

            fileLine = "\t\t\t<media src=\"";
            fileLine = fileLine + fileName + "\"/>";
            sw.WriteLine(fileLine);

            return ( ++iFileCount);
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static int ProcessDirectory(string targetDirectory, ArrayList searchList)
        {
            int iFileCount = 0;

            if (string.IsNullOrEmpty(targetDirectory) == true)
                return iFileCount;

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            if (fileEntries.Length > 0)
            {
                foreach (string fileInfo in fileEntries)
                    iFileCount += ProcessFile(fileInfo, searchList);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            if (subdirectoryEntries.Length > 0)
            {
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory, searchList);
            }
            return iFileCount;
        }

        #endregion

        #region Open Directory
        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog();

            FolderBrowserDialog1.ShowNewFolderButton = false;           // Hide 'Make New Folder' button

            if (string.IsNullOrEmpty(txtDir.Text) == false)             // If something entered dir field
            {
                FolderBrowserDialog1.SelectedPath = txtDir.Text;
            }

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

            if (string.IsNullOrEmpty(txtFilename.Text) == false)
                SaveFileDialog1.FileName = txtFilename.Text;    
            else
                SaveFileDialog1.FileName = "Playlist1.wpl";

            //SaveFileDialog1.InitialDirectory = "C:\\Documents and Settings\\All Users\\My Documents\\My Music\\My Playlists";
            //SaveFileDialog1.FileName = "Playlist1.wpl";
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
            string sFilename = txtFilename.Text;
            if (string.IsNullOrEmpty(sFilename) == true)
            {
                MessageBox.Show("Filename field can not be empty.");
                return;
            }

            if (sFilename.IndexOf('.') == -1)               // If no extension specified
                txtFilename.Text = sFilename + ".wpl";      // Add default player list extension

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

       

    }
}