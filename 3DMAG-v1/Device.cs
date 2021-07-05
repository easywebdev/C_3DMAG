using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Collections;

namespace _3DMAG_v1
{
    class Device
    {
        /* Variables */
        byte ID;
        DeviceSettings settings;
        SerialPort port = new SerialPort();
        /**/

        public Device(byte deviceID, DeviceSettings deviceSettings)
        {
            ID = deviceID;
            settings = deviceSettings;
        }

        /*
         * Function open port if it's closed
         */
        public void openDevice()
        {
            if(!port.IsOpen)
            {
                port.PortName = settings.portname;
                port.BaudRate = settings.baudrate;
                port.Parity = settings.parity;
                port.DataBits = settings.databits;
                port.StopBits = settings.stopbits;
                port.Handshake =settings.handshake;
                port.ReadTimeout = settings.readtimeout;
                port.WriteTimeout = settings.writetimeout;

                port.Open();
            }
        }

        /*
         * Function close port if it's opened
         */
        public void closeDevice()
        {
            if(port.IsOpen)
            {
                port.Close();
            }
        }

        /*
         * Function get voltage from 4 bytes by IEEE 754 standart
         */
        public double getVoltageIEEE754()
        {
            double result = 0;
            byte[] request = new byte[] { ID, 0x21 };
            //byte[] temp = new byte[] { 0x55, 0x21, 0x43, 0x1B, 0xA0, 0x00 }; 155,625 in DEC
            

            port.Write(request, 0, request.Length);
            byte[] responce = readPort(6);
            
            //MessageBox.Show(ByteToStr(tmp));
            if(responce.Length == 6)
            {
                byte[] tmp = new byte[4];
                Array.Copy(responce, 2, tmp, 0, 4);
                result = IEEE754.bytesToDouble32(tmp, false);
            }
            
            return result;
        }

        /*
         * Function get voltage from  3 bytes.
         */
        public double getVoltage()
        {
            double result = 0;
            byte[] request = new byte[] { ID, 0x20 };
            byte sign = 0x00;

            port.Write(request, 0, request.Length);
            byte[] responce = readPort(5);
            //responce = new byte[] {0x55, 0x20, 0xff, 0xfd, 0x94 };
            
            BitArray bitArr = new BitArray(new byte[] { responce[2] });

            if(bitArr[bitArr.Length - 1])
            {
                sign = 0xFF;
            }

            responce[1] = sign;

            Array.Reverse(responce);
            int dig = BitConverter.ToInt32(responce, 0);
            result = dig * 3.6 / 131071;

            return result;
        }

        /*
         * Function for set Sensor current.
         * Current set for sensor selected by function "selectSensor"
         * @param: double current - sensor current [mA]
         * @return: seted current [mA]
         */
        public double setSensorCurrentValue(double current)
        {
            double setCurrent = 0;
            int cod = Convert.ToInt32(Math.Abs(Math.Round(current * 65535 * 15 * 1E-3 / 5)));
            byte[] codBytes = BitConverter.GetBytes(cod);

            byte[] request = new byte[] { ID, 0x09, codBytes[1], codBytes[0] };
            port.Write(request, 0, request.Length);
            byte[] response = readPort(4);

            if (response.SequenceEqual(request))
            {
                Array.Reverse(response);
                setCurrent = BitConverter.ToInt16(response, 0) * 5 * 1E3 / 65535 / 15;
            }

            return setCurrent;
        }

        /*
         * Function for set sensors gains.
         * @param: gainCode - string value from two chars (each char is a value from list: 1,2,3,4,5,6,7,8,9)
         */
        public bool setGains(string gainCode)
        {
            byte[] request = new byte[] { ID, 0x03, Convert.ToByte("0x" + gainCode, 16) };
            byte[] response = new byte[3];

            port.Write(request, 0, request.Length);
            response = readPort(3);

            if (response.SequenceEqual(request))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Function for select sensor.
         * @param int number - sensor number (1, 2, 3, 4)
         */
        public bool selectSensor(int number)
        {
            byte[] request = new byte[] { ID, 0x01, Convert.ToByte(number - 1) };
            byte[] response = new byte[3];

            port.Write(request, 0, request.Length);
            response = readPort(3);

            if (response.SequenceEqual(request))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Function  set Switch combination.
         * @param string combination - switch combination like I##V## (# - is 1,2,3,4)
         *                             Example: I13V24 or I12V34.
         */
        public bool doSwitch(string combination)
        {
            byte IByte = Convert.ToByte("0x" + combination.Substring(1, 2), 16);
            byte VByte = Convert.ToByte("0x" + combination.Substring(4, 2), 16);

            byte[] request = new byte[] { ID, 0x02, VByte, IByte };
            byte[] response = new byte[4];

            port.Write(request, 0, request.Length);
            response = readPort(4);

            if (response.SequenceEqual(request))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Function for read bytes from COM port.
         * Function wait while COM port gets the presets bytes count 
         * and then return the response as byte array
         * param: int count - presets bytes count
         */
        byte[] readPort(int count)
        {
            Stopwatch sw = new Stopwatch();
            int byteCount = port.BytesToRead;

            sw.Start();

            while(byteCount != count)
            {
                byteCount = port.BytesToRead;

                if(sw.ElapsedMilliseconds > settings.readtimeout)
                {
                    break;
                }
            }

            sw.Stop();

            byte[] responce = new byte[byteCount];
            port.Read(responce, 0, byteCount);

            return responce;
        }

        /*
         * Function transform array of bytes to HEX string.
         * String present array bytes as HEX separated by space, like as "0x00 0xFF 0x1F".
         */
        string ByteToStr(byte[] arrBytes)
        {
            if (arrBytes == null)
            {
                return null;
            }

            if (arrBytes.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder str = new StringBuilder();

            foreach (byte hex in arrBytes)
            {
                str.Append("0x");
                str.Append(hex.ToString("x2"));
                str.Append(" ");
            }

            return str.ToString();
        }
    }
}
