using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DMAG_v1
{
    public partial class Form3_MeasureSettings : Form
    {
        /* Variables */
        MeasureSettings settings;
        string file;
        /**/

        /* clases */
        struct Gain
        {
            public string key { set; get; }
            public int value { set; get; }
        }

        List<Gain> listGain = new List<Gain>();
        /**/

        public Form3_MeasureSettings(MeasureSettings measureSettings, string fileSettings)
        {
            settings = measureSettings;
            file = fileSettings;

            InitializeComponent();
        }

        /* Functions */
        void setSettingsToTheInterface()
        {
            textBox_device_id.Text = "0x" + settings.deviceID.ToString("X");

            textBox_hall_sensor_currenr.Text = settings.sensorCurrent.ToString();
            comboBox_hall_sensor_gain1.SelectedIndex = Array.FindIndex(listGain.ToArray(), s => s.key == settings.sensorsGain1);
            comboBox_hall_sensor_gain2.SelectedIndex = Array.FindIndex(listGain.ToArray(), s => s.key == settings.sensorsGain2);

            textBox_stat_t.Text = settings.statCountT.ToString();
            textBox_stat_v.Text = settings.statCountV.ToString();

            textBox_k0.Text = settings.KT0.ToString();
            textBox_k1.Text = settings.KT1.ToString();
            textBox_pt100_current.Text = settings.pt100Current.ToString();
            comboBox_pt100_gain1.SelectedIndex = Array.FindIndex(listGain.ToArray(), s => s.key == settings.pt100Gain1);
            comboBox_pt100_gain2.SelectedIndex = Array.FindIndex(listGain.ToArray(), s => s.key == settings.pt100Gain2);

            comboBox_method_x.SelectedItem = settings.T_MethodX;
            textBox_k1_x.Text = settings.K1x.ToString();
            textBox_k2_x.Text = settings.K2x.ToString();
            textBox_k3_x.Text = settings.K3x.ToString();

            comboBox_method_y.SelectedItem = settings.T_MethodY;
            textBox_k1_y.Text = settings.K1y.ToString();
            textBox_k2_y.Text = settings.K2y.ToString();
            textBox_k3_y.Text = settings.K3y.ToString();

            comboBox_method_z.SelectedItem = settings.T_MethodZ;
            textBox_k1_z.Text = settings.K1z.ToString();
            textBox_k2_z.Text = settings.K2z.ToString();
            textBox_k3_z.Text = settings.K3z.ToString();

            comboBox_b_method_x.SelectedItem = settings.B_MethodX;
            textBox_a0_x.Text = settings.A0x.ToString();
            textBox_a1_x.Text = settings.A1x.ToString();
            textBox_a2_x.Text = settings.A2x.ToString();
            textBox_a3_x.Text = settings.A3x.ToString();

            comboBox_b_method_y.SelectedItem = settings.B_MethodY;
            textBox_a0_y.Text = settings.A0y.ToString();
            textBox_a1_y.Text = settings.A1y.ToString();
            textBox_a2_y.Text = settings.A2y.ToString();
            textBox_a3_y.Text = settings.A3y.ToString();

            comboBox_b_method_z.SelectedItem = settings.B_MethodZ;
            textBox_a0_z.Text = settings.A0z.ToString();
            textBox_a1_z.Text = settings.A1z.ToString();
            textBox_a2_z.Text = settings.A2z.ToString();
            textBox_a3_z.Text = settings.A3z.ToString();
        }
        /**/

        private void Form3_MeasureSettings_Load(object sender, EventArgs e)
        {
            // Fill comboboxes
            Gain gain = new Gain();

            gain.key = "1"; gain.value = 1; listGain.Add(gain);
            gain.key = "2"; gain.value = 2; listGain.Add(gain);
            gain.key = "3"; gain.value = 10; listGain.Add(gain);
            gain.key = "4"; gain.value = 50; listGain.Add(gain);
            gain.key = "5"; gain.value = 100; listGain.Add(gain);
            gain.key = "6"; gain.value = 200; listGain.Add(gain);
            gain.key = "7"; gain.value = 300; listGain.Add(gain);
            gain.key = "8"; gain.value = 500; listGain.Add(gain);
            gain.key = "9"; gain.value = 1000; listGain.Add(gain);

            for (int i = 0; i < listGain.Count; i++)
            {
                comboBox_hall_sensor_gain1.Items.Add(listGain[i].value);
                comboBox_hall_sensor_gain2.Items.Add(listGain[i].value);
                comboBox_pt100_gain1.Items.Add(listGain[i].value);
                comboBox_pt100_gain2.Items.Add(listGain[i].value);
            }

            // set settings to the interface (Device)
            setSettingsToTheInterface();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            // Validate settings
            ValidateData validateData = new ValidateData();
            List<ValidateData> listData = new List<ValidateData>();

            validateData.ctrl = textBox_device_id;
            validateData.type = "byte";
            validateData.errMessage = "Wrong format for Device ID";
            listData.Add(validateData);

            validateData.ctrl = textBox_hall_sensor_currenr;
            validateData.type = "double";
            validateData.errMessage = "Wrong format ror Hall sensors Current";
            listData.Add(validateData);

            validateData.ctrl = textBox_k0;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature sensor K0";
            listData.Add(validateData);

            validateData.ctrl = textBox_k1;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature sensor K1";
            listData.Add(validateData);

            validateData.ctrl = textBox_pt100_current;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature sensor Current";
            listData.Add(validateData);

            validateData.ctrl = textBox_stat_t;
            validateData.type = "int";
            validateData.errMessage = "Wrong format for Statistic statistic T";
            listData.Add(validateData);

            validateData.ctrl = textBox_stat_v;
            validateData.type = "int";
            validateData.errMessage = "Wrong format for Statistic statistic V";
            listData.Add(validateData);

            validateData.ctrl = textBox_k1_x;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-X K1";
            listData.Add(validateData);

            validateData.ctrl = textBox_k2_x;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-X K2";
            listData.Add(validateData);

            validateData.ctrl = textBox_k3_x;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-X K3";
            listData.Add(validateData);

            validateData.ctrl = textBox_k1_y;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-Y K1";
            listData.Add(validateData);

            validateData.ctrl = textBox_k2_y;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-Y K2";
            listData.Add(validateData);

            validateData.ctrl = textBox_k3_y;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-Y K3";
            listData.Add(validateData);

            validateData.ctrl = textBox_k1_z;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-Z K1";
            listData.Add(validateData);

            validateData.ctrl = textBox_k2_z;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-Z K2";
            listData.Add(validateData);

            validateData.ctrl = textBox_k3_z;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Temperature compensation Sensor-Z K3";
            listData.Add(validateData);

            validateData.ctrl = textBox_a0_x;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-X A0";
            listData.Add(validateData);

            validateData.ctrl = textBox_a1_x;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-X A1";
            listData.Add(validateData);

            validateData.ctrl = textBox_a2_x;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-X A2";
            listData.Add(validateData);

            validateData.ctrl = textBox_a3_x;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-X A3";
            listData.Add(validateData);

            validateData.ctrl = textBox_a0_y;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Y A0";
            listData.Add(validateData);

            validateData.ctrl = textBox_a1_y;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Y A1";
            listData.Add(validateData);

            validateData.ctrl = textBox_a2_y;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Y A2";
            listData.Add(validateData);

            validateData.ctrl = textBox_a3_y;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Y A3";
            listData.Add(validateData);

            validateData.ctrl = textBox_a0_z;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Z A0";
            listData.Add(validateData);

            validateData.ctrl = textBox_a1_z;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Z A1";
            listData.Add(validateData);

            validateData.ctrl = textBox_a2_z;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Z A2";
            listData.Add(validateData);

            validateData.ctrl = textBox_a3_z;
            validateData.type = "double";
            validateData.errMessage = "Wrong format for Conversion function Sensor-Z A3";
            listData.Add(validateData);

            // Set settings
            string validErrors = Validator.validate(listData);

            if(validErrors == null)
            {
                settings.deviceID = Convert.ToByte(textBox_device_id.Text, 16);
                settings.sensorCurrent = double.Parse(textBox_hall_sensor_currenr.Text);
                settings.sensorsGain1 = listGain[comboBox_hall_sensor_gain1.SelectedIndex].key;
                settings.sensorsGain2 = listGain[comboBox_hall_sensor_gain2.SelectedIndex].key;

                settings.KT0 = double.Parse(textBox_k0.Text);
                settings.KT1 = double.Parse(textBox_k1.Text);
                settings.pt100Current = double.Parse(textBox_pt100_current.Text);
                settings.pt100Gain1 = listGain[comboBox_pt100_gain1.SelectedIndex].key;
                settings.pt100Gain2 = listGain[comboBox_pt100_gain2.SelectedIndex].key;

                settings.statCountT = int.Parse(textBox_stat_t.Text);
                settings.statCountV = int.Parse(textBox_stat_v.Text);

                settings.T_MethodX = comboBox_method_x.Text;
                settings.K1x = double.Parse(textBox_k1_x.Text);
                settings.K2x = double.Parse(textBox_k2_x.Text);
                settings.K3x = double.Parse(textBox_k3_x.Text);

                settings.T_MethodY = comboBox_method_y.Text;
                settings.K1y = double.Parse(textBox_k1_y.Text);
                settings.K2y = double.Parse(textBox_k2_y.Text);
                settings.K3y = double.Parse(textBox_k3_y.Text);

                settings.T_MethodZ = comboBox_method_z.Text;
                settings.K1z = double.Parse(textBox_k1_z.Text);
                settings.K2z = double.Parse(textBox_k2_z.Text);
                settings.K3z = double.Parse(textBox_k3_z.Text);

                settings.B_MethodX = comboBox_b_method_x.Text;
                settings.A0x = double.Parse(textBox_a0_x.Text);
                settings.A1x = double.Parse(textBox_a1_x.Text);
                settings.A2x = double.Parse(textBox_a2_x.Text);
                settings.A3x = double.Parse(textBox_a3_x.Text);

                settings.B_MethodY = comboBox_b_method_y.Text;
                settings.A0y = double.Parse(textBox_a0_y.Text);
                settings.A1y = double.Parse(textBox_a1_y.Text);
                settings.A2y = double.Parse(textBox_a2_y.Text);
                settings.A3y = double.Parse(textBox_a3_y.Text);

                settings.B_MethodZ = comboBox_b_method_z.Text;
                settings.A0z = double.Parse(textBox_a0_z.Text);
                settings.A1z = double.Parse(textBox_a1_z.Text);
                settings.A2z = double.Parse(textBox_a2_z.Text);
                settings.A3z = double.Parse(textBox_a3_z.Text);

                // Save settings
                Serializator serializator = new Serializator();
                Settings allSettings;

                if(File.Exists(file))
                {
                    allSettings = serializator.getSerialize(file);
                }
                else
                {
                    allSettings = new Settings();
                    allSettings.deviceSettings = new DeviceSettings();
                }

                allSettings.measureSettings = settings;
                serializator.setSerialize(allSettings, file);
            }
            else
            {
                MessageBox.Show(validErrors, "Error list:");
            }
        }

        private void button_set_default_Click(object sender, EventArgs e)
        {
            MeasureSettings defaulSettings = new MeasureSettings();

            settings.deviceID = defaulSettings.deviceID;

            settings.sensorCurrent = defaulSettings.sensorCurrent;
            settings.sensorsGain1 = defaulSettings.sensorsGain1;
            settings.sensorsGain2 = defaulSettings.sensorsGain2;

            settings.KT0 = defaulSettings.KT0;
            settings.KT1 = defaulSettings.KT1;
            settings.pt100Current = defaulSettings.pt100Current;
            settings.pt100Gain1 = defaulSettings.pt100Gain1;
            settings.pt100Gain2 = defaulSettings.pt100Gain2;

            settings.statCountT = defaulSettings.statCountT;
            settings.statCountV = defaulSettings.statCountV;

            settings.T_MethodX = defaulSettings.T_MethodX;
            settings.K1x = defaulSettings.K1x;
            settings.K2x = defaulSettings.K2x;
            settings.K3x = defaulSettings.K3x;

            settings.T_MethodY = defaulSettings.T_MethodY;
            settings.K1y = defaulSettings.K1y;
            settings.K2y = defaulSettings.K2y;
            settings.K3y = defaulSettings.K3y;

            settings.T_MethodZ = defaulSettings.T_MethodZ;
            settings.K1z = defaulSettings.K1z;
            settings.K2z = defaulSettings.K2z;
            settings.K3z = defaulSettings.K3z;

            settings.B_MethodX = defaulSettings.B_MethodX;
            settings.A0x = defaulSettings.A0x;
            settings.A1x = defaulSettings.A1x;
            settings.A2x = defaulSettings.A2x;
            settings.A3x = defaulSettings.A3x;

            settings.B_MethodY = defaulSettings.B_MethodY;
            settings.A0y = defaulSettings.A0y;
            settings.A1y = defaulSettings.A1y;
            settings.A2y = defaulSettings.A2y;
            settings.A3y = defaulSettings.A3y;

            settings.B_MethodZ = defaulSettings.B_MethodZ;
            settings.A0z = defaulSettings.A0z;
            settings.A1z = defaulSettings.A1z;
            settings.A2z = defaulSettings.A2z;
            settings.A3z = defaulSettings.A3z;

            Serializator serializator = new Serializator();
            Settings allSettings;

            if (File.Exists(file))
            {
                allSettings = serializator.getSerialize(file);
            }
            else
            {
                allSettings = new Settings();
                allSettings.deviceSettings = new DeviceSettings();
            }

            allSettings.measureSettings = settings;
            
            serializator.setSerialize(allSettings, file);

            setSettingsToTheInterface();
        }
    }
}
