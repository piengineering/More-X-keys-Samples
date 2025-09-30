namespace PIHidDotName_Csharp_Sample
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
            this.BtnEnumerate = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnUnitID = new System.Windows.Forms.Button();
            this.TxtSetUnitID = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCallback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnBL = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.BtnDescriptor = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.BtnBLToggle = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnGetDataNow = new System.Windows.Forms.Button();
            this.ChkSuppress = new System.Windows.Forms.CheckBox();
            this.BtnCustom = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.TxtVersion = new System.Windows.Forms.TextBox();
            this.BtnVersion = new System.Windows.Forms.Button();
            this.TxtIntensity2 = new System.Windows.Forms.TextBox();
            this.TxtIntensity = new System.Windows.Forms.TextBox();
            this.lstbxDevices = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnumerate
            // 
            this.BtnEnumerate.Location = new System.Drawing.Point(21, 31);
            this.BtnEnumerate.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEnumerate.Name = "BtnEnumerate";
            this.BtnEnumerate.Size = new System.Drawing.Size(92, 22);
            this.BtnEnumerate.TabIndex = 0;
            this.BtnEnumerate.Text = "Enumerate";
            this.BtnEnumerate.UseVisualStyleBackColor = true;
            this.BtnEnumerate.Click += new System.EventHandler(this.BtnEnumerate_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(18, 159);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(847, 69);
            this.listBox1.TabIndex = 6;
            // 
            // BtnUnitID
            // 
            this.BtnUnitID.Location = new System.Drawing.Point(21, 273);
            this.BtnUnitID.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUnitID.Name = "BtnUnitID";
            this.BtnUnitID.Size = new System.Drawing.Size(92, 22);
            this.BtnUnitID.TabIndex = 7;
            this.BtnUnitID.Text = "Write Unit ID";
            this.BtnUnitID.UseVisualStyleBackColor = true;
            this.BtnUnitID.Click += new System.EventHandler(this.BtnUnitID_Click);
            // 
            // TxtSetUnitID
            // 
            this.TxtSetUnitID.Location = new System.Drawing.Point(122, 274);
            this.TxtSetUnitID.Margin = new System.Windows.Forms.Padding(2);
            this.TxtSetUnitID.Name = "TxtSetUnitID";
            this.TxtSetUnitID.Size = new System.Drawing.Size(30, 20);
            this.TxtSetUnitID.TabIndex = 8;
            this.TxtSetUnitID.Text = "1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(896, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // BtnCallback
            // 
            this.BtnCallback.Location = new System.Drawing.Point(18, 133);
            this.BtnCallback.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCallback.Name = "BtnCallback";
            this.BtnCallback.Size = new System.Drawing.Size(122, 22);
            this.BtnCallback.TabIndex = 10;
            this.BtnCallback.Text = "Setup for Callback";
            this.BtnCallback.UseVisualStyleBackColor = true;
            this.BtnCallback.Click += new System.EventHandler(this.BtnCallback_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Do this first";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Set for data callback and read data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(772, 133);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 22);
            this.button1.TabIndex = 21;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnBL
            // 
            this.BtnBL.Location = new System.Drawing.Point(81, 329);
            this.BtnBL.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBL.Name = "BtnBL";
            this.BtnBL.Size = new System.Drawing.Size(92, 22);
            this.BtnBL.TabIndex = 22;
            this.BtnBL.Text = "Set Intensity";
            this.BtnBL.UseVisualStyleBackColor = true;
            this.BtnBL.Click += new System.EventHandler(this.BtnBL_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 479);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 61;
            this.label21.Text = "Descriptor";
            // 
            // BtnDescriptor
            // 
            this.BtnDescriptor.Location = new System.Drawing.Point(21, 496);
            this.BtnDescriptor.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDescriptor.Name = "BtnDescriptor";
            this.BtnDescriptor.Size = new System.Drawing.Size(92, 22);
            this.BtnDescriptor.TabIndex = 62;
            this.BtnDescriptor.Text = "Descriptor";
            this.BtnDescriptor.UseVisualStyleBackColor = true;
            this.BtnDescriptor.Click += new System.EventHandler(this.BtnDescriptor_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(124, 496);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(232, 82);
            this.listBox2.TabIndex = 63;
            // 
            // BtnBLToggle
            // 
            this.BtnBLToggle.Location = new System.Drawing.Point(21, 329);
            this.BtnBLToggle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBLToggle.Name = "BtnBLToggle";
            this.BtnBLToggle.Size = new System.Drawing.Size(54, 22);
            this.BtnBLToggle.TabIndex = 70;
            this.BtnBLToggle.Text = "Toggle";
            this.BtnBLToggle.UseVisualStyleBackColor = true;
            this.BtnBLToggle.Click += new System.EventHandler(this.BtnBLToggle_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 248);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 87;
            this.label13.Text = "Write Unit ID";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 304);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 13);
            this.label17.TabIndex = 119;
            this.label17.Text = "Global Backlight Features";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 366);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(339, 13);
            this.label14.TabIndex = 120;
            this.label14.Text = "Stimulate a general incoming data report or send a custom input report.";
            // 
            // BtnGetDataNow
            // 
            this.BtnGetDataNow.Location = new System.Drawing.Point(21, 384);
            this.BtnGetDataNow.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGetDataNow.Name = "BtnGetDataNow";
            this.BtnGetDataNow.Size = new System.Drawing.Size(98, 22);
            this.BtnGetDataNow.TabIndex = 121;
            this.BtnGetDataNow.Text = "Generate Data";
            this.BtnGetDataNow.UseVisualStyleBackColor = true;
            this.BtnGetDataNow.Click += new System.EventHandler(this.BtnGetDataNow_Click);
            // 
            // ChkSuppress
            // 
            this.ChkSuppress.AutoSize = true;
            this.ChkSuppress.Location = new System.Drawing.Point(145, 137);
            this.ChkSuppress.Name = "ChkSuppress";
            this.ChkSuppress.Size = new System.Drawing.Size(158, 17);
            this.ChkSuppress.TabIndex = 152;
            this.ChkSuppress.Text = "Suppress Duplicate Reports";
            this.ChkSuppress.UseVisualStyleBackColor = true;
            this.ChkSuppress.CheckedChanged += new System.EventHandler(this.ChkSuppress_CheckedChanged);
            // 
            // BtnCustom
            // 
            this.BtnCustom.Location = new System.Drawing.Point(132, 384);
            this.BtnCustom.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCustom.Name = "BtnCustom";
            this.BtnCustom.Size = new System.Drawing.Size(92, 22);
            this.BtnCustom.TabIndex = 259;
            this.BtnCustom.Text = "Custom Data";
            this.BtnCustom.UseVisualStyleBackColor = true;
            this.BtnCustom.Click += new System.EventHandler(this.BtnCustom_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(8, 420);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(195, 13);
            this.label43.TabIndex = 279;
            this.label43.Text = "Write Version (0-65535), reboot required";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(178, 447);
            this.LblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(41, 13);
            this.LblVersion.TabIndex = 278;
            this.LblVersion.Text = "version";
            // 
            // TxtVersion
            // 
            this.TxtVersion.Location = new System.Drawing.Point(124, 442);
            this.TxtVersion.Margin = new System.Windows.Forms.Padding(2);
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.Size = new System.Drawing.Size(49, 20);
            this.TxtVersion.TabIndex = 277;
            this.TxtVersion.Text = "100";
            // 
            // BtnVersion
            // 
            this.BtnVersion.Location = new System.Drawing.Point(21, 440);
            this.BtnVersion.Margin = new System.Windows.Forms.Padding(2);
            this.BtnVersion.Name = "BtnVersion";
            this.BtnVersion.Size = new System.Drawing.Size(92, 22);
            this.BtnVersion.TabIndex = 276;
            this.BtnVersion.Text = "Write Version";
            this.BtnVersion.UseVisualStyleBackColor = true;
            this.BtnVersion.Click += new System.EventHandler(this.BtnVersion_Click);
            // 
            // TxtIntensity2
            // 
            this.TxtIntensity2.Location = new System.Drawing.Point(211, 331);
            this.TxtIntensity2.Margin = new System.Windows.Forms.Padding(2);
            this.TxtIntensity2.Name = "TxtIntensity2";
            this.TxtIntensity2.Size = new System.Drawing.Size(30, 20);
            this.TxtIntensity2.TabIndex = 293;
            this.TxtIntensity2.Text = "255";
            // 
            // TxtIntensity
            // 
            this.TxtIntensity.Location = new System.Drawing.Point(177, 331);
            this.TxtIntensity.Margin = new System.Windows.Forms.Padding(2);
            this.TxtIntensity.Name = "TxtIntensity";
            this.TxtIntensity.Size = new System.Drawing.Size(30, 20);
            this.TxtIntensity.TabIndex = 292;
            this.TxtIntensity.Text = "255";
            // 
            // lstbxDevices
            // 
            this.lstbxDevices.FormattingEnabled = true;
            this.lstbxDevices.Location = new System.Drawing.Point(118, 31);
            this.lstbxDevices.Name = "lstbxDevices";
            this.lstbxDevices.Size = new System.Drawing.Size(380, 69);
            this.lstbxDevices.TabIndex = 300;
            this.lstbxDevices.SelectedIndexChanged += new System.EventHandler(this.lstbxDevices_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 13);
            this.label3.TabIndex = 301;
            this.label3.Text = "Select device to send output reports to";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(896, 622);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstbxDevices);
            this.Controls.Add(this.TxtIntensity2);
            this.Controls.Add(this.TxtIntensity);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.TxtVersion);
            this.Controls.Add(this.BtnVersion);
            this.Controls.Add(this.BtnCustom);
            this.Controls.Add(this.ChkSuppress);
            this.Controls.Add(this.BtnGetDataNow);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BtnBLToggle);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.BtnDescriptor);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.BtnBL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtSetUnitID);
            this.Controls.Add(this.BtnUnitID);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "C# X-keys Multi Unit Sample";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEnumerate;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnUnitID;
        private System.Windows.Forms.TextBox TxtSetUnitID;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button BtnCallback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnBL;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button BtnDescriptor;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button BtnBLToggle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BtnGetDataNow;
        private System.Windows.Forms.CheckBox ChkSuppress;
        private System.Windows.Forms.Button BtnCustom;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.TextBox TxtVersion;
        private System.Windows.Forms.Button BtnVersion;
        private System.Windows.Forms.TextBox TxtIntensity2;
        private System.Windows.Forms.TextBox TxtIntensity;
        private System.Windows.Forms.ListBox lstbxDevices;
        private System.Windows.Forms.Label label3;
    }
}

