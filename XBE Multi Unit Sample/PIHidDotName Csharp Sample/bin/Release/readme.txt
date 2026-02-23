Generic Multi-Unit Sample

1. Connect all devices to computer or to the hub and the hub to the computer.
2. Start .exe
3. Click Enumerate. All the devices should be listed in the top box. The first one found will be selected. The device selected is the device that the commands are written to, like Toggle or Write Unit ID. 
4. Click Setup for Callback to begin reading data from all devices. Press buttons on the devices and you will see for each button press and button release a line written to the long listbox. They will be identified by the productstring, pid, oem id, and unit id. The handle is shown too but not really useful to the non-developer (very useful for the developer).
5. Everything else on the screen are commands that can be written to the selected device, such as Write Unit ID. etc. To identify a particular device, first select it in the top listbox then click Toggle (if backlights available) a few times, the backlights will go off and on so you can see which real device corresponds to the ones in the listbox.

WARNING: If each of the devices were previously setup for a specific backlighting and user messes with the backlighting then clicks Save Backlights, the previously setup backlighting will be destroyed. You can mess with the backlighting as long as Save Backlights is not clicked. Same for other "sticky" features (features written to the device's eeprom). Here is the list:

-Write Unit ID
-Write Version
-Save Configuration
-Set AES Key
-Change Device
-Desired PID on reboot
-Always change to KVM on reboot