/**
* Refactor the Device class to respect SOLID principles and patterns. 
* What happens if a new device type needs to be supported such as Automotive, or if we need to support more languages?
*
* You can make any change you see fit, in code or tests.
*/


using System.Collections.Generic;

namespace SOLID.Assessment.Before
{

    public static class PrintHTMLclass
    {
        private  stringbuilder objstringbuilder = new stringbuilder()
            
            publis  AddHeader(string srHeader)
        {
            objstringbuilder.appendline("<h1>"+srHeader+"</h1>");
        }
        publis  AddBody(string strBody)
        {
            objstringbuilder.appendline("<br/>"+strBody);
        }
        public  string getReturnString()
        {
            return objstringbuilder.tostring();
        }
    }
    
    interface iLangugae
    {
        string statusMessage;
        string on;
        string off;
    }
    public  class Language : iLangugae
    {
        statusMessage = "OnOff";
    }
    
    public class DutchLanguage : iLangugae
    {
        statusMessage = "Toestand";
    }
    
    public class Device
    {
        private const int MEDICAL = 0;
        private const int AGRICULTURAL = 1;
        private const int REFINARY = 2;

        public int Type;
        public bool Status = true;
        public int DeviceId;

        public int SoilQuality;
        public int HeartRate;
        public int Temperature;



        public Device(int type, int deviceId)
        {
            this.Type = type;
            this.DeviceId = deviceId;
        }

        public void ToggleStatus()
        {
            Status = !Status;
        }

        public static string GetStatus(Device device, Ilanguage language)
        {
            string onOrOff;
            string statusMessage;
            //If not english, then dutch
            
                statusMessage = language.statusMessage;
                onOrOff = device.Status ? language.ON : language.OFF;
            

            switch (device.Type)
            {
                case MEDICAL:
                    return $"{statusMessage}: {onOrOff},  {device.HeartRate}";
                case AGRICULTURAL:
                    return $"{statusMessage}: {onOrOff},  {device.SoilQuality}";
                case REFINARY:
                    return $"{statusMessage}: {onOrOff},  {device.Temperature}";
            }
            return string.Empty;
        }

        public static string PrintStatus(List<Device> devices,  Ilanguage language)
        {
            // test list is empty
            if (devices.Count == 0)
            {
                PrintHTMLclass.addHeader(language.norecordmessage);
            }
            else
            {
                //we have devices
                //header
                PrintHTMLclass.addHeader(language.Headermesage);
                var numberMedical = 0;
                var numberAgricultural = 0;
                var numberRefinaries = 0;

                //Get all statuses
                foreach (Device device in devices)
                {
                    if (device.Type == MEDICAL)
                    {
                        numberMedical++;                        
                    }
                    else if (device.Type == AGRICULTURAL)
                    {
                        numberAgricultural++;                        
                    }
                    else if (device.Type == REFINARY)
                    {
                        numberRefinaries++;                        
                    }
                    PrintHTMLclass.addbody("Device ID: {device.DeviceId};{GetStatus(device, userLanguage)}");
                }

                //let`s print this
                PrintHTMLclass.addbody(GetLine(Device.MEDICAL, userLanguage, numberMedical));
                PrintHTMLclass.addbody( GetLine(Device.AGRICULTURAL, userLanguage, numberAgricultural));
                PrintHTMLclass.addbody(GetLine(Device.REFINARY, userLanguage, numberRefinaries));

                //footer
                 PrintHTMLclass.addbody("TOTAL:  (numberAgricultural + numberMedical + numberRefinaries) + " " +
                                (language.devices);

            }
            return PrintHTMLclass.getReturnString();
        }

        public static string GetLine(int deviceType, Ilanguage language, int numberOfDevices)
        {
            if (numberOfDevices > 0)
            {
                return $"{numberOfDevices} {TranslateDevice(deviceType, userLanguage)} " + language.devices;
            }
            return string.Empty;
        }

        private static string TranslateDevice(int type, Ilanguage language)
        {
            switch (type)
            {
                case MEDICAL:
                    return userLanguage == EN ? "Medical" : "Medisch";
                case AGRICULTURAL:
                    return userLanguage == EN ? "Agricultural" : "Agrarisch";
                case REFINARY:
                    return userLanguage == EN ? "Refinary" : "Raffinaderij";
            }
            return string.Empty;
        }
    }
}
