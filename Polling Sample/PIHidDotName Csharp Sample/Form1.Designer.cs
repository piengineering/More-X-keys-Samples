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
            this.components = new System.ComponentModel.Container();
            this.BtnEnumerate = new System.Windows.Forms.Button();
            this.CboDevices = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnUnitID = new System.Windows.Forms.Button();
            this.TxtSetUnitID = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCallback = new System.Windows.Forms.Button();
            this.LblUnitID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnPolling = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnumerate
            // 
            this.BtnEnumerate.Location = new System.Drawing.Point(12, 17);
            this.BtnEnumerate.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEnumerate.Name = "BtnEnumerate";
            this.BtnEnumerate.Size = new System.Drawing.Size(98, 22);
            this.BtnEnumerate.TabIndex = 0;
            this.BtnEnumerate.Text = "Enumerate";
            this.BtnEnumerate.UseVisualStyleBackColor = true;
            this.BtnEnumerate.Click += new System.EventHandler(this.BtnEnumerate_Click);
            // 
            // CboDevices
            // 
            this.CboDevices.FormattingEnabled = true;
            this.CboDevices.Location = new System.Drawing.Point(134, 16);
            this.CboDevices.Margin = new System.Windows.Forms.Padding(2);
            this.CboDevices.Name = "CboDevices";
            this.CboDevices.Size = new System.Drawing.Size(358, 21);
            this.CboDevices.TabIndex = 1;
            this.CboDevices.SelectedIndexChanged += new System.EventHandler(this.CboDevices_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 102);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(780, 69);
            this.listBox1.TabIndex = 6;
            // 
            // BtnUnitID
            // 
            this.BtnUnitID.Location = new System.Drawing.Point(12, 199);
            this.BtnUnitID.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUnitID.Name = "BtnUnitID";
            this.BtnUnitID.Size = new System.Drawing.Size(92, 22);
            this.BtnUnitID.TabIndex = 7;
            this.BtnUnitID.Text = "Write Unit ID*";
            this.BtnUnitID.UseVisualStyleBackColor = true;
            this.BtnUnitID.Click += new System.EventHandler(this.BtnUnitID_Click);
            // 
            // TxtSetUnitID
            // 
            this.TxtSetUnitID.Location = new System.Drawing.Point(115, 198);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 262);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
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
            this.BtnCallback.Location = new System.Drawing.Point(12, 64);
            this.BtnCallback.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCallback.Name = "BtnCallback";
            this.BtnCallback.Size = new System.Drawing.Size(119, 22);
            this.BtnCallback.TabIndex = 10;
            this.BtnCallback.Text = "Setup for Callback";
            this.BtnCallback.UseVisualStyleBackColor = true;
            this.BtnCallback.Click += new System.EventHandler(this.BtnCallback_Click);
            // 
            // LblUnitID
            // 
            this.LblUnitID.AutoSize = true;
            this.LblUnitID.Location = new System.Drawing.Point(158, 202);
            this.LblUnitID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUnitID.Name = "LblUnitID";
            this.LblUnitID.Size = new System.Drawing.Size(38, 13);
            this.LblUnitID.TabIndex = 12;
            this.LblUnitID.Text = "unit ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "1. Do this first";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "2. Set for data callback and read data";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(691, 179);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(101, 22);
            this.BtnClear.TabIndex = 23;
            this.BtnClear.Text = "Clear Listbox";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnPolling
            // 
            this.BtnPolling.Location = new System.Drawing.Point(182, 64);
            this.BtnPolling.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPolling.Name = "BtnPolling";
            this.BtnPolling.Size = new System.Drawing.Size(79, 22);
            this.BtnPolling.TabIndex = 25;
            this.BtnPolling.Text = "Start Polling";
            this.BtnPolling.UseVisualStyleBackColor = true;
            this.BtnPolling.Click += new System.EventHandler(this.BtnPolling_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "OR";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 184);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 88;
            this.label13.Text = "3. Write Unit ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 284);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnPolling);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUnitID);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtSetUnitID);
            this.Controls.Add(this.BtnUnitID);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.CboDevices);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "C# X-keys Polling Sample";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEnumerate;
        private System.Windows.Forms.ComboBox CboDevices;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnUnitID;
        private System.Windows.Forms.TextBox TxtSetUnitID;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button BtnCallback;
        private System.Windows.Forms.Label LblUnitID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnPolling;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
    }
}

