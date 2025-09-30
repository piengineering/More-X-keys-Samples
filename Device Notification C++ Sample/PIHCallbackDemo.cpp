// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
//#include "PIEHid.h"

#include <winuser.h>
#include <Dbt.h> 
#include <string.h>

#include <iostream> // For input/output operations
#include <cctype>   // For std::toupper

#define MAXDEVICES  512   //max allowed array size for enumeratepie =128 devices*4 bytes per device

//this is now in PIEHid.h file

//typedef enum {
//	piNone = 0,
//	piNewData = 1,
//	piDataChange = 2
//} EEventPI;

//typedef DWORD (__stdcall *PHIDDataEvent)(UCHAR *pData, DWORD deviceID, DWORD error);

//extern "C" DWORD __stdcall EnumeratePIE(long VID, long *data, long &count);
//extern "C" DWORD __stdcall SetupInterface(long hnd);
//extern "C" VOID  __stdcall CloseInterface(long hnd);
//extern "C" VOID  __stdcall CleanupInterface(long hnd);
//extern "C" DWORD __stdcall ReadData(long hnd, UCHAR *data);
//extern "C" DWORD __stdcall WriteData(long hnd, UCHAR *data);
//extern "C" DWORD __stdcall FastWrite(long hnd, UCHAR *data);
//extern "C" DWORD __stdcall ReadLast(long hnd, UCHAR *data);
//extern "C" DWORD __stdcall ClearBuffer(long hnd);
//extern "C" DWORD __stdcall GetReadLength(long hnd);
//extern "C" DWORD __stdcall GetWriteLength(long hnd);
//extern "C" DWORD __stdcall SetDataCallback(long hnd, int eventType, PHIDDataEvent pDataEvent);


// function declares 
int CALLBACK DialogProc(
  HWND hwndDlg,  // handle to dialog box
  UINT uMsg,     // message
  WPARAM wParam, // first message parameter
  LPARAM lParam  // second message parameter
);
//void FindAndStart(HWND hDialog);
void AddEventMsg(HWND hDialog, char *msg);
//DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error);

BYTE buffer[80];  //used for writing to device

HWND hDialog;
long hDevice = -1;



//Device Notification
#define DEVICE_NOTIFY_ALL_INTERFACE_CLASSES  0x00000004

HDEVNOTIFY hNotification = NULL;




//---------------------------------------------------------------------

int APIENTRY WinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{
    
	

	DWORD result;
	MSG   msg;

	hDialog = CreateDialog(hInstance, (LPCTSTR)IDD_MAIN, NULL, DialogProc);

	//Device Notification
	
	DEV_BROADCAST_DEVICEINTERFACE *filter;
    void *filter_ptr = NULL;
   // HWND hWnd;

   filter_ptr = (DEV_BROADCAST_DEVICEINTERFACE *)malloc(sizeof(DEV_BROADCAST_DEVICEINTERFACE) + 32);
   filter = (DEV_BROADCAST_DEVICEINTERFACE *)((long)filter_ptr & 0xFFFFFFE0);
   // Fixing pointer alignment. I don't know if this is really necessary or not...

   memset(filter, 0, sizeof(DEV_BROADCAST_DEVICEINTERFACE));
   filter->dbcc_size = sizeof(DEV_BROADCAST_DEVICEINTERFACE);
   filter->dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;

   hNotification = RegisterDeviceNotification(hDialog, filter, DEVICE_NOTIFY_WINDOW_HANDLE | DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
	//end Device Notification

    


	ShowWindow(hDialog, SW_NORMAL);

	result = GetMessage( &msg, NULL, 0, 0 );
	while (result != 0)    { 
		if (result == -1)    {
			return 1;
			// handle the error and possibly exit
		}
		else    {
			TranslateMessage(&msg); 
			DispatchMessage(&msg); 
		}
		
		result = GetMessage( &msg, NULL, 0, 0 );
	}

 

    
	


      


	return 0;
	



}
//---------------------------------------------------------------------


int CALLBACK DialogProc(
  HWND hwndDlg,  // handle to dialog box
  UINT uMsg,     // message
  WPARAM wParam, // first message parameter
  LPARAM lParam  // second message parameter
)    {

	DWORD result;
//	BYTE buffer[80];  //this globally declared only to keep track of LEDs	
	int i=0;
	HWND hList;
	
	//add for device notification
	DEV_BROADCAST_HDR *HdrPtr;
    DEV_BROADCAST_DEVNODE *NodeInfoPtr;
    DEV_BROADCAST_VOLUME *VolumeInfoPtr;
    PDEV_BROADCAST_DEVICEINTERFACE dintInfo;
	char devname[200];//how big? 
	char pivid[]="USB#VID_05F3"; //look for the USB#VID only as there are several notifications and we only need one
	char pividlower[]="USB#Vid_05f3";
    DWORD ThisDeviceType;
	//end add for device notification

	switch (uMsg)    {
	
	

	case WM_INITDIALOG:
		//SendMessage(GetDlgItem(hwndDlg, CHK_NONE), BM_SETCHECK, BST_CHECKED, 0);
		// Indicate that events are off to start.
		return FALSE;   // not choosing keyboard focus

	case WM_DEVICECHANGE:
		
		if (wParam == DBT_DEVICEARRIVAL || wParam == DBT_DEVICEREMOVEPENDING || wParam == DBT_DEVICEREMOVECOMPLETE || wParam == DBT_DEVICEQUERYREMOVE)
		{ 
			HdrPtr = (DEV_BROADCAST_HDR *)lParam;
            ThisDeviceType = HdrPtr->dbch_devicetype;
            switch (ThisDeviceType)
            {  //ok
            case DBT_DEVTYP_DEVICEINTERFACE:
                dintInfo = (PDEV_BROADCAST_DEVICEINTERFACE)lParam;
				strcpy (devname,dintInfo->dbcc_name);
                char * pch;
				pch=strstr(devname, pivid); 
				char * pchlc;
				pchlc=strstr(devname, pividlower); 
				if (pch!=NULL)
                {
                    //PI Device, re-enumerate
					//could parse even further to determine specific pid 
					
					if (wParam==DBT_DEVICEARRIVAL) 
					{
						char str[100];
						strcpy_s(str, "Arrival: ");
						strcat_s(str, devname);
						AddEventMsg(hDialog, str);
					}
					if (wParam==DBT_DEVICEREMOVECOMPLETE)
					{
						char str[100];
						strcpy_s(str, "Removal: ");
						strcat_s(str, devname);
						AddEventMsg(hDialog, str);
					}

					MessageBeep(MB_ICONHAND);
                }
				else if (pchlc!=NULL)
                {
                    //PI Device, re-enumerate
					//could parse even further to determine specific pid 

					if (wParam==DBT_DEVICEARRIVAL) 
					{
						char str[100];
						strcpy_s(str, "Arrival: ");
						strcat_s(str, devname);
						AddEventMsg(hDialog, str);
					}
					if (wParam==DBT_DEVICEREMOVECOMPLETE)
					{
						char str[100];
						strcpy_s(str, "Removal: ");
						strcat_s(str, devname);
						AddEventMsg(hDialog, devname);
					}
					MessageBeep(MB_ICONHAND);
                }
				else
				{
					//could be a non PI device or the non "USB#VID" notifications from the PI device
				}

                break;
            case DBT_DEVTYP_DEVNODE:  // from Platform SDK
                
                NodeInfoPtr = (DEV_BROADCAST_DEVNODE *)HdrPtr;
                //Description = Description + AnsiString::IntToHex(NodeInfoPtr->dbcd_devnode, 8);
                break;
            //default:
               // Description = CString(HdrPtr->dbch_devicetype);
            }//end of switch
		}
		return FALSE;

    case WM_COMMAND:
		switch (wParam)    {
		case IDCANCEL:
			
			if (hNotification)
			{
				UnregisterDeviceNotification(hNotification);
				hNotification = NULL;
			}
			PostQuitMessage(0);
			return TRUE;
		
	
		case IDC_CLEAR:
			hList = GetDlgItem(hDialog, ID_EVENTS);
			if (hList == NULL) return TRUE;
			SendMessage(hList, LB_RESETCONTENT, 0, 0);
			return TRUE;
       
		
		
		
		}

		break;
	}

	return FALSE;
}
//---------------------------------------------------------------------

//void FindAndStart(HWND hDialog)
//{
//	DWORD result;
//	long  deviceData[MAXDEVICES];  
//	long  hnd;
//	long  count;
//	int pid;
//
//	result = EnumeratePIE(0x5F3, deviceData, count);
//
//	if (result != 0)    {
//		AddEventMsg(hDialog, "Error finding PI Engineering Devices");
//		return;
//	} else if (count == 0)    {
//		AddEventMsg(hDialog, "No PI Engineering Devices Found");
//		return;
//	}
//
//	for (long i=0; i<count; i++)    {
//		pid=deviceData[i*4+0]; //get the device pid
//		if ((deviceData[i*4 + 2] == 0xC && pid!=37) && ((pid==0x403) || (pid==0x405))  )    {	
//			hnd = deviceData[i*4 + 3];
//			result = SetupInterface(hnd);
//			if (result != 0)    {
//				AddEventMsg(hDialog, "Error setting up PI Engineering Device");
//			}
//			else    {
//				hDevice = hnd;
//				AddEventMsg(hDialog, "Found Device: XK-24");
//				return;
//			}
//		}
//	}
//
//	AddEventMsg(hDialog, "No XK-24 device found");
//}
//------------------------------------------------------------------------

void AddEventMsg(HWND hDialog, char *msg)
{
	HWND hList;
	static short cnt = -1;

	hList = GetDlgItem(hDialog, ID_EVENTS);
	if (hList == NULL) return;

	SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)msg);
	cnt++;

	SendMessage(hList, LB_SETCURSEL, cnt, 0);
}
//------------------------------------------------------------------------

//DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error)
//{
//	char dataStr[256];
//
//	sprintf(dataStr, "%02x %02x %02x %02x -- %02x %02x %02x %02x -- %02x %02x %02x\n", 
//		pData[0], pData[1], pData[2], pData[3], pData[4], pData[5], pData[6], pData[7], 
//		pData[8], pData[9], pData[10]);
//
//	AddEventMsg(hDialog, dataStr);
//	//error handling
//	if (error==307)
//	{
//		CleanupInterface(hDevice);
//		MessageBeep(MB_ICONHAND);
//		AddEventMsg(hDialog, "PI Device Disconnected");
//		
//	}
//	return TRUE;
//}
//------------------------------------------------------------------------
    

     
