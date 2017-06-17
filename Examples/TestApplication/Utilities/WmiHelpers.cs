using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Management.Instrumentation;

namespace TestApplication.Utilities
{
    public class WmiHelpers
    {
        private enum EBitlockerProtectionStatus { PROTECTION_OFF = 0, PROTECTION_ON = 1, PROTECTION_UNKNOWN = 2 }

        public static void GetBitlockerStatus()
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2\\Security\\MicrosoftVolumeEncryption",
                    "SELECT * FROM Win32_EncryptableVolume");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_EncryptableVolume instance");
                    Console.WriteLine("-----------------------------------");
                    // Console.WriteLine("ProtectionStatus: {0}", queryObj["ProtectionStatus"]);
                    switch (int.Parse(queryObj["ProtectionStatus"].ToString()))
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ProtectionStatus: {0}", "Off");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("ProtectionStatus: {0}", "On");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ProtectionStatus: {0}", "Unknown");
                            break;
                    }

                    Console.WriteLine("ConversionStatus: {0}", queryObj["ConversionStatus"]);
                    Console.WriteLine("DriveLetter: {0}", queryObj["DriveLetter"]);
                    Console.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
                    Console.WriteLine("VolumeType: {0}", queryObj["VolumeType"]);
                    Console.WriteLine("EncryptionMethod: {0}", queryObj["EncryptionMethod"]);
                    
                    Console.WriteLine("IsVolumeInitializedForProtection: {0}", queryObj["IsVolumeInitializedForProtection"]);
                    Console.WriteLine("PersistentVolumeID: {0}", queryObj["PersistentVolumeID"]);
                    Console.ForegroundColor = Examples.ExampleUtilities.DefaultColor;
                }
            }
            catch (ManagementException e)
            {
                // MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }
    }
}