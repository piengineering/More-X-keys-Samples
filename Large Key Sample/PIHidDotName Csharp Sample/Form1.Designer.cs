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
            this.CboDevices = new System.Windows.Forms.ComboBox();
            this.LblSwitchPos = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCallback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ChkFRedLED = new System.Windows.Forms.CheckBox();
            this.ChkFGreenLED = new System.Windows.Forms.CheckBox();
            this.ChkRedLED = new System.Windows.Forms.CheckBox();
            this.ChkGreenLED = new System.Windows.Forms.CheckBox();
            this.ChkSuppress = new System.Windows.Forms.CheckBox();
            this.BtnKey1 = new System.Windows.Forms.Button();
            this.BtnKey13 = new System.Windows.Forms.Button();
            this.BtnKey14 = new System.Windows.Forms.Button();
            this.BtnKey20 = new System.Windows.Forms.Button();
            this.BtnKey19 = new System.Windows.Forms.Button();
            this.BtnKey3 = new System.Windows.Forms.Button();
            this.BtnKey10 = new System.Windows.Forms.Button();
            this.BtnKey9 = new System.Windows.Forms.Button();
            this.BtnKey22 = new System.Windows.Forms.Button();
            this.BtnKey21 = new System.Windows.Forms.Button();
            this.BtnKey16 = new System.Windows.Forms.Button();
            this.BtnKey15 = new System.Windows.Forms.Button();
            this.BtnKey23 = new System.Windows.Forms.Button();
            this.BtnKey17 = new System.Windows.Forms.Button();
            this.BtnKey5 = new System.Windows.Forms.Button();
            this.BtnKey24 = new System.Windows.Forms.Button();
            this.BtnKey18 = new System.Windows.Forms.Button();
            this.BtnKey12 = new System.Windows.Forms.Button();
            this.BtnKey6 = new System.Windows.Forms.Button();
            this.LblDTime = new System.Windows.Forms.Label();
            this.LblATime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblDTime2 = new System.Windows.Forms.Label();
            this.LblATime2 = new System.Windows.Forms.Label();
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
            // CboDevices
            // 
            this.CboDevices.FormattingEnabled = true;
            this.CboDevices.Location = new System.Drawing.Point(116, 32);
            this.CboDevices.Margin = new System.Windows.Forms.Padding(2);
            this.CboDevices.Name = "CboDevices";
            this.CboDevices.Size = new System.Drawing.Size(376, 21);
            this.CboDevices.TabIndex = 1;
            this.CboDevices.SelectedIndexChanged += new System.EventHandler(this.CboDevices_SelectedIndexChanged);
            // 
            // LblSwitchPos
            // 
            this.LblSwitchPos.Location = new System.Drawing.Point(21, 199);
            this.LblSwitchPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblSwitchPos.Name = "LblSwitchPos";
            this.LblSwitchPos.Size = new System.Drawing.Size(104, 14);
            this.LblSwitchPos.TabIndex = 5;
            this.LblSwitchPos.Text = "Switch Position";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(21, 118);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(480, 69);
            this.listBox1.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 381);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(725, 22);
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
            this.BtnCallback.Location = new System.Drawing.Point(21, 92);
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
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "1. Do this first";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "2. Set for data callback and read data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 230);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "3. LED Control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 22);
            this.button1.TabIndex = 21;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChkFRedLED
            // 
            this.ChkFRedLED.AutoSize = true;
            this.ChkFRedLED.Location = new System.Drawing.Point(238, 261);
            this.ChkFRedLED.Margin = new System.Windows.Forms.Padding(2);
            this.ChkFRedLED.Name = "ChkFRedLED";
            this.ChkFRedLED.Size = new System.Drawing.Size(98, 17);
            this.ChkFRedLED.TabIndex = 102;
            this.ChkFRedLED.Text = "Flash Red LED";
            this.ChkFRedLED.UseVisualStyleBackColor = true;
            // 
            // ChkFGreenLED
            // 
            this.ChkFGreenLED.AutoSize = true;
            this.ChkFGreenLED.Location = new System.Drawing.Point(146, 261);
            this.ChkFGreenLED.Margin = new System.Windows.Forms.Padding(2);
            this.ChkFGreenLED.Name = "ChkFGreenLED";
            this.ChkFGreenLED.Size = new System.Drawing.Size(83, 17);
            this.ChkFGreenLED.TabIndex = 101;
            this.ChkFGreenLED.Text = "Flash Green";
            this.ChkFGreenLED.UseVisualStyleBackColor = true;
            // 
            // ChkRedLED
            // 
            this.ChkRedLED.AutoSize = true;
            this.ChkRedLED.Location = new System.Drawing.Point(88, 261);
            this.ChkRedLED.Margin = new System.Windows.Forms.Padding(2);
            this.ChkRedLED.Name = "ChkRedLED";
            this.ChkRedLED.Size = new System.Drawing.Size(46, 17);
            this.ChkRedLED.TabIndex = 100;
            this.ChkRedLED.Text = "Red";
            this.ChkRedLED.UseVisualStyleBackColor = true;
            this.ChkRedLED.CheckedChanged += new System.EventHandler(this.ChkRedLED_CheckedChanged);
            // 
            // ChkGreenLED
            // 
            this.ChkGreenLED.AutoSize = true;
            this.ChkGreenLED.Location = new System.Drawing.Point(21, 261);
            this.ChkGreenLED.Margin = new System.Windows.Forms.Padding(2);
            this.ChkGreenLED.Name = "ChkGreenLED";
            this.ChkGreenLED.Size = new System.Drawing.Size(55, 17);
            this.ChkGreenLED.TabIndex = 99;
            this.ChkGreenLED.Text = "Green";
            this.ChkGreenLED.UseVisualStyleBackColor = true;
            this.ChkGreenLED.CheckedChanged += new System.EventHandler(this.ChkGreenLED_CheckedChanged);
            // 
            // ChkSuppress
            // 
            this.ChkSuppress.AutoSize = true;
            this.ChkSuppress.Location = new System.Drawing.Point(148, 96);
            this.ChkSuppress.Name = "ChkSuppress";
            this.ChkSuppress.Size = new System.Drawing.Size(158, 17);
            this.ChkSuppress.TabIndex = 152;
            this.ChkSuppress.Text = "Suppress Duplicate Reports";
            this.ChkSuppress.UseVisualStyleBackColor = true;
            this.ChkSuppress.CheckedChanged += new System.EventHandler(this.ChkSuppress_CheckedChanged);
            // 
            // BtnKey1
            // 
            this.BtnKey1.Location = new System.Drawing.Point(521, 27);
            this.BtnKey1.Name = "BtnKey1";
            this.BtnKey1.Size = new System.Drawing.Size(90, 90);
            this.BtnKey1.TabIndex = 153;
            this.BtnKey1.Text = "1";
            this.BtnKey1.UseVisualStyleBackColor = true;
            // 
            // BtnKey13
            // 
            this.BtnKey13.Location = new System.Drawing.Point(617, 27);
            this.BtnKey13.Name = "BtnKey13";
            this.BtnKey13.Size = new System.Drawing.Size(42, 42);
            this.BtnKey13.TabIndex = 154;
            this.BtnKey13.Text = "13";
            this.BtnKey13.UseVisualStyleBackColor = true;
            // 
            // BtnKey14
            // 
            this.BtnKey14.Location = new System.Drawing.Point(617, 75);
            this.BtnKey14.Name = "BtnKey14";
            this.BtnKey14.Size = new System.Drawing.Size(42, 42);
            this.BtnKey14.TabIndex = 155;
            this.BtnKey14.Text = "14";
            this.BtnKey14.UseVisualStyleBackColor = true;
            // 
            // BtnKey20
            // 
            this.BtnKey20.Location = new System.Drawing.Point(665, 75);
            this.BtnKey20.Name = "BtnKey20";
            this.BtnKey20.Size = new System.Drawing.Size(42, 42);
            this.BtnKey20.TabIndex = 157;
            this.BtnKey20.Text = "20";
            this.BtnKey20.UseVisualStyleBackColor = true;
            // 
            // BtnKey19
            // 
            this.BtnKey19.Location = new System.Drawing.Point(665, 27);
            this.BtnKey19.Name = "BtnKey19";
            this.BtnKey19.Size = new System.Drawing.Size(42, 42);
            this.BtnKey19.TabIndex = 156;
            this.BtnKey19.Text = "19";
            this.BtnKey19.UseVisualStyleBackColor = true;
            // 
            // BtnKey3
            // 
            this.BtnKey3.Location = new System.Drawing.Point(521, 123);
            this.BtnKey3.Name = "BtnKey3";
            this.BtnKey3.Size = new System.Drawing.Size(42, 90);
            this.BtnKey3.TabIndex = 158;
            this.BtnKey3.Text = "3";
            this.BtnKey3.UseVisualStyleBackColor = true;
            // 
            // BtnKey10
            // 
            this.BtnKey10.Location = new System.Drawing.Point(569, 171);
            this.BtnKey10.Name = "BtnKey10";
            this.BtnKey10.Size = new System.Drawing.Size(42, 42);
            this.BtnKey10.TabIndex = 160;
            this.BtnKey10.Text = "10";
            this.BtnKey10.UseVisualStyleBackColor = true;
            // 
            // BtnKey9
            // 
            this.BtnKey9.Location = new System.Drawing.Point(569, 123);
            this.BtnKey9.Name = "BtnKey9";
            this.BtnKey9.Size = new System.Drawing.Size(42, 42);
            this.BtnKey9.TabIndex = 159;
            this.BtnKey9.Text = "9";
            this.BtnKey9.UseVisualStyleBackColor = true;
            // 
            // BtnKey22
            // 
            this.BtnKey22.Location = new System.Drawing.Point(665, 171);
            this.BtnKey22.Name = "BtnKey22";
            this.BtnKey22.Size = new System.Drawing.Size(42, 42);
            this.BtnKey22.TabIndex = 164;
            this.BtnKey22.Text = "22";
            this.BtnKey22.UseVisualStyleBackColor = true;
            // 
            // BtnKey21
            // 
            this.BtnKey21.Location = new System.Drawing.Point(665, 123);
            this.BtnKey21.Name = "BtnKey21";
            this.BtnKey21.Size = new System.Drawing.Size(42, 42);
            this.BtnKey21.TabIndex = 163;
            this.BtnKey21.Text = "21";
            this.BtnKey21.UseVisualStyleBackColor = true;
            // 
            // BtnKey16
            // 
            this.BtnKey16.Location = new System.Drawing.Point(617, 171);
            this.BtnKey16.Name = "BtnKey16";
            this.BtnKey16.Size = new System.Drawing.Size(42, 42);
            this.BtnKey16.TabIndex = 162;
            this.BtnKey16.Text = "16";
            this.BtnKey16.UseVisualStyleBackColor = true;
            // 
            // BtnKey15
            // 
            this.BtnKey15.Location = new System.Drawing.Point(617, 123);
            this.BtnKey15.Name = "BtnKey15";
            this.BtnKey15.Size = new System.Drawing.Size(42, 42);
            this.BtnKey15.TabIndex = 161;
            this.BtnKey15.Text = "15";
            this.BtnKey15.UseVisualStyleBackColor = true;
            // 
            // BtnKey23
            // 
            this.BtnKey23.Location = new System.Drawing.Point(665, 219);
            this.BtnKey23.Name = "BtnKey23";
            this.BtnKey23.Size = new System.Drawing.Size(42, 42);
            this.BtnKey23.TabIndex = 166;
            this.BtnKey23.Text = "23";
            this.BtnKey23.UseVisualStyleBackColor = true;
            // 
            // BtnKey17
            // 
            this.BtnKey17.Location = new System.Drawing.Point(617, 219);
            this.BtnKey17.Name = "BtnKey17";
            this.BtnKey17.Size = new System.Drawing.Size(42, 42);
            this.BtnKey17.TabIndex = 165;
            this.BtnKey17.Text = "17";
            this.BtnKey17.UseVisualStyleBackColor = true;
            // 
            // BtnKey5
            // 
            this.BtnKey5.Location = new System.Drawing.Point(521, 219);
            this.BtnKey5.Name = "BtnKey5";
            this.BtnKey5.Size = new System.Drawing.Size(90, 42);
            this.BtnKey5.TabIndex = 167;
            this.BtnKey5.Text = "5";
            this.BtnKey5.UseVisualStyleBackColor = true;
            // 
            // BtnKey24
            // 
            this.BtnKey24.Location = new System.Drawing.Point(665, 267);
            this.BtnKey24.Name = "BtnKey24";
            this.BtnKey24.Size = new System.Drawing.Size(42, 42);
            this.BtnKey24.TabIndex = 168;
            this.BtnKey24.Text = "24";
            this.BtnKey24.UseVisualStyleBackColor = true;
            // 
            // BtnKey18
            // 
            this.BtnKey18.Location = new System.Drawing.Point(617, 267);
            this.BtnKey18.Name = "BtnKey18";
            this.BtnKey18.Size = new System.Drawing.Size(42, 42);
            this.BtnKey18.TabIndex = 171;
            this.BtnKey18.Text = "18";
            this.BtnKey18.UseVisualStyleBackColor = true;
            // 
            // BtnKey12
            // 
            this.BtnKey12.Location = new System.Drawing.Point(569, 267);
            this.BtnKey12.Name = "BtnKey12";
            this.BtnKey12.Size = new System.Drawing.Size(42, 42);
            this.BtnKey12.TabIndex = 170;
            this.BtnKey12.Text = "12";
            this.BtnKey12.UseVisualStyleBackColor = true;
            // 
            // BtnKey6
            // 
            this.BtnKey6.Location = new System.Drawing.Point(521, 267);
            this.BtnKey6.Name = "BtnKey6";
            this.BtnKey6.Size = new System.Drawing.Size(42, 42);
            this.BtnKey6.TabIndex = 169;
            this.BtnKey6.Text = "6";
            this.BtnKey6.UseVisualStyleBackColor = true;
            // 
            // LblDTime
            // 
            this.LblDTime.AutoSize = true;
            this.LblDTime.Location = new System.Drawing.Point(216, 219);
            this.LblDTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDTime.Name = "LblDTime";
            this.LblDTime.Size = new System.Drawing.Size(52, 13);
            this.LblDTime.TabIndex = 173;
            this.LblDTime.Text = "delta time";
            // 
            // LblATime
            // 
            this.LblATime.AutoSize = true;
            this.LblATime.Location = new System.Drawing.Point(216, 200);
            this.LblATime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblATime.Name = "LblATime";
            this.LblATime.Size = new System.Drawing.Size(69, 13);
            this.LblATime.TabIndex = 172;
            this.LblATime.Text = "absolute time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 174;
            this.label4.Text = "Time Stamp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 177;
            this.label5.Text = "Large Key Time Stamp:";
            // 
            // LblDTime2
            // 
            this.LblDTime2.AutoSize = true;
            this.LblDTime2.Location = new System.Drawing.Point(518, 349);
            this.LblDTime2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDTime2.Name = "LblDTime2";
            this.LblDTime2.Size = new System.Drawing.Size(52, 13);
            this.LblDTime2.TabIndex = 176;
            this.LblDTime2.Text = "delta time";
            // 
            // LblATime2
            // 
            this.LblATime2.AutoSize = true;
            this.LblATime2.Location = new System.Drawing.Point(518, 329);
            this.LblATime2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblATime2.Name = "LblATime2";
            this.LblATime2.Size = new System.Drawing.Size(69, 13);
            this.LblATime2.TabIndex = 175;
            this.LblATime2.Text = "absolute time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(725, 403);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblDTime2);
            this.Controls.Add(this.LblATime2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblDTime);
            this.Controls.Add(this.LblATime);
            this.Controls.Add(this.BtnKey18);
            this.Controls.Add(this.BtnKey12);
            this.Controls.Add(this.BtnKey6);
            this.Controls.Add(this.BtnKey24);
            this.Controls.Add(this.BtnKey5);
            this.Controls.Add(this.BtnKey23);
            this.Controls.Add(this.BtnKey17);
            this.Controls.Add(this.BtnKey22);
            this.Controls.Add(this.BtnKey21);
            this.Controls.Add(this.BtnKey16);
            this.Controls.Add(this.BtnKey15);
            this.Controls.Add(this.BtnKey10);
            this.Controls.Add(this.BtnKey9);
            this.Controls.Add(this.BtnKey3);
            this.Controls.Add(this.BtnKey20);
            this.Controls.Add(this.BtnKey19);
            this.Controls.Add(this.BtnKey14);
            this.Controls.Add(this.BtnKey13);
            this.Controls.Add(this.BtnKey1);
            this.Controls.Add(this.ChkSuppress);
            this.Controls.Add(this.ChkFRedLED);
            this.Controls.Add(this.ChkFGreenLED);
            this.Controls.Add(this.ChkRedLED);
            this.Controls.Add(this.ChkGreenLED);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.LblSwitchPos);
            this.Controls.Add(this.CboDevices);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "C# X-keys Large Key Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEnumerate;
        private System.Windows.Forms.ComboBox CboDevices;
        private System.Windows.Forms.Label LblSwitchPos;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button BtnCallback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ChkFRedLED;
        private System.Windows.Forms.CheckBox ChkFGreenLED;
        private System.Windows.Forms.CheckBox ChkRedLED;
        private System.Windows.Forms.CheckBox ChkGreenLED;
        private System.Windows.Forms.CheckBox ChkSuppress;
        private System.Windows.Forms.Button BtnKey1;
        private System.Windows.Forms.Button BtnKey13;
        private System.Windows.Forms.Button BtnKey14;
        private System.Windows.Forms.Button BtnKey20;
        private System.Windows.Forms.Button BtnKey19;
        private System.Windows.Forms.Button BtnKey3;
        private System.Windows.Forms.Button BtnKey10;
        private System.Windows.Forms.Button BtnKey9;
        private System.Windows.Forms.Button BtnKey22;
        private System.Windows.Forms.Button BtnKey21;
        private System.Windows.Forms.Button BtnKey16;
        private System.Windows.Forms.Button BtnKey15;
        private System.Windows.Forms.Button BtnKey23;
        private System.Windows.Forms.Button BtnKey17;
        private System.Windows.Forms.Button BtnKey5;
        private System.Windows.Forms.Button BtnKey24;
        private System.Windows.Forms.Button BtnKey18;
        private System.Windows.Forms.Button BtnKey12;
        private System.Windows.Forms.Button BtnKey6;
        private System.Windows.Forms.Label LblDTime;
        private System.Windows.Forms.Label LblATime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblDTime2;
        private System.Windows.Forms.Label LblATime2;
    }
}

