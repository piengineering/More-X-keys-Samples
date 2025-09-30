using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;  //in order to use DllImport 

namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form
    {
        const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004;
        const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
        const int DBT_DEVTYP_DEVICEINTERFACE = 0x00000005;
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        public class DeviceBroadcastInterface
        {
            public int Size;
            public int DeviceType;
            public int Reserved;
            public Guid ClassGuid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string Name;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]

        public struct DEV_BROADCAST_DEVICEINTERFACE
        {
            public uint dbcc_size;
            public uint dbcc_devicetype;
            public uint dbcc_reserved;
            public Guid dbcc_classguid; // GUID
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string dbcc_name1; // tchar[1]
        }

        [DllImport("user32.dll", SetLastError = true)]
        protected static extern IntPtr RegisterDeviceNotification(IntPtr hwnd, DeviceBroadcastInterface oInterface, uint nFlags);

        [DllImport("user32.dll", SetLastError = true)]
        protected static extern bool UnregisterDeviceNotification(IntPtr hHandle);
        IntPtr deviceNotificationHandle;
        DeviceBroadcastInterface dbi=new DeviceBroadcastInterface();

        public Form1()
        {
            InitializeComponent();

            //register for device notification
            int size = Marshal.SizeOf(dbi);
            dbi.Size = size;
            dbi.DeviceType = DBT_DEVTYP_DEVICEINTERFACE;
            deviceNotificationHandle = RegisterDeviceNotification(Handle, dbi, DEVICE_NOTIFY_WINDOW_HANDLE | DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //unregister for device notification
            UnregisterDeviceNotification(Handle);
           
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
      
        protected override void WndProc(ref Message m)
        {
            //you may find these definitions (and more) in dbt.h and winuser.h 
            const int WM_DEVICECHANGE = 0x0219;
            // system detected a new device 
            const int DBT_DEVICEARRIVAL = 0x8000;
            // system detected a new device 
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
            // device interface class
            const int DBT_DEVTYP_DEVICEINTERFACE = 0x00000005;

            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    int wp =(int) m.WParam;
                    int lp = (int) m.LParam;
                    if (wp == DBT_DEVICEARRIVAL || wp == DBT_DEVICEREMOVECOMPLETE)
                    {
                        
                        int devType = Marshal.ReadInt32(m.LParam, 4);

                        switch (devType)
                        {
                            case DBT_DEVTYP_DEVICEINTERFACE:
                                DEV_BROADCAST_DEVICEINTERFACE devint;
                                devint = (DEV_BROADCAST_DEVICEINTERFACE) Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_DEVICEINTERFACE));
                                string device = devint.dbcc_name1;
                                string action = "";
                                if (wp == DBT_DEVICEARRIVAL) action = "arrival";
                                if (wp == DBT_DEVICEREMOVECOMPLETE) action = "removal";
                                if (device.ToUpper().IndexOf("USB#VID_05F3") != -1)  //only want ONE notification per event so ignore all the HID#... ones
                                {
                                    //P.I. Engineering device was connected or removed
                                    this.listBox1.Items.Add(action + "  " + device);
                                    this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                                }
                                else if (device.IndexOf("Vid_05f3") == -1) //non P.I. Engineering devices
                                {
                                    this.listBox2.Items.Add(action + "  " + device);
                                    this.listBox2.SelectedIndex = this.listBox2.Items.Count - 1;
                                }
                               
                                break;
                        }
                    }
                    break;
            }
            base.WndProc(ref m);

        }

        
        
   

        
       
       
    }
    
    
}
