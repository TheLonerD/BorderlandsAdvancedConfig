namespace BorderlandsAdvancedConfig
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.SettingsDirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.midPanel = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.chkCrouchToggle = new System.Windows.Forms.CheckBox();
            this.chkF9Hud = new System.Windows.Forms.CheckBox();
            this.chkF12Fps = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtF11Fov = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtF10Fov = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkScrollWheel = new System.Windows.Forms.CheckBox();
            this.chkZoomToggle = new System.Windows.Forms.CheckBox();
            this.chkConsole = new System.Windows.Forms.CheckBox();
            this.chkDisablevchat = new System.Windows.Forms.CheckBox();
            this.chkDisableMouseSmooth = new System.Windows.Forms.CheckBox();
            this.chkFOVAdjust = new System.Windows.Forms.CheckBox();
            this.grpGraphic = new System.Windows.Forms.GroupBox();
            this.chkOutlines = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSmoothFrameRate = new System.Windows.Forms.CheckBox();
            this.txtScreenPercentage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxAA = new System.Windows.Forms.Label();
            this.trkMaxAA = new System.Windows.Forms.TrackBar();
            this.lblMaxAnsio = new System.Windows.Forms.Label();
            this.trkMaxAnsio = new System.Windows.Forms.TrackBar();
            this.chkDisableStartup = new System.Windows.Forms.CheckBox();
            this.chkPhysX = new System.Windows.Forms.CheckBox();
            this.chkVsync = new System.Windows.Forms.CheckBox();
            this.chkHBloom = new System.Windows.Forms.CheckBox();
            this.chkAmbient = new System.Windows.Forms.CheckBox();
            this.trkPlayerInfoMaxDist = new System.Windows.Forms.TrackBar();
            this.UpdateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.lnkOfficialThread = new System.Windows.Forms.LinkLabel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.topPicture = new System.Windows.Forms.PictureBox();
            this.midPanel.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpGraphic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMaxAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMaxAnsio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPlayerInfoMaxDist)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsDirBrowser
            // 
            this.SettingsDirBrowser.SelectedPath = "c:\\";
            // 
            // midPanel
            // 
            this.midPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.midPanel.Controls.Add(this.txtLog);
            this.midPanel.Controls.Add(this.grpInput);
            this.midPanel.Controls.Add(this.grpGraphic);
            this.midPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.midPanel.Location = new System.Drawing.Point(0, 150);
            this.midPanel.Name = "midPanel";
            this.midPanel.Size = new System.Drawing.Size(776, 358);
            this.midPanel.TabIndex = 35;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(456, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(320, 358);
            this.txtLog.TabIndex = 34;
            this.txtLog.TabStop = false;
            this.txtLog.Text = "";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.chkCrouchToggle);
            this.grpInput.Controls.Add(this.chkF9Hud);
            this.grpInput.Controls.Add(this.chkF12Fps);
            this.grpInput.Controls.Add(this.label6);
            this.grpInput.Controls.Add(this.txtF11Fov);
            this.grpInput.Controls.Add(this.label7);
            this.grpInput.Controls.Add(this.label4);
            this.grpInput.Controls.Add(this.txtF10Fov);
            this.grpInput.Controls.Add(this.label5);
            this.grpInput.Controls.Add(this.chkScrollWheel);
            this.grpInput.Controls.Add(this.chkZoomToggle);
            this.grpInput.Controls.Add(this.chkConsole);
            this.grpInput.Controls.Add(this.chkDisablevchat);
            this.grpInput.Controls.Add(this.chkDisableMouseSmooth);
            this.grpInput.Controls.Add(this.chkFOVAdjust);
            this.grpInput.ForeColor = System.Drawing.Color.White;
            this.grpInput.Location = new System.Drawing.Point(246, 3);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(204, 349);
            this.grpInput.TabIndex = 32;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input Settings";
            // 
            // chkCrouchToggle
            // 
            this.chkCrouchToggle.AutoSize = true;
            this.chkCrouchToggle.Location = new System.Drawing.Point(18, 188);
            this.chkCrouchToggle.Name = "chkCrouchToggle";
            this.chkCrouchToggle.Size = new System.Drawing.Size(137, 17);
            this.chkCrouchToggle.TabIndex = 32;
            this.chkCrouchToggle.Text = "Make Crouch Togglable";
            this.chkCrouchToggle.UseVisualStyleBackColor = true;
            // 
            // chkF9Hud
            // 
            this.chkF9Hud.AutoSize = true;
            this.chkF9Hud.Location = new System.Drawing.Point(18, 20);
            this.chkF9Hud.Name = "chkF9Hud";
            this.chkF9Hud.Size = new System.Drawing.Size(163, 17);
            this.chkF9Hud.TabIndex = 31;
            this.chkF9Hud.Text = "Assign F9 to Show/Hide HUD";
            this.chkF9Hud.UseVisualStyleBackColor = true;
            // 
            // chkF12Fps
            // 
            this.chkF12Fps.AutoSize = true;
            this.chkF12Fps.Location = new System.Drawing.Point(18, 119);
            this.chkF12Fps.Name = "chkF12Fps";
            this.chkF12Fps.Size = new System.Drawing.Size(166, 17);
            this.chkF12Fps.TabIndex = 30;
            this.chkF12Fps.Text = "Assign F12 to Show/Hide FPS";
            this.chkF12Fps.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Degrees";
            // 
            // txtF11Fov
            // 
            this.txtF11Fov.Location = new System.Drawing.Point(71, 88);
            this.txtF11Fov.Name = "txtF11Fov";
            this.txtF11Fov.Size = new System.Drawing.Size(43, 21);
            this.txtF11Fov.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "F11 FOV:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Degrees";
            // 
            // txtF10Fov
            // 
            this.txtF10Fov.Location = new System.Drawing.Point(71, 62);
            this.txtF10Fov.Name = "txtF10Fov";
            this.txtF10Fov.Size = new System.Drawing.Size(43, 21);
            this.txtF10Fov.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "F10 FOV:";
            // 
            // chkScrollWheel
            // 
            this.chkScrollWheel.AutoSize = true;
            this.chkScrollWheel.Location = new System.Drawing.Point(18, 234);
            this.chkScrollWheel.Name = "chkScrollWheel";
            this.chkScrollWheel.Size = new System.Drawing.Size(153, 17);
            this.chkScrollWheel.TabIndex = 29;
            this.chkScrollWheel.Text = "Enable Mouse Scroll Wheel";
            this.chkScrollWheel.UseVisualStyleBackColor = true;
            // 
            // chkZoomToggle
            // 
            this.chkZoomToggle.AutoSize = true;
            this.chkZoomToggle.Location = new System.Drawing.Point(18, 211);
            this.chkZoomToggle.Name = "chkZoomToggle";
            this.chkZoomToggle.Size = new System.Drawing.Size(129, 17);
            this.chkZoomToggle.TabIndex = 28;
            this.chkZoomToggle.Text = "Make Zoom Togglable";
            this.chkZoomToggle.UseVisualStyleBackColor = true;
            // 
            // chkConsole
            // 
            this.chkConsole.AutoSize = true;
            this.chkConsole.Location = new System.Drawing.Point(18, 257);
            this.chkConsole.Name = "chkConsole";
            this.chkConsole.Size = new System.Drawing.Size(99, 17);
            this.chkConsole.TabIndex = 27;
            this.chkConsole.Text = "Enable Console";
            this.chkConsole.UseVisualStyleBackColor = true;
            // 
            // chkDisablevchat
            // 
            this.chkDisablevchat.AutoSize = true;
            this.chkDisablevchat.Location = new System.Drawing.Point(18, 165);
            this.chkDisablevchat.Name = "chkDisablevchat";
            this.chkDisablevchat.Size = new System.Drawing.Size(155, 17);
            this.chkDisablevchat.TabIndex = 26;
            this.chkDisablevchat.Text = "Disable in-game Voice Chat";
            this.chkDisablevchat.UseVisualStyleBackColor = true;
            // 
            // chkDisableMouseSmooth
            // 
            this.chkDisableMouseSmooth.AutoSize = true;
            this.chkDisableMouseSmooth.Location = new System.Drawing.Point(18, 142);
            this.chkDisableMouseSmooth.Name = "chkDisableMouseSmooth";
            this.chkDisableMouseSmooth.Size = new System.Drawing.Size(147, 17);
            this.chkDisableMouseSmooth.TabIndex = 25;
            this.chkDisableMouseSmooth.Text = "Disable Mouse Smoothing";
            this.chkDisableMouseSmooth.UseVisualStyleBackColor = true;
            // 
            // chkFOVAdjust
            // 
            this.chkFOVAdjust.AutoSize = true;
            this.chkFOVAdjust.Location = new System.Drawing.Point(18, 43);
            this.chkFOVAdjust.Name = "chkFOVAdjust";
            this.chkFOVAdjust.Size = new System.Drawing.Size(170, 17);
            this.chkFOVAdjust.TabIndex = 18;
            this.chkFOVAdjust.Text = "Assign F10/F11 to Adjust FOV";
            this.chkFOVAdjust.UseVisualStyleBackColor = true;
            this.chkFOVAdjust.CheckedChanged += new System.EventHandler(this.chkFOVAdjust_CheckedChanged);
            // 
            // grpGraphic
            // 
            this.grpGraphic.Controls.Add(this.chkOutlines);
            this.grpGraphic.Controls.Add(this.label8);
            this.grpGraphic.Controls.Add(this.chkSmoothFrameRate);
            this.grpGraphic.Controls.Add(this.txtScreenPercentage);
            this.grpGraphic.Controls.Add(this.label3);
            this.grpGraphic.Controls.Add(this.label2);
            this.grpGraphic.Controls.Add(this.txtHeight);
            this.grpGraphic.Controls.Add(this.txtWidth);
            this.grpGraphic.Controls.Add(this.label1);
            this.grpGraphic.Controls.Add(this.lblMaxAA);
            this.grpGraphic.Controls.Add(this.trkMaxAA);
            this.grpGraphic.Controls.Add(this.lblMaxAnsio);
            this.grpGraphic.Controls.Add(this.trkMaxAnsio);
            this.grpGraphic.Controls.Add(this.chkDisableStartup);
            this.grpGraphic.Controls.Add(this.chkPhysX);
            this.grpGraphic.Controls.Add(this.chkVsync);
            this.grpGraphic.Controls.Add(this.chkHBloom);
            this.grpGraphic.Controls.Add(this.chkAmbient);
            this.grpGraphic.Controls.Add(this.trkPlayerInfoMaxDist);
            this.grpGraphic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpGraphic.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGraphic.ForeColor = System.Drawing.Color.White;
            this.grpGraphic.Location = new System.Drawing.Point(12, 3);
            this.grpGraphic.Name = "grpGraphic";
            this.grpGraphic.Size = new System.Drawing.Size(217, 349);
            this.grpGraphic.TabIndex = 31;
            this.grpGraphic.TabStop = false;
            this.grpGraphic.Text = "Graphic Settings";
            // 
            // chkOutlines
            // 
            this.chkOutlines.AutoSize = true;
            this.chkOutlines.Location = new System.Drawing.Point(17, 66);
            this.chkOutlines.Name = "chkOutlines";
            this.chkOutlines.Size = new System.Drawing.Size(102, 17);
            this.chkOutlines.TabIndex = 20;
            this.chkOutlines.Text = "Disable Outlines";
            this.chkOutlines.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Loot view Distance:";
            // 
            // chkSmoothFrameRate
            // 
            this.chkSmoothFrameRate.AutoSize = true;
            this.chkSmoothFrameRate.Location = new System.Drawing.Point(17, 111);
            this.chkSmoothFrameRate.Name = "chkSmoothFrameRate";
            this.chkSmoothFrameRate.Size = new System.Drawing.Size(189, 17);
            this.chkSmoothFrameRate.TabIndex = 17;
            this.chkSmoothFrameRate.Text = "Smooth Frame Rate (62 FPS Limit)";
            this.chkSmoothFrameRate.UseVisualStyleBackColor = true;
            // 
            // txtScreenPercentage
            // 
            this.txtScreenPercentage.Location = new System.Drawing.Point(149, 305);
            this.txtScreenPercentage.Name = "txtScreenPercentage";
            this.txtScreenPercentage.Size = new System.Drawing.Size(43, 21);
            this.txtScreenPercentage.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Screen Percentage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "x";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(149, 278);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(43, 21);
            this.txtHeight.TabIndex = 14;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(81, 278);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(43, 21);
            this.txtWidth.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Resolution:";
            // 
            // lblMaxAA
            // 
            this.lblMaxAA.AutoSize = true;
            this.lblMaxAA.Location = new System.Drawing.Point(14, 246);
            this.lblMaxAA.Name = "lblMaxAA";
            this.lblMaxAA.Size = new System.Drawing.Size(92, 13);
            this.lblMaxAA.TabIndex = 9;
            this.lblMaxAA.Text = "Max Anti Aliasing:";
            // 
            // trkMaxAA
            // 
            this.trkMaxAA.Location = new System.Drawing.Point(128, 246);
            this.trkMaxAA.Maximum = 4;
            this.trkMaxAA.Name = "trkMaxAA";
            this.trkMaxAA.Size = new System.Drawing.Size(83, 45);
            this.trkMaxAA.TabIndex = 10;
            this.trkMaxAA.Scroll += new System.EventHandler(this.trkMaxAA_Scroll);
            // 
            // lblMaxAnsio
            // 
            this.lblMaxAnsio.AutoSize = true;
            this.lblMaxAnsio.Location = new System.Drawing.Point(14, 214);
            this.lblMaxAnsio.Name = "lblMaxAnsio";
            this.lblMaxAnsio.Size = new System.Drawing.Size(101, 13);
            this.lblMaxAnsio.TabIndex = 7;
            this.lblMaxAnsio.Text = "Max Aniso Filtering:";
            // 
            // trkMaxAnsio
            // 
            this.trkMaxAnsio.Location = new System.Drawing.Point(128, 214);
            this.trkMaxAnsio.Maximum = 4;
            this.trkMaxAnsio.Name = "trkMaxAnsio";
            this.trkMaxAnsio.Size = new System.Drawing.Size(83, 45);
            this.trkMaxAnsio.TabIndex = 8;
            this.trkMaxAnsio.Scroll += new System.EventHandler(this.trkMaxAniso_Scroll);
            // 
            // chkDisableStartup
            // 
            this.chkDisableStartup.AutoSize = true;
            this.chkDisableStartup.Location = new System.Drawing.Point(17, 134);
            this.chkDisableStartup.Name = "chkDisableStartup";
            this.chkDisableStartup.Size = new System.Drawing.Size(131, 17);
            this.chkDisableStartup.TabIndex = 6;
            this.chkDisableStartup.Text = "Disable Starup Movies";
            this.chkDisableStartup.UseVisualStyleBackColor = true;
            // 
            // chkPhysX
            // 
            this.chkPhysX.AutoSize = true;
            this.chkPhysX.Location = new System.Drawing.Point(17, 157);
            this.chkPhysX.Name = "chkPhysX";
            this.chkPhysX.Size = new System.Drawing.Size(90, 17);
            this.chkPhysX.TabIndex = 5;
            this.chkPhysX.Text = "Enable PhysX";
            this.chkPhysX.UseVisualStyleBackColor = true;
            // 
            // chkVsync
            // 
            this.chkVsync.AutoSize = true;
            this.chkVsync.Location = new System.Drawing.Point(17, 88);
            this.chkVsync.Name = "chkVsync";
            this.chkVsync.Size = new System.Drawing.Size(140, 17);
            this.chkVsync.TabIndex = 4;
            this.chkVsync.Text = "V-Sync (Recommended)";
            this.chkVsync.UseVisualStyleBackColor = true;
            this.chkVsync.CheckedChanged += new System.EventHandler(this.chkVsync_CheckedChanged);
            // 
            // chkHBloom
            // 
            this.chkHBloom.AutoSize = true;
            this.chkHBloom.Location = new System.Drawing.Point(17, 43);
            this.chkHBloom.Name = "chkHBloom";
            this.chkHBloom.Size = new System.Drawing.Size(115, 17);
            this.chkHBloom.TabIndex = 3;
            this.chkHBloom.Text = "High Quality Bloom";
            this.chkHBloom.UseVisualStyleBackColor = true;
            // 
            // chkAmbient
            // 
            this.chkAmbient.AutoSize = true;
            this.chkAmbient.Location = new System.Drawing.Point(17, 20);
            this.chkAmbient.Name = "chkAmbient";
            this.chkAmbient.Size = new System.Drawing.Size(113, 17);
            this.chkAmbient.TabIndex = 2;
            this.chkAmbient.Text = "Ambient Occlusion";
            this.chkAmbient.UseVisualStyleBackColor = true;
            // 
            // trkPlayerInfoMaxDist
            // 
            this.trkPlayerInfoMaxDist.LargeChange = 1000;
            this.trkPlayerInfoMaxDist.Location = new System.Drawing.Point(128, 179);
            this.trkPlayerInfoMaxDist.Maximum = 60000;
            this.trkPlayerInfoMaxDist.Minimum = 15000;
            this.trkPlayerInfoMaxDist.Name = "trkPlayerInfoMaxDist";
            this.trkPlayerInfoMaxDist.Size = new System.Drawing.Size(83, 45);
            this.trkPlayerInfoMaxDist.SmallChange = 100;
            this.trkPlayerInfoMaxDist.TabIndex = 19;
            this.trkPlayerInfoMaxDist.TickFrequency = 5000;
            this.trkPlayerInfoMaxDist.Value = 15000;
            // 
            // UpdateBackgroundWorker
            // 
            this.UpdateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateBackgroundWorker_DoWork);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bottomPanel.BackgroundImage = global::BorderlandsAdvancedConfig.Properties.Resources.Glacier;
            this.bottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottomPanel.Controls.Add(this.lnkOfficialThread);
            this.bottomPanel.Controls.Add(this.btnAbout);
            this.bottomPanel.Controls.Add(this.btnRestore);
            this.bottomPanel.Controls.Add(this.btnSave);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 508);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(776, 43);
            this.bottomPanel.TabIndex = 33;
            // 
            // lnkOfficialThread
            // 
            this.lnkOfficialThread.AutoSize = true;
            this.lnkOfficialThread.BackColor = System.Drawing.Color.Transparent;
            this.lnkOfficialThread.LinkColor = System.Drawing.Color.PaleGreen;
            this.lnkOfficialThread.Location = new System.Drawing.Point(107, 15);
            this.lnkOfficialThread.Name = "lnkOfficialThread";
            this.lnkOfficialThread.Size = new System.Drawing.Size(53, 13);
            this.lnkOfficialThread.TabIndex = 33;
            this.lnkOfficialThread.TabStop = true;
            this.lnkOfficialThread.Text = "Feedback";
            this.lnkOfficialThread.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOfficialThread_LinkClicked);
            // 
            // btnAbout
            // 
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbout.Location = new System.Drawing.Point(12, 6);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(83, 31);
            this.btnAbout.TabIndex = 32;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRestore.Location = new System.Drawing.Point(510, 6);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(124, 31);
            this.btnRestore.TabIndex = 32;
            this.btnRestore.Text = "Restore Backup";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(640, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 31);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // topPicture
            // 
            this.topPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPicture.Image = ((System.Drawing.Image)(resources.GetObject("topPicture.Image")));
            this.topPicture.Location = new System.Drawing.Point(0, 0);
            this.topPicture.Name = "topPicture";
            this.topPicture.Size = new System.Drawing.Size(776, 150);
            this.topPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.topPicture.TabIndex = 0;
            this.topPicture.TabStop = false;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(776, 551);
            this.Controls.Add(this.midPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPicture);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borderlands Advanced Settings";
            this.midPanel.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpGraphic.ResumeLayout(false);
            this.grpGraphic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMaxAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMaxAnsio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPlayerInfoMaxDist)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox topPicture;
        private System.Windows.Forms.FolderBrowserDialog SettingsDirBrowser;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel midPanel;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtF11Fov;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtF10Fov;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkScrollWheel;
        private System.Windows.Forms.CheckBox chkZoomToggle;
        private System.Windows.Forms.CheckBox chkConsole;
        private System.Windows.Forms.CheckBox chkDisablevchat;
        private System.Windows.Forms.CheckBox chkDisableMouseSmooth;
        private System.Windows.Forms.CheckBox chkFOVAdjust;
        private System.Windows.Forms.GroupBox grpGraphic;
        private System.Windows.Forms.TextBox txtScreenPercentage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxAA;
        private System.Windows.Forms.TrackBar trkMaxAA;
        private System.Windows.Forms.Label lblMaxAnsio;
        private System.Windows.Forms.TrackBar trkMaxAnsio;
        private System.Windows.Forms.CheckBox chkDisableStartup;
        private System.Windows.Forms.CheckBox chkPhysX;
        private System.Windows.Forms.CheckBox chkVsync;
        private System.Windows.Forms.CheckBox chkHBloom;
        private System.Windows.Forms.CheckBox chkAmbient;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.LinkLabel lnkOfficialThread;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox chkF12Fps;
        private System.Windows.Forms.CheckBox chkSmoothFrameRate;
        private System.Windows.Forms.CheckBox chkF9Hud;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trkPlayerInfoMaxDist;
        private System.Windows.Forms.CheckBox chkOutlines;
        private System.ComponentModel.BackgroundWorker UpdateBackgroundWorker;
        private System.Windows.Forms.CheckBox chkCrouchToggle;
    }
}

