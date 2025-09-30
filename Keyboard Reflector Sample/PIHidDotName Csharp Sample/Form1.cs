using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PIEHid32Net;
using System.IO; //in order to use Streamwriter

namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        PIEDevice[] devices;
        
        int[] cbotodevice=null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        int selecteddevice=-1; //set to the index of CboDevice

        byte[] lastdata = null;

       
        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        Control c;
        ListBox thisListBox;
        //end thread-safe

        int[] asciitohid = null;
        int[] shiftasciitohid = null;
        string richboxtext = ""; //cheesy way of getting around threadsafe errors.
        StreamWriter sw;
     
        public Form1()
        {
            InitializeComponent();

            asciitohid = new int[256];
            shiftasciitohid = new int[256];

            for (int i = 0; i < 256; i++) { asciitohid[i] = 0; shiftasciitohid[i] = 0; }
            asciitohid[97] = 04; //a
            asciitohid[98] = 05; //b
            asciitohid[99] = 06; //c
            asciitohid[100] = 07; //d
            asciitohid[101] = 08; //e
            asciitohid[102] = 09; //f
            asciitohid[103] = 10; //g
            asciitohid[104] = 11; //h
            asciitohid[105] = 12; //i
            asciitohid[106] = 13; //j
            asciitohid[107] = 14; //k
            asciitohid[108] = 15; //l
            asciitohid[109] = 16; //m
            asciitohid[110] = 17; //n
            asciitohid[111] = 18; //o
            asciitohid[112] = 19; //p
            asciitohid[113] = 20; //q
            asciitohid[114] = 21; //r
            asciitohid[115] = 22; //s
            asciitohid[116] = 23; //t
            asciitohid[117] = 24; //u
            asciitohid[118] = 25; //v
            asciitohid[119] = 26; //w
            asciitohid[120] = 27; //x
            asciitohid[121] = 28; //y
            asciitohid[122] = 29; //z
            asciitohid[48] = 39; //0
            asciitohid[49] = 30; //1
            asciitohid[50] = 31; //2
            asciitohid[51] = 32; //3
            asciitohid[52] = 33; //4
            asciitohid[53] = 34; //5
            asciitohid[54] = 35; //6
            asciitohid[55] = 36; //7
            asciitohid[56] = 37; //8
            asciitohid[57] = 38; //9

            asciitohid[45] = 45; //-
            asciitohid[61] = 46; //=
            asciitohid[91] = 47; //[
            asciitohid[93] = 48; //]
            asciitohid[92] = 49; //\
            asciitohid[96] = 53; //`
            asciitohid[59] = 51; //;
            asciitohid[39] = 52; //'
            asciitohid[44] = 54; //,
            asciitohid[46] = 55; //.
            asciitohid[47] = 56; // /

            asciitohid[9] = 43; //tab
            asciitohid[10] = 40; //NL to enter
            asciitohid[13] = 40; //CR to enter
            asciitohid[32] = 44; //space
            asciitohid[8] = 42; //backspace

     
            shiftasciitohid[65] = 04; //A
            shiftasciitohid[66] = 05; //B
            shiftasciitohid[67] = 06; //C
            shiftasciitohid[68] = 07; //D
            shiftasciitohid[69] = 08; //E
            shiftasciitohid[70] = 09; //F
            shiftasciitohid[71] = 10; //G
            shiftasciitohid[72] = 11; //H
            shiftasciitohid[73] = 12; //I
            shiftasciitohid[74] = 13; //J
            shiftasciitohid[75] = 14; //K
            shiftasciitohid[76] = 15; //L
            shiftasciitohid[77] = 16; //M
            shiftasciitohid[78] = 17; //N
            shiftasciitohid[79] = 18; //O
            shiftasciitohid[80] = 19; //P
            shiftasciitohid[81] = 20; //Q
            shiftasciitohid[82] = 21; //R
            shiftasciitohid[83] = 22; //S
            shiftasciitohid[84] = 23; //T
            shiftasciitohid[85] = 24; //U
            shiftasciitohid[86] = 25; //V
            shiftasciitohid[87] = 26; //W
            shiftasciitohid[88] = 27; //X
            shiftasciitohid[89] = 28; //Y
            shiftasciitohid[90] = 29; //Z
            shiftasciitohid[41] = 39; //)
            shiftasciitohid[33] = 30; //!
            shiftasciitohid[64] = 31; //@
            shiftasciitohid[35] = 32; //#
            shiftasciitohid[36] = 33; //$
            shiftasciitohid[37] = 34; //%
            shiftasciitohid[94] = 35; //^
            shiftasciitohid[38] = 36; //&
            shiftasciitohid[42] = 37; //*
            shiftasciitohid[41] = 38; //(

            shiftasciitohid[95] = 45; //_
            shiftasciitohid[43] = 46; //+
            shiftasciitohid[123] = 47; //{
            shiftasciitohid[125] = 48; //}
            shiftasciitohid[124] = 49; //|
            shiftasciitohid[126] = 53; //~
            shiftasciitohid[58] = 51; //:
            shiftasciitohid[34] = 52; //"
            shiftasciitohid[60] = 54; //<
            shiftasciitohid[62] = 55; //>
            shiftasciitohid[63] = 56; //?

            richboxtext = richTextBox1.Text;

            string filename = "arrays.txt";
            sw = File.CreateText(filename);

        }

        //data callback    
        public void HandlePIEHidData(Byte[] data, PIEDevice sourceDevice, int error)
        {

            //check the sourceDevice and make sure it is the same device as selected in CboDevice   
            if (sourceDevice == devices[selecteddevice])
            {
                //write raw data to listbox1
                String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                for (int i = 0; i < sourceDevice.ReadLength; i++)
                {
                    output = output + BinToHex(data[i]) + " ";
                }
                this.SetListBox(output);

                if (data[2] < 4) //general incoming data
                {

                    byte val2;
                    //check for key presses
                    val2 = (byte)(data[3] & 1); //top left key is 1st key
                    byte lval2 = (byte)(lastdata[3] & 1);
                    if (val2 == 1 && lval2 == 0) //this key was up and now is down, ie pressed
                    {
                        XKButton1();
                    }
                    val2 = (byte)(data[3] & 2); //2nd key
                    lval2 = (byte)(lastdata[3] & 2);
                    if (val2 == 2 && lval2 == 0)
                    {
                        XKButton2();
                    }
                    val2 = (byte)(data[3] & 4); //3rd key
                    lval2 = (byte)(lastdata[3] & 4);
                    if (val2 == 4 && lval2 == 0)
                    {
                        XKButton3();
                    }
                    val2 = (byte)(data[3] & 8); //4th key
                    lval2 = (byte)(lastdata[3] & 8);
                    if (val2 == 8 && lval2 == 0)
                    {
                        XKButton4();
                    }



                    for (int i = 0; i < sourceDevice.ReadLength; i++)
                    {
                        lastdata[i] = data[i];
                    }


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

        public static String BinToHex(Byte value)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(value.ToString("X2"));  //the 2 means 2 digits
            return sb.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sw.Close();
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
            lastdata = new byte[devices[selecteddevice].ReadLength];
            for (int i = 0; i < devices[selecteddevice].ReadLength; i++) lastdata[i] = 0;
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
                toolStripStatusLabel1.Text = "Callback on";
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
                    //HID Version = devices[i].Version);

                    if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength > 1)
                    {
                        switch (devices[i].Pid)
                        {
                            case 1027:
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1028:
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1029:
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #3)");
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
                lastdata = new byte[devices[selecteddevice].ReadLength];
                for (int i = 0; i < devices[selecteddevice].ReadLength; i++) lastdata[i] = 0;
               
            }
           
        }
       
        private void BtnRed_Click(object sender, EventArgs e)
        {
            
            

        }

        

        

        private void BtnBL_Click(object sender, EventArgs e)
        {

            
           
        }
        private void BtnBLToggle_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkScrollLock_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkGreenOnOff_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkRedOnOff_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnSetFlash_Click(object sender, EventArgs e)
        {
            
        }

       

        private void BtnSaveBL_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnTimeStamp_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnTimeStampOn_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnKBreflect_Click(object sender, EventArgs e)
        {
            //Sends native keyboard messages
            //Write some keys to the textbox, should be Abcd
            //send some hid codes to the textbox, these will be coming in on the native keyboard endpoint
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                int result;
                textBox1.Focus();
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 201;

                wData[2] = 2;       //modifiers, Bit 1=Left Ctrl, bit 2=Left Shift, bit 3=Left Alt, bit 4=Left Gui, bit 5=Right Ctrl, bit 6=Right Shift, bit 7=Right Alt, bit 8=Right Gui.
                wData[3] = 0;       //always 0
                wData[4] = 0x04;    //hid code = a down
                wData[5] = 0;
                wData[6] = 0;
                wData[7] = 0;
                wData[8] = 0;
                wData[9] = 0;
                result = devices[selecteddevice].WriteData(wData);

                wData[2] = 0;       //modifiers
                wData[3] = 0;       //always 0
                wData[4] = 0;    //hid code = a up
                wData[5] = 0x05;    //hid code = b down
                wData[6] = 0x06;    //hid code = c down
                wData[7] = 0x07;    //hid code = d down
                wData[8] = 0;
                wData[9] = 0;
                result = devices[selecteddevice].WriteData(wData);

                wData[2] = 0;
                wData[4] = 0;
                wData[5] = 0;  //b up
                wData[6] = 0;  //c up
                wData[7] = 0;  //d up
                wData[8] = 0; 
                wData[9] = 0;
                result = devices[selecteddevice].WriteData(wData);

                wData[2] = 0;
                wData[4] = 0x05;
                wData[5] = 0;  
                wData[6] = 0;  
                wData[7] = 0;  
                wData[8] = 0; //b up
                wData[9] = 0;
                result = devices[selecteddevice].WriteData(wData);

                wData[2] = 0;
                wData[4] = 0;
                wData[5] = 0;  //b up
                wData[6] = 0;  //c up
                wData[7] = 0;  //d up
                wData[8] = 0;
                wData[9] = 0;
                result = devices[selecteddevice].WriteData(wData);


                //using this method in real application if want to exactly duplicate down and up strokes would
                //probably do one key at a time.
                //response seems good but maybe some machines may need a sleep between writes??

            }
        }

        private void BtnJoyreflect_Click(object sender, EventArgs e)
        {
            //Sends native joystick messages
            //Open up the game controller control panel to test these features, after clicking this button
            //go and make active the control panel properties and change will be seen
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                int result;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 202;
                wData[2] = (byte)((Convert.ToByte(textBox2.Text) ^ 127) - 255); //X, in raw form 0 to 127 from center to right, 255 to 128 from center to left but I like to use 0-255 where 0 is max left, 255 is max right
                wData[3] = (byte)(Convert.ToByte(textBox3.Text) ^ 127); //Y, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[4] = (byte)(Convert.ToByte(textBox4.Text) ^ 127); //Z, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[5] = Convert.ToByte(textBox5.Text); //buttons
                wData[6] = Convert.ToByte(textBox6.Text); //hat
                result = devices[selecteddevice].WriteData(wData);
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - joystick reflector";
                }
            }
        }

        private void BtnDescriptor_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnSetKey_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCheckKey_Click(object sender, EventArgs e)
        {
            
            
        }

        private void BtnReflector_Click(object sender, EventArgs e)
        {
            //Change device to reflector mode, the default mode as shipped
            //In reflector mode the device has 2 additional endpoints; keyboard and joystick
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                //now disable the internal macros
                wData[0] = 0;
                wData[1] = 0xd3;
                wData[2] = 0x16; //Reflector Mode, default 0x16, no Parse, no Mouse set to 17 to have stored macro (from HW mode) played back in addition to the splat report
                wData[3] = 0x0f; //Hardware Mode, default 0x0F, no Splat, all else
                wData[4] = 0x10; //Splat Only
                //0 0 0 S M J K P  where S=Splat, M=Mouse, J=Joystick, K=Keyboard, P=Parse
                int result = devices[selecteddevice].WriteData(wData);
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    //  toolStripStatusLabel1.Text = "Write Success - Enable Ins";
                }
                
                //0=device 0:Reflector mode.  Reporting to the USB as a Splat device (IN and OUT), a Combined Joystick-Mouse, and a keyboard.
                //1=device 1: Hardware mode**. Reporting to the USB as a Splat (OUT only) device, a Joystick, and a keyboard.
                //2=device 2: Traditional Splat mode. Reporting as only a Splat  device (IN and OUT).
                //**The use of Hardware mode is not covered in this SDK. 
                wData[0] = 0;
                wData[1] = 204;
                wData[2] = 0;  //mode
              
                 result = devices[selecteddevice].WriteData(wData);
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                    
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - to reflector mode";
                }
               

                
            }
        }

        private void BtnSplatOnly_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkGreenLED_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkRedLED_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkFGreenLED_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkFRedLED_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkBLOnOff_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkFlash_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnGetDataNow_Click(object sender, EventArgs e)
        {
            
        }
        private void XKButton1()
        {
            //send the keys kbs and holds down for 2 sec and release
            int result;

            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 201;

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0x0e;    //hid code = k down
            wData[5] = 0;
            wData[6] = 0;
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0x0e;    //hid code = k down
            wData[5] = 0x05;    //b
            wData[6] = 0;
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0x0e;    //hid code = k down
            wData[5] = 0x05;    //b
            wData[6] = 0x16;    //s
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);
            System.Threading.Thread.Sleep(2000); //hold down for 2 sec

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0;    //hid code = k up
            wData[5] = 0;    //hid code = b up
            wData[6] = 0;    //hid code = s up
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);

        }
        private void XKButton2()
        {
            //send the keys vmp and holds down for 2 sec and release
            int result;

            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 201;

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0x19;    //hid code = v down
            wData[5] = 0;
            wData[6] = 0;
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0x19;    //hid code = v down
            wData[5] = 0x10;    //m
            wData[6] = 0;
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0x19;    //hid code = v down
            wData[5] = 0x10;    //m
            wData[6] = 0x16;    //p
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);
            System.Threading.Thread.Sleep(2000); //hold down for 2 sec

            wData[2] = 0;       //modifiers
            wData[3] = 0;       //always 0
            wData[4] = 0;    //hid code = v up
            wData[5] = 0;    //hid code = m up
            wData[6] = 0;    //hid code = p up
            wData[7] = 0;
            wData[8] = 0;
            wData[9] = 0;
            result = devices[selecteddevice].WriteData(wData);
        }
        private void XKButton3()
        {
            //This takes a string and sends it out one character at a time unlike the above 2 buttons where simultaneous key presses were needed
            
            string sendthis = "";
          
            sendthis = richboxtext;
            
            //sendthis = "This is a test of the USB Keylogger.  It is intended to determine the keylogger's ability to record extended typing at a nominal rate.\n";
            //sendthis=sendthis+"`1234567890-= qwertyuiop[]"+(char)92 +"asdfghjkl;'zxcvbnm,./\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            //sendthis = sendthis+"This concludes this portion of the keylogger test.";
            int result;
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 201;

            while (sendthis.Length > 0)
            {   
                //get first character
                int ascii = (int)sendthis[0];
                //find this character
                int hidc = asciitohid[ascii];
                if (hidc == 0)  //must be a shifted character
                {
                    hidc = shiftasciitohid[ascii];
                    if (hidc != 0) //means needs shift and shift is not down already so put it down
                    {
                        wData[2] = 2;
                        wData[4] =(byte) hidc;
                        result = 404;
                        while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                        //and up
                        wData[2] = 0;
                        wData[4] = 0;
                        result = 404;
                        while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                    }
                }
                else
                {
                    wData[2] = 0;
                    wData[4] = (byte)hidc;
                    result = 404;
                    while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                    //and up
                    wData[2] = 0; 
                    wData[4] = 0;
                    result = 404;
                    while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                }
                sendthis = sendthis.Remove(0, 1);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richboxtext = richTextBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //use escape codes if needed
            //   \n=linefeed, \t=tab, \r=carriage return, \\=backslash, \b=backspace 
            
            string sendthis = "This is a test of reflector commands.  It is intended to determine the speed at which commands can be sent.\n";
            sendthis = sendthis + "`1234567890-= qwertyuiop[]" + (char)92 + "asdfghjkl;'zxcvbnm,./\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "Now is the time for all good men to come to the aid of their country.\n";
            sendthis = sendthis + "This concludes this portion of the keylogger test.";
            richTextBox1.Text = sendthis;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Change device to hardware mode, the default mode as shipped
            //In reflector mode the device has 2 additional endpoints; keyboard and joystick
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                //0=device 0:Reflector mode.  Reporting to the USB as a Splat device (IN and OUT), a Combined Joystick-Mouse, and a keyboard.
                //1=device 1: Hardware mode**. Reporting to the USB as a Splat (OUT only) device, a Joystick, and a keyboard.
                //2=device 2: Traditional Splat mode. Reporting as only a Splat  device (IN and OUT).
                //**The use of Hardware mode is not covered in this SDK. 
                wData[0] = 0;
                wData[1] = 204;
                wData[2] = 1;  //mode

                int result = devices[selecteddevice].WriteData(wData);
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - to hardware mode";
                }

            }
        }
        private void XKButton4()
        {
            //This takes a string and sends it out 6 characters at a time (if possible)
            string sendthis = "";

            sendthis = richboxtext;
            
            int result;
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 201;

            bool shifted = false;

            bool[] hiddown = null;
            int[] stopshift = null;
            hiddown= new bool[256]; //keeps track of the state of this hid code, if true then it is down already and need to up it if want to send another
            stopshift = new int[6];


            while (sendthis.Length > 0)
            {
                //get first 6 characters
                int numchartosend=6;
                if (sendthis.Length < 6) //then send 6
                {
                    numchartosend = sendthis.Length;
                }
                
                int cnt = 4;//the first spot for characters
                for (int i = 0; i <numchartosend; i++)
                {
                    //in order to optimize messages, need to find out start and stop points of modifiers.  In the case of sending
                    //pure ascii text we have only the Shift modifier to deal with.
                    int ascii = (int)sendthis[i];
                    int hidc = asciitohid[ascii];
                    //find this character
                    if (hidc == 0 && shifted==false)  //must be a shifted character but shift is not down
                    {
                        hidc = shiftasciitohid[ascii];
                        if (hidc != 0) 
                        {
                            //doesn't matter about hiddown because we are sending the ups out first 
                            //send out what's in the queue if anything before putting down the shift
                            if (cnt > 4)
                            {
                                result = 404;
                                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                                for (int j = 4; j < cnt; j++)
                                {
                                    hiddown[wData[j]] = false;
                                    wData[j] = 0;  //ups
                                }
                                result = 404;
                                while (result == 404) { result = devices[selecteddevice].WriteData(wData); } //send the ups
                                PrintwData();
                                cnt = 4;
                            }

                            wData[2] = 2;
                            wData[cnt] = (byte)hidc;
                            hiddown[hidc] = true;
                            shifted = true;
                            cnt++;
                        }
                    }
                    else if (hidc == 0 && shifted == true) //another shifted character but shift is already down
                    {
                        hidc = shiftasciitohid[ascii];
                        if (hidc != 0) 
                        {
                            if (hiddown[hidc] == false) //add to message
                            {
                                wData[2] = 2; //redundant
                                wData[cnt] = (byte)hidc;
                                hiddown[hidc]=true;
                                shifted = true;
                                cnt++;
                            }
                            else //this key is already down, must up it before downing it again
                            {
                                //send out and up before can put that key down again
                                result = 404;
                                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                                PrintwData();
                                for (int j = 4; j < cnt; j++)
                                {
                                    hiddown[wData[j]] = false;
                                    wData[j] = 0;  //ups
                                }
                                result = 404;
                                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }  //send the ups
                                PrintwData();
                                cnt = 4;
                                //and now for this one
                                wData[2] = 2; //redundant
                                wData[cnt] = (byte)hidc;
                                hiddown[cnt]=true;
                                shifted = true;
                                cnt++;
                            }
                        }
                    }
                    else if (hidc != 0 && shifted == true) //done shifting, send out what have and start to fill in next message
                    {
                        //doesn't matter about hiddown because we are sending the ups anyway
                        //send the shifted message
                        result = 404;
                        while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                        PrintwData();
                        //and up 
                        wData[2] = 0; //up modifier
                        for (int j = 4; j < cnt; j++)
                        {
                            hiddown[wData[j]] = false;
                            wData[j] = 0; //ups
                        }
                        result = 404;
                        while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                        PrintwData();
                        cnt = 4;
                        wData[cnt] = (byte)hidc;
                        hiddown[hidc] = true;
                        cnt++;
                        shifted = false;
                    }
                    else  //not shifted and previous character was not shifted, add to message
                    {
                        if (hiddown[hidc] == false) //add to message
                        {
                            wData[cnt] = (byte)hidc;
                            hiddown[hidc] = true;
                            cnt++;
                        }
                        else  //have to write out before can do that key again
                        {
                            result = 404;
                            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                            PrintwData();
                            //and up 
                            for (int j = 4; j < cnt; j++)
                            {
                                hiddown[wData[j]] = false;
                                wData[j] = 0; //ups
                            }
                            result = 404;
                            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                            PrintwData();
                            cnt = 4;
                            wData[cnt] = (byte)hidc;
                            hiddown[hidc] = true;
                            cnt++;
                            shifted = false;
                        }
                    }

                }

                //write out all 6 (or less if at end of macro)
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                PrintwData();
                //and ups
                if (shifted == true) wData[2] = 2;
                else wData[2] = 0;
                wData[3] = 0;
                wData[4] = 0;
                wData[5] = 0;
                wData[6] = 0;
                wData[7] = 0;
                wData[8] = 0;
                wData[9] = 0;
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                PrintwData();

                sendthis = sendthis.Remove(0, numchartosend);
            }
        }

        private void PrintwData()
        {
            ////for debugging reflector mode
            ////write out the wData array
            //for (int i = 0; i < 10; i++)
            //{
            //    string buff = i.ToString() + "=" + wData[i].ToString();
            //    sw.WriteLine(buff);
              
            //}
            //sw.WriteLine("");

            


        }

        
 
       
    }
    
    
}
