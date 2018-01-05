namespace MediaKill
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.quitApp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.iCountDownDisplay = new System.Windows.Forms.NumericUpDown();
            this.bArm = new System.Windows.Forms.Button();
            this.LabelStopTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.labelprogress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.editapptoclose = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iCountDownDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // quitApp
            // 
            this.quitApp.Location = new System.Drawing.Point(238, 142);
            this.quitApp.Name = "quitApp";
            this.quitApp.Size = new System.Drawing.Size(90, 50);
            this.quitApp.TabIndex = 4;
            this.quitApp.Text = "Quit";
            this.quitApp.UseVisualStyleBackColor = true;
            this.quitApp.Click += new System.EventHandler(this.quitApp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minutes before Stop:";
            // 
            // iCountDownDisplay
            // 
            this.iCountDownDisplay.Location = new System.Drawing.Point(124, 31);
            this.iCountDownDisplay.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.iCountDownDisplay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iCountDownDisplay.Name = "iCountDownDisplay";
            this.iCountDownDisplay.Size = new System.Drawing.Size(53, 20);
            this.iCountDownDisplay.TabIndex = 0;
            this.iCountDownDisplay.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // bArm
            // 
            this.bArm.Location = new System.Drawing.Point(16, 142);
            this.bArm.Name = "bArm";
            this.bArm.Size = new System.Drawing.Size(90, 50);
            this.bArm.TabIndex = 2;
            this.bArm.Text = "Arm";
            this.bArm.UseVisualStyleBackColor = true;
            this.bArm.Click += new System.EventHandler(this.bArm_Click);
            // 
            // LabelStopTime
            // 
            this.LabelStopTime.AutoSize = true;
            this.LabelStopTime.Location = new System.Drawing.Point(124, 113);
            this.LabelStopTime.Name = "LabelStopTime";
            this.LabelStopTime.Size = new System.Drawing.Size(0, 13);
            this.LabelStopTime.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "App will Stop at:";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(127, 142);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(90, 49);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // labelprogress
            // 
            this.labelprogress.AutoSize = true;
            this.labelprogress.Location = new System.Drawing.Point(124, 223);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(0, 13);
            this.labelprogress.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Remaining Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Application to Stop:";
            // 
            // editapptoclose
            // 
            this.editapptoclose.Location = new System.Drawing.Point(124, 64);
            this.editapptoclose.Name = "editapptoclose";
            this.editapptoclose.Size = new System.Drawing.Size(146, 20);
            this.editapptoclose.TabIndex = 1;
            this.editapptoclose.Text = "ehshell";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(183, 31);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(46, 23);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "Save ";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 256);
            this.ControlBox = false;
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.editapptoclose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelprogress);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelStopTime);
            this.Controls.Add(this.bArm);
            this.Controls.Add(this.iCountDownDisplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Media Stop";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iCountDownDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quitApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown iCountDownDisplay;
        private System.Windows.Forms.Button bArm;
        private System.Windows.Forms.Label LabelStopTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label labelprogress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox editapptoclose;
        private System.Windows.Forms.Button button_save;
    }
}

