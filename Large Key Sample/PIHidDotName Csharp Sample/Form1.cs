using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PIEHid32Net;


namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        PIEDevice[] devices;
        
        int[] cbotodevice=null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        int selecteddevice=-1; //set to the index of CboDevice
        
        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        Control c;
        //end thread-safe

        long saveabsolutetime;  //for timestamp demo
        long saveabsolutetime2;  //for large key timestamp demo

        //large key stuff
        byte lastKey1;
        byte lastKey3;
        byte lastKey5;
        byte lastKey6;
        byte lastKey9;
        byte lastKey10;
        byte lastKey12;
        byte lastKey13;
        byte lastKey14;
        byte lastKey15;
        byte lastKey16;
        byte lastKey17;
        byte lastKey18;
        byte lastKey19;
        byte lastKey20;
        byte lastKey21;
        byte lastKey22;
        byte lastKey23;
        byte lastKey24;

        
       
        public Form1()
        {
            InitializeComponent();
        }

        //data callback    
        public void HandlePIEHidData(Byte[] data, PIEDevice sourceDevice, int error)
        {
            //check the sourceDevice and make sure it is the same device as selected in CboDevice   
            if (sourceDevice == devices[selecteddevice])
            {
                //check the switch byte 
                byte val2 = (byte)(data[2] & 1);
                if (val2 == 0)
                {
                    c = this.LblSwitchPos;
                    this.SetText("switch up");

                }
                else
                {
                    c = this.LblSwitchPos;
                    this.SetText("switch down");

                }

                //write raw data to listbox1 in HEX
                String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                for (int i = 0; i < sourceDevice.ReadLength; i++)
                {
                    output = output + BinToHex(data[i]) + " ";
                }
                this.SetListBox(output);

                //deal with large keys
                //Key 1 has 4 keys; 1, 2, 7, 8
                bool registertimestamp = false; //for large key time stamp
                byte bit0 = (byte)(data[3] & 1);
                byte bit1 = (byte)(data[3] & 2);
                byte bit2 = (byte)(data[4] & 1);
                byte bit3 = (byte)(data[4] & 2);
                byte thisKey1=(byte)(bit0|bit1|bit2|bit3);
                if (thisKey1 != 0 && lastKey1 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey1.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey1 != 0 && thisKey1 == 0) //release
                {
                    BtnKey1.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey1 = thisKey1;

                //Key 3 has 2 keys; 3, 4
                bit0 = (byte)(data[3] & 4);
                bit1 = (byte)(data[3] & 8);
                byte thisKey3 = (byte)(bit0 | bit1);
                if (thisKey3 != 0 && lastKey3 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey3.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey3 != 0 && thisKey3 == 0) //release
                {
                    BtnKey3.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey3 = thisKey3;

                //Key 5 has 2 keys; 5, 11
                bit0 = (byte)(data[3] & 16);
                bit1 = (byte)(data[4] & 16);
                byte thisKey5 = (byte)(bit0 | bit1);
                if (thisKey5 != 0 && lastKey5 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey5.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey5 != 0 && thisKey5 == 0) //release
                {
                    BtnKey5.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey5 = thisKey5;

                //all others are singles
                byte thisKey6 = (byte)(data[3] & 32);
                if (thisKey6 != 0 && lastKey5 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey6.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey6 != 0 && thisKey6 == 0) //release
                {
                    BtnKey6.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey6 = thisKey6;

                byte thisKey9 = (byte)(data[4] & 4);
                if (thisKey9 != 0 && lastKey9 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey9.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey9 != 0 && thisKey9 == 0) //release
                {
                    BtnKey9.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey9 = thisKey9;

                byte thisKey10 = (byte)(data[4] & 8);
                if (thisKey10 != 0 && lastKey10 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey10.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey10 != 0 && thisKey10 == 0) //release
                {
                    BtnKey10.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey10 = thisKey10;

                byte thisKey12 = (byte)(data[4] & 32);
                if (thisKey12 != 0 && lastKey12 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey12.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey12 != 0 && thisKey12 == 0) //release
                {
                    BtnKey12.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey12 = thisKey12;

                byte thisKey13 = (byte)(data[5] & 1);
                if (thisKey13 != 0 && lastKey13 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey13.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey13 != 0 && thisKey13 == 0) //release
                {
                    BtnKey13.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey13 = thisKey13;

                byte thisKey14 = (byte)(data[5] & 2);
                if (thisKey14 != 0 && lastKey14 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey14.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey14 != 0 && thisKey14 == 0) //release
                {
                    BtnKey14.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey14 = thisKey14;

                byte thisKey15 = (byte)(data[5] & 4);
                if (thisKey15 != 0 && lastKey15 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey15.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey15 != 0 && thisKey15 == 0) //release
                {
                    BtnKey15.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey15 = thisKey15;

                byte thisKey16 = (byte)(data[5] & 8);
                if (thisKey16 != 0 && lastKey16 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey16.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey16 != 0 && thisKey16 == 0) //release
                {
                    BtnKey16.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey16 = thisKey16;

                byte thisKey17 = (byte)(data[5] & 16);
                if (thisKey17 != 0 && lastKey17 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey17.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey17 != 0 && thisKey17 == 0) //release
                {
                    BtnKey17.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey17 = thisKey17;

                byte thisKey18 = (byte)(data[5] & 32);
                if (thisKey18 != 0 && lastKey18 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey18.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey18 != 0 && thisKey18 == 0) //release
                {
                    BtnKey18.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey18 = thisKey18;

                byte thisKey19 = (byte)(data[6] & 1);
                if (thisKey19 != 0 && lastKey19 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey19.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey19 != 0 && thisKey19 == 0) //release
                {
                    BtnKey19.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey19 = thisKey19;

                byte thisKey20 = (byte)(data[6] & 2);
                if (thisKey20 != 0 && lastKey20 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey20.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey20 != 0 && thisKey20 == 0) //release
                {
                    BtnKey20.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey20 = thisKey20;

                byte thisKey21 = (byte)(data[6] & 4);
                if (thisKey21 != 0 && lastKey21 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey21.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey21 != 0 && thisKey21 == 0) //release
                {
                    BtnKey21.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey21 = thisKey21;

                byte thisKey22 = (byte)(data[6] & 8);
                if (thisKey22 != 0 && lastKey22 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey22.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey22 != 0 && thisKey22 == 0) //release
                {
                    BtnKey22.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey22 = thisKey22;

                byte thisKey23 = (byte)(data[6] & 16);
                if (thisKey23 != 0 && lastKey23 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey23.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey23 != 0 && thisKey23 == 0) //release
                {
                    BtnKey23.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey23 = thisKey23;

                byte thisKey24 = (byte)(data[6] & 32);
                if (thisKey24 != 0 && lastKey24 == 0) //press
                {
                    System.Media.SystemSounds.Beep.Play();
                    BtnKey24.BackColor = Color.Lime;
                    registertimestamp = true;
                }
                else if (lastKey24 != 0 && thisKey24 == 0) //release
                {
                    BtnKey24.BackColor = SystemColors.Control;
                    registertimestamp = true;
                }
                lastKey24 = thisKey24;

                //Time Stamp
                //time stamp info 4 bytes
                long absolutetime = 16777216 * data[7] + 65536 * data[8] + 256 * data[9] + data[10];  //ms
                long absolutetimesec = absolutetime / 1000; //seconds
                c = this.LblATime;
                this.SetText("absolute time: " + absolutetimesec.ToString() + " s");
                long deltatime = absolutetime - saveabsolutetime;
                c = this.LblDTime;
                this.SetText("delta time: " + deltatime + " ms");
                saveabsolutetime = absolutetime;

                //large key time stamp
                if (registertimestamp == true)
                {
                    c = this.LblATime2;
                    this.SetText("absolute time: " + absolutetimesec.ToString() + " s");
                    deltatime = absolutetime - saveabsolutetime2;
                    c = this.LblDTime2;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime2 = absolutetime;
                    registertimestamp = false;
                }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closeinterfaces on all devices that have been setup (SetupInterface called)
            for (int i = 0; i < CboDevices.Items.Count; i++)
            {
                //if devices[].Connected=false don't call CloseInterface
                devices[cbotodevice[i]].CloseInterface();

            }
            System.Environment.Exit(0);
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
                for (int i = 0; i < CboDevices.Items.Count; i++)
                {
                    //use the cbotodevice array which contains the mapping of the devices in the CboDevices to the actual device IDs
                    devices[cbotodevice[i]].SetErrorCallback(this);
                    devices[cbotodevice[i]].SetDataCallback(this);
                    devices[cbotodevice[i]].callNever = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void BtnEnumerate_Click(object sender, EventArgs e)
        {
            CboDevices.Items.Clear();
            cbotodevice = new int[128]; //128=max # of devices
            //enumerate and setupinterfaces for all devices
            devices = PIEHid32Net.PIEDevice.EnumeratePIE();
            if (devices.Length == 0)
            {
                toolStripStatusLabel1.Text = "No Devices Found";
            }
            else
            {
                //System.Media.SystemSounds.Beep.Play(); 
                int cbocount=0; //keeps track of how many valid devices were added to the CboDevice box
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
                            case 1027:
                                //Device 2 Keyboard, Joystick, Input and Output endpoints, PID #3
                                CboDevices.Items.Add(devices[i].ProductString+" ("+devices[i].Pid+"=PID #3)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1028:
                                //Device 1 Keyboard, Joystick, Mouse and Output endpoints,. PID #2
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1029:
                                //Device 0 Keyboard, Mouse, Input and Output endpoints (factory default), PID #1
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1249:
                                //Device 3 Keyboard, Multimedia, Mouse and Output endpoints, PID #4
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #4)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            default:
                                CboDevices.Items.Add("Unknown Device: " + devices[i].ProductString + " (" + devices[i].Pid + ")");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                        }
                        devices[i].SetupInterface();
                        devices[i].suppressDuplicateReports = false;
                    }
                }
            }
            if (CboDevices.Items.Count > 0)
            {
                CboDevices.SelectedIndex = 0;
                selecteddevice = cbotodevice[CboDevices.SelectedIndex];
                wData = new byte[devices[selecteddevice].WriteLength];//go ahead and setup for write
            }
        }
       
        private void BtnRed_Click(object sender, EventArgs e)
        {
            //Turn on the red LED
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte saveled = wData[2]; //save the current value of the LED byte
                for (int j = 0; j <devices[selecteddevice].WriteLength; j++) 
                {
                    wData[j] = 0;
                }
                wData[1] = 186;
                wData[2] = (byte)(saveled | 128);

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-Red LED";
                }
            }
        }

        private void ChkGreenLED_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1)
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = 6; //6 for green, 7 for red


                if (ChkGreenLED.Checked == true)
                {
                    wData[3] = 1; //0=off, 1=on, 2=flash
                    if (ChkFGreenLED.Checked == true) wData[3] = 2;
                }
                else
                {
                    wData[3] = 0; //0=off, 1=on, 2=flash
                }

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set LED";
                }
            }
        }

        private void ChkRedLED_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1)
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = 7; //6 for green, 7 for red


                if (ChkRedLED.Checked == true)
                {
                    wData[3] = 1; //0=off, 1=on, 2=flash
                    if (ChkFRedLED.Checked == true) wData[3] = 2;
                }
                else
                {
                    wData[3] = 0; //0=off, 1=on, 2=flash
                }

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set LED";
                }
            }
        }

        private void BtnGetDataNow_Click(object sender, EventArgs e)
        {
            //After sending this command a general incoming data report will be given with
            //the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
            //and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
            //or unit id of the device before it sends any data.
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 177; //0xb1

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Generate Data";
                }
            }
        }

        

        private void BtnPID3_Click(object sender, EventArgs e)
        {
        }
        public static String BinToHex(Byte value)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(value.ToString("X2"));  //the 2 means 2 digits
            return sb.ToString();
        }

        private void ChkSuppress_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                if (ChkSuppress.Checked == false)
                {
                    devices[selecteddevice].suppressDuplicateReports = false;
                }
                else
                {
                    devices[selecteddevice].suppressDuplicateReports = true;
                }
            }
        }

        

        public static Byte HexToBin(String value)
        {
            value = value.Trim();
            String addup = "0x" + value;
            return (Byte)Convert.ToInt32(value, 16);
        }

       

        

    }
    
    
}
