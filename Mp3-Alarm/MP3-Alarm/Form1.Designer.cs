namespace MP3_Alarm
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.MP3List = new System.Windows.Forms.ListBox();
            this.Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.musicfolder = new System.Windows.Forms.TextBox();
            this.buttonDir = new System.Windows.Forms.Button();
            this.btnLoadSongs = new System.Windows.Forms.Button();
            this.setAlarm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblplaying = new System.Windows.Forms.Label();
            this.txtPlaylistname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DateTimeClock = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(18, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(54, 13);
            this.label.TabIndex = 0;
            this.label.Text = "Music List";
            // 
            // MP3List
            // 
            this.MP3List.FormattingEnabled = true;
            this.MP3List.HorizontalScrollbar = true;
            this.MP3List.Location = new System.Drawing.Point(21, 35);
            this.MP3List.Name = "MP3List";
            this.MP3List.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MP3List.Size = new System.Drawing.Size(279, 368);
            this.MP3List.Sorted = true;
            this.MP3List.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(626, 368);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(87, 23);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Music Folder";
            // 
            // musicfolder
            // 
            this.musicfolder.Location = new System.Drawing.Point(337, 41);
            this.musicfolder.Name = "musicfolder";
            this.musicfolder.Size = new System.Drawing.Size(279, 20);
            this.musicfolder.TabIndex = 6;
            this.musicfolder.Text = "d:\\music\\wake up\\";
            // 
            // buttonDir
            // 
            this.buttonDir.Location = new System.Drawing.Point(621, 41);
            this.buttonDir.Name = "buttonDir";
            this.buttonDir.Size = new System.Drawing.Size(30, 23);
            this.buttonDir.TabIndex = 8;
            this.buttonDir.Text = "...";
            this.buttonDir.UseVisualStyleBackColor = true;
            this.buttonDir.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // btnLoadSongs
            // 
            this.btnLoadSongs.Location = new System.Drawing.Point(657, 41);
            this.btnLoadSongs.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadSongs.Name = "btnLoadSongs";
            this.btnLoadSongs.Size = new System.Drawing.Size(56, 23);
            this.btnLoadSongs.TabIndex = 12;
            this.btnLoadSongs.Text = "Load Songs";
            this.btnLoadSongs.UseVisualStyleBackColor = true;
            this.btnLoadSongs.Click += new System.EventHandler(this.btnLoadSongs_Click);
            // 
            // setAlarm
            // 
            this.setAlarm.Location = new System.Drawing.Point(338, 161);
            this.setAlarm.Name = "setAlarm";
            this.setAlarm.Size = new System.Drawing.Size(87, 23);
            this.setAlarm.TabIndex = 3;
            this.setAlarm.Text = "Start Alarm";
            this.setAlarm.UseVisualStyleBackColor = true;
            this.setAlarm.Click += new System.EventHandler(this.setAlarm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Currently Playing:";
            // 
            // lblplaying
            // 
            this.lblplaying.AutoSize = true;
            this.lblplaying.Location = new System.Drawing.Point(424, 71);
            this.lblplaying.Name = "lblplaying";
            this.lblplaying.Size = new System.Drawing.Size(16, 13);
            this.lblplaying.TabIndex = 16;
            this.lblplaying.Text = "...";
            // 
            // txtPlaylistname
            // 
            this.txtPlaylistname.Location = new System.Drawing.Point(337, 117);
            this.txtPlaylistname.Name = "txtPlaylistname";
            this.txtPlaylistname.Size = new System.Drawing.Size(279, 20);
            this.txtPlaylistname.TabIndex = 19;
            this.txtPlaylistname.Text = "wakeup.wpl";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Playlist Name:";
            // 
            // DateTimeClock
            // 
            this.DateTimeClock.CustomFormat = "HH:mm";
            this.DateTimeClock.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeClock.Location = new System.Drawing.Point(438, 164);
            this.DateTimeClock.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.DateTimeClock.Name = "DateTimeClock";
            this.DateTimeClock.ShowUpDown = true;
            this.DateTimeClock.Size = new System.Drawing.Size(72, 20);
            this.DateTimeClock.TabIndex = 4;
            this.DateTimeClock.Value = new System.DateTime(2016, 3, 7, 7, 30, 0, 0);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(740, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "ccccc";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "PlayList";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 427);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlaylistname);
            this.Controls.Add(this.lblplaying);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadSongs);
            this.Controls.Add(this.buttonDir);
            this.Controls.Add(this.musicfolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateTimeClock);
            this.Controls.Add(this.setAlarm);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.MP3List);
            this.Controls.Add(this.label);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Media Alarm";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ListBox MP3List;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox musicfolder;
        private System.Windows.Forms.Button buttonDir;
        private System.Windows.Forms.Button btnLoadSongs;
        private System.Windows.Forms.Button setAlarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblplaying;
        private System.Windows.Forms.TextBox txtPlaylistname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DateTimeClock;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}

