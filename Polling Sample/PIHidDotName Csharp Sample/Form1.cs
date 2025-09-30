using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using PIEHidDotNet;
using PIEHid32Net;


namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        PIEDevice[] devices;

        int[] cbotodevice = null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        byte[] lastdata = null;
        int selecteddevice = -1; //set to the index of CboDevice
        int singleLED = 0; //indicates whether single LED is running or not
        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        Control c;
        //end thread-safe
       
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnEnumerate_Click(object sender, EventArgs e)
        {
            CboDevices.Items.Clear();
            cbotodevice = new int[128];  //max # devices = 128
            //enumerate and setupinterfaces for all devices
            devices = PIEHid32Net.PIEDevice.EnumeratePIE();
            if (devices.Length == 0)
            {
                toolStripStatusLabel1.Text = "No Devices Found";
            }
            else
            {
                //System.Media.SystemSounds.Beep.Play(); 
                int cbocount = 0; //keeps track of how many valid devices were added to the CboDevice box
                for (int i = 0; i < devices.Length; i++)
                {
                    //information about device
                    //PID = devices[i].Pid);
                    //HID Usage = devices[i].HidUsage);
                    //HID Usage Page = devices[i].HidUsagePage);
                    //HID Version = devices[i].Version); //NOTE: this is NOT the firmware version which is given in the descriptor
                    int hidusagepg = devices[i].HidUsagePage;
                    int hidusage = devices[i].HidUsage;
                    if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength == 36)
                    {
                        switch (devices[i].Pid)
                        {
                            case 1049:
                                CboDevices.Items.Add("XK-16 Stick (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1050:
                                CboDevices.Items.Add("XK-16 Stick (" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1051:
                                CboDevices.Items.Add("XK-16 Stick (" + devices[i].Pid + "=PID #3)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1251:
                                CboDevices.Items.Add("XK-16 Stick (" + devices[i].Pid + "=PID #4)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1127:
                                CboDevices.Items.Add("XK-4 Stick (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1128:
                                CboDevices.Items.Add("XK-4 Stick (" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1129:
                                CboDevices.Items.Add("XK-4 Stick (" + devices[i].Pid + "=PID #3)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1253:
                                CboDevices.Items.Add("XK-4 Stick (" + devices[i].Pid + "=PID #4)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1130:
                                CboDevices.Items.Add("XK-8 Stick (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1131:
                                CboDevices.Items.Add("XK-8 Stick (" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1132:
                                CboDevices.Items.Add("XK-8 Stick (" + devices[i].Pid + "=PID #3)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1252:
                                CboDevices.Items.Add("XK-8 Stick (" + devices[i].Pid + "=PID #4)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            default:
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + ")");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                        }
                        devices[i].SetupInterface();
                        devices[i].suppressDuplicateReports = true;
                    }
                }
            }
            if (CboDevices.Items.Count > 0)
            {
                CboDevices.SelectedIndex = 0;
                selecteddevice = cbotodevice[CboDevices.SelectedIndex];
                wData = new byte[devices[selecteddevice].WriteLength];//go ahead and setup for write
                lastdata = new byte[devices[selecteddevice].ReadLength];
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closeinterfaces on all devices
            for (int i = 0; i < CboDevices.Items.Count; i++)
            {
                devices[cbotodevice[i]].CloseInterface();
            }
            System.Environment.Exit(0);
        }

        private void BtnRed_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnNoLEDS_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnGreen_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void BtnUnitID_Click(object sender, EventArgs e)
        {
            //Write Unit ID to currently selected device
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                //write Unit ID given in the TxtSetUnitID box
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 189;
                wData[2] = (byte)(Convert.ToInt16(TxtSetUnitID.Text));

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write Unit ID";
                }
            }
        }
        private void CboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecteddevice = cbotodevice[CboDevices.SelectedIndex];
            wData = new byte[devices[selecteddevice].WriteLength];//size write array 
        }
        private void BtnCallback_Click(object sender, EventArgs e)
        {
            //setup callback if there are devices found for each device found
            if (CboDevices.SelectedIndex != -1)
            {
                if (CboDevices.SelectedIndex != -1)
                {
                    //turn of polling timer
                    timer1.Enabled = false;
                    BtnPolling.Text = "Start Polling";

                    for (int i = 0; i < CboDevices.Items.Count; i++)
                    {
                        //use the cbotodevice array which contains the mapping of the devices in the CboDevices to the actual device IDs
                        devices[cbotodevice[i]].SetErrorCallback(this);
                        devices[cbotodevice[i]].SetDataCallback(this);
                        devices[cbotodevice[i]].callNever = false;
                    }
                }
            }
        }
        //data callback    
        public void HandlePIEHidData(Byte[] data, PIEDevice sourceDevice, int error)
        {
            //check the sourceDevice and make sure it is the same device as selected in CboDevice   
            if (sourceDevice == devices[selecteddevice])
            {
                //read the unit ID
                c = this.LblUnitID;
                this.SetText(data[1].ToString());

                //write raw data to listbox1 in HEX
                String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                for (int i = 0; i < sourceDevice.ReadLength; i++)
                {
                    output = output + BinToHex(data[i]) + " ";
                }
                this.SetListBox(output);
            }
        }
        //error callback
        public void HandlePIEHidError(PIEDevice sourceDevice, Int32 error)
        {
            this.SetToolStrip("Error: " + error.ToString());
        }
        //for threadsafe setting of Windows Forms control
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.c.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.c.Text = text;
            }
        }
        //for threadsafe setting of Windows Forms control
        private void SetListBox(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetListBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.listBox1.Items.Add(text);
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            }
        }
        //for threadsafe setting of Windows Forms control
        private void SetToolStrip(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.statusStrip1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetToolStrip);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.toolStripStatusLabel1.Text = text;
            }
        }

       

        

        private void BtnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           
        }

        private void BtnPolling_Click(object sender, EventArgs e)
        {
            if (BtnPolling.Text == "Start Polling")
            {
                //turn off callback
                devices[selecteddevice].callNever = true;
                
                timer1.Enabled = true;
                BtnPolling.Text = "Stop Polling";
            }
            else
            {
                timer1.Enabled = false;
                BtnPolling.Text = "Start Polling";
            }


        }
        public static String BinToHex(Byte value)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(value.ToString("X2"));  //the 2 means 2 digits
            return sb.ToString();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //read data
            byte[] data = null;
            while (0 == devices[selecteddevice].ReadData(ref data))
            {
                //handle data
                LblUnitID.Text = data[1].ToString();
                   

                String output = "Polling: " + devices[selecteddevice].Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                for (int i = 0; i < devices[selecteddevice].ReadLength; i++)
                {
                    output = output + BinToHex(data[i]) + " ";
                }
                this.SetListBox(output);
                            
            }
        }
    }
    
}
