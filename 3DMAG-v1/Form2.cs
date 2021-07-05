using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _3DMAG_v1
{
    public partial class Form2_ConnectionSettings : Form
    {
        /* Variables */
        string FileSettings;
        DeviceSettings deviceSettings;
        int[] baudrate = { 300, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200, 230400 };
        /**/

        public Form2_ConnectionSettings(DeviceSettings settings, string fileSettings)
        {
            InitializeComponent();
            FileSettings = fileSettings;
            deviceSettings = settings;
        }

        /* Functions */
        string[] getPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }

        void setSettingsToTheInterface()
        {
            comboBox_portname.SelectedItem = deviceSettings.portname;
            comboBox_baudrate.SelectedItem = deviceSettings.baudrate;
            comboBox_parity.SelectedItem = deviceSettings.parity.ToString();
            textBox_databits.Text = deviceSettings.databits.ToString();
            comboBox_stopbits.SelectedItem = deviceSettings.stopbits.ToString();
            comboBox_handshake.SelectedItem = deviceSettings.handshake.ToString();
            textBox_read_timeout.Text = deviceSettings.readtimeout.ToString();
            textBox_write_timeout.Text = deviceSettings.writetimeout.ToString();
        }
        /**/

        private void Form2_ConnectionSettings_Load(object sender, EventArgs e)
        {
            // Fill comboboxes
            comboBox_portname.Items.AddRange(getPorts());

            foreach (int s in baudrate)
            {
                comboBox_baudrate.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                comboBox_parity.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                comboBox_stopbits.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                comboBox_handshake.Items.Add(s);
            }

            // set settings to the interface
            setSettingsToTheInterface();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            // Apply settings
            bool valid = false;
            List<string> errList = new List<string>();
            string err = null;

            comboBox_portname.ForeColor = Color.Black;
            comboBox_baudrate.ForeColor = Color.Black;
            comboBox_parity.ForeColor = Color.Black;
            textBox_databits.ForeColor = Color.Black;
            comboBox_stopbits.ForeColor = Color.Black;
            comboBox_handshake.ForeColor = Color.Black;
            textBox_read_timeout.ForeColor = Color.Black;
            textBox_write_timeout.ForeColor = Color.Black;

            if(getPorts().Contains(comboBox_portname.Text)) { deviceSettings.portname = comboBox_portname.Text; } else { errList.Add("Wrong Port name"); comboBox_portname.ForeColor = Color.Red; }
            try { deviceSettings.baudrate = int.Parse(comboBox_baudrate.Text); } catch { errList.Add("Wrong Baudrate"); comboBox_baudrate.ForeColor = Color.Red; }
            try { deviceSettings.parity = (Parity)Enum.Parse(typeof(Parity), comboBox_parity.Text); } catch { errList.Add("Wrong Parity"); comboBox_parity.ForeColor = Color.Red; }
            try { deviceSettings.databits = int.Parse(textBox_databits.Text); } catch { errList.Add("Wrong Databits"); textBox_databits.ForeColor = Color.Red; }
            try { deviceSettings.stopbits = (StopBits)Enum.Parse(typeof(StopBits), comboBox_stopbits.Text); } catch { errList.Add("Wrong Stopbits"); comboBox_stopbits.ForeColor = Color.Red; }
            try { deviceSettings.handshake = (Handshake)Enum.Parse(typeof(Handshake), comboBox_handshake.Text); } catch { errList.Add("Wrong Handshake"); comboBox_handshake.ForeColor = Color.Red; }
            try { deviceSettings.readtimeout = int.Parse(textBox_read_timeout.Text); } catch { errList.Add("Wrong Read timeout"); textBox_read_timeout.ForeColor = Color.Red; }
            try { deviceSettings.writetimeout = int.Parse(textBox_write_timeout.Text); } catch { errList.Add("Wrong Write timeout"); textBox_write_timeout.ForeColor = Color.Red; }

            if(errList.Count == 0)
            {
                valid = true;
            }
            else
            {
                for(int i = 0; i < errList.Count; i++)
                {
                    err += (i + 1).ToString() + ". " + errList[i] + "\n";
                }
                MessageBox.Show(err, "Error list");
            }

            // Save settings
            Serializator serializator = new Serializator();
            Settings allSettings;

            if(File.Exists(FileSettings))
            {
                allSettings = serializator.getSerialize(FileSettings);
                allSettings.deviceSettings = deviceSettings;
            }
            else
            {
                allSettings = new Settings();
                allSettings.deviceSettings = deviceSettings;
                allSettings.measureSettings = new MeasureSettings();
            }

            serializator.setSerialize(allSettings, FileSettings);
        }

        private void button_set_default_Click(object sender, EventArgs e)
        {
            DeviceSettings devSettings = new DeviceSettings();
            deviceSettings.portname = devSettings.portname;
            deviceSettings.baudrate = devSettings.baudrate;
            deviceSettings.parity = devSettings.parity;
            deviceSettings.databits = devSettings.databits;
            deviceSettings.stopbits = devSettings.stopbits;
            deviceSettings.handshake = devSettings.handshake;
            deviceSettings.readtimeout = devSettings.readtimeout;
            deviceSettings.writetimeout = devSettings.writetimeout;

            Serializator serializator = new Serializator();
            Settings allSettings;

            if (File.Exists(FileSettings))
            {
                allSettings = serializator.getSerialize(FileSettings);
                allSettings.deviceSettings = deviceSettings;
            }
            else
            {
                allSettings = new Settings();
                allSettings.deviceSettings = deviceSettings;
                allSettings.measureSettings = new MeasureSettings();
            }

            serializator.setSerialize(allSettings, FileSettings);
            setSettingsToTheInterface();
        }
    }
}
