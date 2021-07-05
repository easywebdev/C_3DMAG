using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace _3DMAG_v1
{
    [Serializable]
    public class DeviceSettings
    {
        public string portname { set; get; }     // Port Name
        public int baudrate { set; get; }        // Baudrate Speed data transfer (look device settings)
        public Parity parity { set; get; }       // Parity
        public int databits { set; get; }        // Data Bits
        public StopBits stopbits { set; get; }   // Stop Bits
        public Handshake handshake { set; get; } // HandShake
        public int readtimeout { set; get; }     // Read TimeOut waiting responce to read data from device
        public int writetimeout { set; get; }    // Write TimeOut waiting responce to write data to device

        public DeviceSettings()
        {
            portname = "COM1";
            baudrate = 9600;
            parity = Parity.None;
            databits = 8;
            stopbits = StopBits.One;
            handshake = Handshake.None;
            readtimeout = 2000;
            writetimeout = 2000;
        }
    }

    public class MeasureSettings
    {
        public byte deviceID { set; get; }

        public string sensorsGain1 { set; get; }
        public string sensorsGain2 { set; get; }
        public double sensorCurrent { set; get; }       // [mA]

        public string pt100Gain1 { set; get; }
        public string pt100Gain2 { set; get; }
        public double pt100Current { set; get; }        // [mA]

        public int statCountT { set; get; }
        public int statCountV { set; get; }

        public string T_MethodX { set; get; }
        public string T_MethodY { set; get; }
        public string T_MethodZ { set; get; }

        public string B_MethodX { set; get; }
        public string B_MethodY { set; get; }
        public string B_MethodZ { set; get; }

        public double K1x { set; get; }               // Temperture corection coefficients
        public double K2x { set; get; }               // V = V / (1 + K1*(T - T0) + K2*(T^2 - T0^2) + K3*(T^3 - T0^3))
        public double K3x { set; get; }
        public double K1y { set; get; }               
        public double K2y { set; get; }
        public double K3y { set; get; }
        public double K1z { set; get; }
        public double K2z { set; get; }
        public double K3z { set; get; }               // ***

        public double A0x { set; get; }               // A0 - A3 koefficients for Magnetic field transform
        public double A1x { set; get; }               // B = A0 + A1*V + A2*V^2 + A3*V^3
        public double A2x { set; get; }
        public double A3x { set; get; }
        public double A0y { set; get; }
        public double A1y { set; get; }
        public double A2y { set; get; }
        public double A3y { set; get; }
        public double A0z { set; get; }
        public double A1z { set; get; }
        public double A2z { set; get; }
        public double A3z { set; get; }               // ****

        public double KT0 { set; get; }               // T-sensor (Pt100) coefficients
        public double KT1 { set; get; }               // ***              

        public bool enableLog { set; get; }
        public string logPath { set; get; }

        public string measureMode { set; get; }
        public string fieldUnits { set; get; }
        public int chartPoints { set; get; }
        public int delayCycle { set; get; }

        public string programName { set; get; }

        public MeasureSettings()
        {
            deviceID = 0x55;

            sensorsGain1 = "1";
            sensorsGain2 = "1";
            sensorCurrent = 10;

            pt100Gain1 = "1";
            pt100Gain2 = "1";
            pt100Current = 1;

            statCountT = 1;
            statCountV = 1;

            T_MethodX = "Linear";
            T_MethodY = "Linear";
            T_MethodZ = "Linear";

            B_MethodX = "Linear";
            B_MethodY = "Linear";
            B_MethodZ = "Linear";

            K1x = 0;
            K2x = 0;
            K3x = 0;
            K1y = 0;
            K2y = 0;
            K3y = 0;
            K1z = 0;
            K2z = 0;
            K3z = 0;

            A0x = 0;
            A1x = 1;
            A2x = 0;
            A3x = 0;
            A0y = 0;
            A1y = 1;
            A2y = 0;
            A3y = 0;
            A0z = 0;
            A1z = 1;
            A2z = 0;
            A3z = 0;

            KT0 = -262.255;
            KT1 = 2.621;

            enableLog = false;
            logPath = null;

            measureMode = "1D";
            fieldUnits = "mT";
            chartPoints = 1000;
            delayCycle = 0;

            programName = null;
        }
    }

    [Serializable]
    public class Settings
    {
        public DeviceSettings deviceSettings { set; get; }
        public MeasureSettings measureSettings { set; get; }
    }
}
