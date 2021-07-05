using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace _3DMAG_v1
{
    public partial class Form1 : Form
    {
        /* Variables */
        string fileSettings = "settings.xml";
        string fileLog = null;
        Device device;
        Settings settings;
        Serializator serializator = new Serializator();
        bool doMeasure = false;
        bool saveLog = false;
        bool delExistFile = false;
        /**/

        public Form1()
        {
            InitializeComponent();
        }

        /* Functions */
        /*
         * Function calculate Value from voltage by linear aproximation
         */
        double voltToValue(double V, double K1, double K0)
        {
            return V * K1 + K0;
        }

        /*
         * Function clear points in all series in charts
         */
        void clearCharts(Chart[] charts)
        {
            foreach(Chart ch in charts)
            {
                for(int i = 0; i < ch.Series.Count; i++)
                {
                    ch.Series[i].Points.Clear();
                }
            }
        }

        /*
         * Function build chart and control chart point in series
         */
        void buildChart(Chart ch, int serieNumber, DateTime X, double Y, int limitPoints)
        {
            if (Math.Abs(Y) < (Double)Decimal.MaxValue)
            {
                ch.Series[serieNumber].Points.AddXY(X, Y);
            }

            if (limitPoints > 0)
            {
                if (ch.Series[serieNumber].Points.Count > limitPoints)
                {
                    ch.Series[serieNumber].Points.RemoveAt(0);
                    ch.ResetAutoValues();
                }
            }
        }

        /*
         * Function calculate units coefficient
         */
        double unitsK(string units)
        {
            double Coef = 1;
            string Symb = units.Substring(0, 1);

            switch (Symb)
            {
                case "m":
                    Coef = 1E3;
                    break;
                case "µ":
                    Coef = 1E6;
                    break;
                case "n":
                    Coef = 1E9;
                    break;
                case "k":
                    Coef = 1E-3;
                    break;
                case "M":
                    Coef = 1E-6;
                    break;
            }

            return Coef;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set settings
            if(File.Exists(fileSettings))
            {
                settings = serializator.getSerialize(fileSettings);
            }
            else
            {
                settings = new Settings();
                settings.deviceSettings = new DeviceSettings();
                settings.measureSettings = new MeasureSettings();
                serializator.setSerialize(settings, fileSettings);
            }

            // Set data to the interface
            comboBox_mode.SelectedItem = settings.measureSettings.measureMode;
            comboBox_units.SelectedItem = settings.measureSettings.fieldUnits;
            textBox_chart_points.Text = settings.measureSettings.chartPoints.ToString();
            textBox_cycle_delay.Text = settings.measureSettings.delayCycle.ToString();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            // Variables
            int pointNumber = 0;
            DateTime DT;
            double timeSpan = 0;
            double K = unitsK(comboBox_units.Text);
            int statT = 1;
            int statV = 1;
            
            // Validate settings
            ValidateData validateData = new ValidateData();
            List<ValidateData> listValidete = new List<ValidateData>();

            validateData.ctrl = textBox_chart_points;
            validateData.type = "int";
            validateData.errMessage = "Wrong value for Chart points";
            listValidete.Add(validateData);

            validateData.ctrl = textBox_cycle_delay;
            validateData.type = "int";
            validateData.errMessage = "Wrong format for Cycle delay";
            listValidete.Add(validateData);

            string validationErrors = Validator.validate(listValidete);

            if (validationErrors == null)
            {
                // block interface
                Control[] controls = new Control[] {menuStrip1, button_start, comboBox_carts };
                ControlsBlockUnblock.BlockIface(controls);
                label_log.Text = "Log: Measure started";
                
                // apply settings
                settings.measureSettings.chartPoints = int.Parse(textBox_chart_points.Text);
                settings.measureSettings.fieldUnits = comboBox_units.Text;
                settings.measureSettings.delayCycle = int.Parse(textBox_cycle_delay.Text);
                settings.measureSettings.measureMode = comboBox_mode.Text;

                chart_B.ChartAreas[0].AxisY.Title = "B [" + comboBox_units.Text + "]";

                if(comboBox_carts.Text == "T")
                {
                    chart_add.ChartAreas[0].AxisY.Title = "T [°C]";
                }
                else
                {
                    chart_add.ChartAreas[0].AxisY.Title = "B [" + comboBox_units.Text + "]";
                }

                // remove existing file
                if(saveLog && fileLog != null && delExistFile)
                {
                    if(File.Exists(fileLog))
                    {
                        File.Delete(fileLog);
                    }
                    delExistFile = false;
                }

                // start measure
                doMeasure = true;
                DateTime DT0 = DateTime.Now;
                Device device = new Device(settings.measureSettings.deviceID, settings.deviceSettings);
                Measure measure = new Measure(device, settings.measureSettings);

                // create file header
                string fileHeader = null;

                if (saveLog && fileLog != null)
                {
                    switch(settings.measureSettings.measureMode)
                    {
                        case "1D":
                            fileHeader = $"#\tDateTime\tTimeSpan\tB [{settings.measureSettings.fieldUnits}]\tT[°C]";
                            break;
                        case "2D":
                            fileHeader = $"#\tDateTime\tTimeSpan\tB [{settings.measureSettings.fieldUnits}]\tBx [{settings.measureSettings.fieldUnits}]\tBy [{settings.measureSettings.fieldUnits}]\tT[°C]";
                            break;
                        case "3D":
                            fileHeader = $"#\tDateTime\tTimeSpan\tB [{settings.measureSettings.fieldUnits}]\tBx [{settings.measureSettings.fieldUnits}]\tBy [{settings.measureSettings.fieldUnits}]\tBz [{settings.measureSettings.fieldUnits}]\tT[°C]";
                            break;
                    }
                }

                // add last file data if append to file
                if (saveLog && File.Exists(fileLog))
                {
                    string lastLine = File.ReadLines(fileLog).Last();
                    string[] spliter = lastLine.Split('\t');

                    try
                    {
                        pointNumber = int.Parse(spliter[0]);
                        DT0 = DateTime.Parse(spliter[1]);
                        timeSpan = double.Parse(spliter[2]);
                    }
                    catch { }
                }

                device.openDevice();

                Thread th = new Thread(() => {
                    while(doMeasure)
                    {
                        double T = 0;
                        double B = 0;
                        double Bx = 0;
                        double By = 0;
                        double Bz = 0;
                        string fileData = null;
                        Stopwatch sw = new Stopwatch();

                        // start time calculator
                        sw.Start();

                        // additional data
                        DT = DateTime.Now;
                        pointNumber++;

                        if(pointNumber > 1)
                        {
                            timeSpan = timeSpan + (DT - DT0).TotalSeconds;
                        }

                        DT0 = DT;

                        // measure T
                        for(int i = 0; i < settings.measureSettings.statCountT; i++)
                        {
                            if(doMeasure)
                            {
                                T += measure.measureT();
                                statT = i + 1;
                            }
                            else
                            {
                                break;
                            }
                        }

                        T = T / statT;

                        // save log
                        if(saveLog && fileLog != null)
                        {
                            fileData = pointNumber + "\t" + DT + "\t" + timeSpan + "\t";
                        }

                        // set sensors settings
                        device.setSensorCurrentValue(settings.measureSettings.sensorCurrent);
                        device.setGains(settings.measureSettings.sensorsGain1 + settings.measureSettings.sensorsGain2);

                        if (settings.measureSettings.measureMode == "1D")
                        {
                            // measure sensor Z
                            device.selectSensor(3);

                            for(int i = 0; i < settings.measureSettings.statCountV; i++)
                            {
                                if(doMeasure)
                                {
                                    Bx += measure.measureV();
                                    statV = i + 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // temperature correction
                            if (settings.measureSettings.T_MethodX == "Linear")
                            {
                                Bz = TemperatureCorrection.linearCorrection(Bx / statV, T, settings.measureSettings.K1x);
                            }
                            else
                            {
                                Bz = TemperatureCorrection.polynomCorrection(Bx / statV, T, settings.measureSettings.K1x, settings.measureSettings.K2x, settings.measureSettings.K3x);
                            }

                            // conversation function
                            if(settings.measureSettings.B_MethodX == "Linear")
                            {
                                Bz = ConversionFunction.linearConversion(Bx, settings.measureSettings.A0x, settings.measureSettings.A1x) * unitsK(settings.measureSettings.fieldUnits);
                            }
                            else
                            {
                                Bz = ConversionFunction.polynomConversion(Bx, settings.measureSettings.A0x, settings.measureSettings.A1x, settings.measureSettings.A2x, settings.measureSettings.A3x) * unitsK(settings.measureSettings.fieldUnits);
                            }

                            // Calculate B
                            B = Bz;

                            // Out results to the file and to the interface
                            if (doMeasure)
                            {
                                // save log
                                if (saveLog && fileLog != null)
                                {
                                    fileData += B + "\t";
                                }

                                // to interface
                                this.Invoke(new ThreadStart(() => {
                                    buildChart(chart_B, 0, DT, B, settings.measureSettings.chartPoints);
                                    label_b.Text = "B = " + B.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_bz.Text = "Bz = " + Bz.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_t.Text = "T = " + T.ToString("F5") + " [°C]";

                                    buildChart(chart_add, 0, DT, T, settings.measureSettings.chartPoints);
                                }));
                            } 
                        }
                        else if (settings.measureSettings.measureMode == "2D")
                        {
                            // measure sensor X
                            device.selectSensor(1);

                            for (int i = 0; i < settings.measureSettings.statCountV; i++)
                            {
                                if (doMeasure)
                                {
                                    Bx += measure.measureV();
                                    statV = i + 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // measure sensor Y
                            device.selectSensor(2);

                            for (int i = 0; i < settings.measureSettings.statCountV; i++)
                            {
                                if (doMeasure)
                                {
                                    By += measure.measureV();
                                    statV = i + 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // temperature correction
                            if (settings.measureSettings.T_MethodX == "Linear")
                            {
                                Bx = TemperatureCorrection.linearCorrection(Bx / statV, T, settings.measureSettings.K1x);
                            }
                            else
                            {
                                Bx = TemperatureCorrection.polynomCorrection(Bx / statV, T, settings.measureSettings.K1x, settings.measureSettings.K2x, settings.measureSettings.K3x);
                            }

                            if (settings.measureSettings.T_MethodY == "Linear")
                            {
                                By = TemperatureCorrection.linearCorrection(By / statV, T, settings.measureSettings.K1y);
                            }
                            else
                            {
                                By = TemperatureCorrection.polynomCorrection(By / statV, T, settings.measureSettings.K1y, settings.measureSettings.K2y, settings.measureSettings.K3y);
                            }

                            // conversation function
                            if (settings.measureSettings.B_MethodX == "Linear")
                            {
                                Bx = ConversionFunction.linearConversion(Bx, settings.measureSettings.A0x, settings.measureSettings.A1x) * unitsK(settings.measureSettings.fieldUnits);
                            }
                            else
                            {
                                Bx = ConversionFunction.polynomConversion(Bx, settings.measureSettings.A0x, settings.measureSettings.A1x, settings.measureSettings.A2x, settings.measureSettings.A3x) * unitsK(settings.measureSettings.fieldUnits);
                            }

                            if (settings.measureSettings.B_MethodX == "Linear")
                            {
                                By = ConversionFunction.linearConversion(By, settings.measureSettings.A0y, settings.measureSettings.A1y) * unitsK(settings.measureSettings.fieldUnits);
                            }
                            else
                            {
                                By = ConversionFunction.polynomConversion(By, settings.measureSettings.A0y, settings.measureSettings.A1y, settings.measureSettings.A2y, settings.measureSettings.A3y) * unitsK(settings.measureSettings.fieldUnits);
                            }

                            // Calculate B
                            B = Math.Sqrt(Math.Pow(Bx, 2) + Math.Pow(By, 2));

                            // Out results to the file and to the interface
                            if (doMeasure)
                            {
                                // save log
                                if (saveLog && fileLog != null)
                                {
                                    fileData += B + "\t" + Bx + "\t" + By + "\t";
                                }

                                // to the interface
                                this.Invoke(new ThreadStart(() => {
                                    buildChart(chart_B, 0, DT, Bx, settings.measureSettings.chartPoints);
                                    label_b.Text = "B = " + B.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_bx.Text = "Bx = " + Bx.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_by.Text = "By = " + By.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_t.Text = "T = " + T.ToString("F5") + " [°C]";

                                    switch (comboBox_carts.Text)
                                    {
                                        case "T":
                                            buildChart(chart_add, 0, DT, T, settings.measureSettings.chartPoints);
                                            break;
                                        case "Bx":
                                            buildChart(chart_add, 1, DT, Bx, settings.measureSettings.chartPoints);
                                            break;
                                        case "By":
                                            buildChart(chart_add, 2, DT, By, settings.measureSettings.chartPoints);
                                            break;
                                        case "BxBy":
                                            buildChart(chart_add, 1, DT, Bx, settings.measureSettings.chartPoints);
                                            buildChart(chart_add, 2, DT, By, settings.measureSettings.chartPoints);
                                            break;
                                    }
                                }));
                            }
                        }
                        else if (settings.measureSettings.measureMode == "3D")
                        {
                            // measure sensor X
                            device.selectSensor(1);

                            for (int i = 0; i < settings.measureSettings.statCountV; i++)
                            {
                                if (doMeasure)
                                {
                                    Bx += measure.measureV();
                                    statV = i + 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // measure sensor Y
                            device.selectSensor(2);

                            for (int i = 0; i < settings.measureSettings.statCountV; i++)
                            {
                                if (doMeasure)
                                {
                                    By += measure.measureV();
                                    statV = i + 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // measure sensor Z
                            device.selectSensor(3);

                            for (int i = 0; i < settings.measureSettings.statCountV; i++)
                            {
                                if (doMeasure)
                                {
                                    Bz += measure.measureV();
                                    statV = i + 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // temperature correction
                            if (settings.measureSettings.T_MethodX == "Linear")
                            {
                                Bx = TemperatureCorrection.linearCorrection(Bx / statV, T, settings.measureSettings.K1x);
                            }
                            else
                            {
                                Bx = TemperatureCorrection.polynomCorrection(Bx / statV, T, settings.measureSettings.K1x, settings.measureSettings.K2x, settings.measureSettings.K3x);
                            }

                            if (settings.measureSettings.T_MethodY == "Linear")
                            {
                                By = TemperatureCorrection.linearCorrection(By / statV, T, settings.measureSettings.K1y);
                            }
                            else
                            {
                                By = TemperatureCorrection.polynomCorrection(By / statV, T, settings.measureSettings.K1y, settings.measureSettings.K2y, settings.measureSettings.K3y);
                            }

                            if (settings.measureSettings.T_MethodZ == "Linear")
                            {
                                Bz = TemperatureCorrection.linearCorrection(Bz / statV, T, settings.measureSettings.K1z);
                            }
                            else
                            {
                                Bz = TemperatureCorrection.polynomCorrection(Bz / statV, T, settings.measureSettings.K1z, settings.measureSettings.K2z, settings.measureSettings.K3z);
                            }

                            // conversation function
                            if (settings.measureSettings.B_MethodX == "Linear")
                            {
                                Bx = ConversionFunction.linearConversion(Bx, settings.measureSettings.A0x, settings.measureSettings.A1x) * unitsK(settings.measureSettings.fieldUnits);
                            }
                            else
                            {
                                Bx = ConversionFunction.polynomConversion(Bx, settings.measureSettings.A0x, settings.measureSettings.A1x, settings.measureSettings.A2x, settings.measureSettings.A3x) * unitsK(settings.measureSettings.fieldUnits);
                            }

                            if (settings.measureSettings.B_MethodX == "Linear")
                            {
                                By = ConversionFunction.linearConversion(By, settings.measureSettings.A0y, settings.measureSettings.A1y) * unitsK(settings.measureSettings.fieldUnits);
                            }
                            else
                            {
                                By = ConversionFunction.polynomConversion(By, settings.measureSettings.A0y, settings.measureSettings.A1y, settings.measureSettings.A2y, settings.measureSettings.A3y) * unitsK(settings.measureSettings.fieldUnits);
                            }

                            if (settings.measureSettings.B_MethodX == "Linear")
                            {
                                Bz = ConversionFunction.linearConversion(Bz, settings.measureSettings.A0z, settings.measureSettings.A1z) * unitsK(settings.measureSettings.fieldUnits);
                            }
                            else
                            {
                                Bz = ConversionFunction.polynomConversion(Bz, settings.measureSettings.A0z, settings.measureSettings.A1z, settings.measureSettings.A2z, settings.measureSettings.A3z) * unitsK(settings.measureSettings.fieldUnits);
                            }

                            // Calculate B
                            B = Math.Sqrt(Math.Pow(Bx, 2) + Math.Pow(By, 2) + Math.Pow(Bz, 2));

                            // Out results to the file and to the interface
                            if (doMeasure)
                            {
                                // save log
                                if (saveLog && fileLog != null)
                                {
                                    fileData += B + "\t" + Bx + "\t" + By + "\t" + Bz + "\t";
                                }

                                // to the interface
                                this.Invoke(new ThreadStart(() => {
                                    buildChart(chart_B, 0, DT, Bx, settings.measureSettings.chartPoints);
                                    label_b.Text = "B = " + B.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_bx.Text = "Bx = " + Bx.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_by.Text = "By = " + By.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_bz.Text = "Bz = " + Bz.ToString("F5") + " [" + comboBox_units.Text + "]";
                                    label_t.Text = "T = " + T.ToString("F5") + " [°C]";

                                    switch (comboBox_carts.Text)
                                    {
                                        case "T":
                                            buildChart(chart_add, 0, DT, T, settings.measureSettings.chartPoints);
                                            break;
                                        case "Bx":
                                            buildChart(chart_add, 1, DT, Bx, settings.measureSettings.chartPoints);
                                            break;
                                        case "By":
                                            buildChart(chart_add, 2, DT, By, settings.measureSettings.chartPoints);
                                            break;
                                        case "Bz":
                                            buildChart(chart_add, 3, DT, Bz, settings.measureSettings.chartPoints);
                                            break;
                                        case "BxBy":
                                            buildChart(chart_add, 1, DT, Bx, settings.measureSettings.chartPoints);
                                            buildChart(chart_add, 2, DT, By, settings.measureSettings.chartPoints);
                                            break;
                                        case "BxBz":
                                            buildChart(chart_add, 1, DT, Bx, settings.measureSettings.chartPoints);
                                            buildChart(chart_add, 3, DT, Bz, settings.measureSettings.chartPoints);
                                            break;
                                        case "ByBz":
                                            buildChart(chart_add, 2, DT, By, settings.measureSettings.chartPoints);
                                            buildChart(chart_add, 3, DT, Bz, settings.measureSettings.chartPoints);
                                            break;
                                        case "BxByBz":
                                            buildChart(chart_add, 1, DT, Bx, settings.measureSettings.chartPoints);
                                            buildChart(chart_add, 2, DT, By, settings.measureSettings.chartPoints);
                                            buildChart(chart_add, 3, DT, Bz, settings.measureSettings.chartPoints);
                                            break;
                                    }
                                }));
                            }
                        }

                        // save log
                        if (doMeasure && saveLog && fileLog != null)
                        {
                            fileData += T;

                            if(!File.Exists(fileLog))
                            {
                                using (StreamWriter sr = new StreamWriter(fileLog))
                                {
                                    sr.WriteLine(fileHeader);
                                }
                            }

                            using(StreamWriter sr = new StreamWriter(fileLog, true))
                            {
                                sr.WriteLine(fileData);
                            }
                        }

                        // stop time calculator
                        sw.Stop();

                        this.Invoke(new ThreadStart(() => {
                            label_cycle_time.Text = "Cycle time: " + (sw.ElapsedMilliseconds / 1E3).ToString("F3");
                        }));

                        // wait next cycle
                        if (settings.measureSettings.delayCycle > 0)
                        {
                            Thread.Sleep(settings.measureSettings.delayCycle * 1000);
                        }
                    }

                    device.closeDevice();

                    // Unblock interface
                    this.Invoke(new ThreadStart(() => {
                        ControlsBlockUnblock.UnblockIface(controls);
                        label_log.Text = "Log: Measure finished";
                    }));

                }); th.IsBackground = true; th.Start();
            }
            else
            {
                MessageBox.Show(validationErrors, "Error list:");
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            doMeasure = false;
        }

        private void connectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2_ConnectionSettings F2_CS = new Form2_ConnectionSettings(settings.deviceSettings, fileSettings);
            F2_CS.ShowDialog();
        }

        private void measureSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3_MeasureSettings F3_MS = new Form3_MeasureSettings(settings.measureSettings, fileSettings);
            F3_MS.ShowDialog();
        }

        private void calibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4_Calibration F4_Calibration = new Form4_Calibration(settings, fileSettings);
            F4_Calibration.ShowDialog();
        }

        private void comboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_carts.Items.Clear();

            switch(comboBox_mode.Text)
            {
                case "1D":
                    comboBox_carts.Items.Add("T");
                    break;
                case "2D":
                    comboBox_carts.Items.Add("T");
                    comboBox_carts.Items.Add("Bx");
                    comboBox_carts.Items.Add("By");
                    comboBox_carts.Items.Add("BxBy");
                    break;
                case "3D":
                    comboBox_carts.Items.Add("T");
                    comboBox_carts.Items.Add("Bx");
                    comboBox_carts.Items.Add("By");
                    comboBox_carts.Items.Add("Bz");
                    comboBox_carts.Items.Add("BxBy");
                    comboBox_carts.Items.Add("BxBz");
                    comboBox_carts.Items.Add("ByBz");
                    comboBox_carts.Items.Add("BxByBz");
                    break;
            }

            comboBox_carts.SelectedItem = "T";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = contextMenuStrip_charts.SourceControl;
            Chart chart = (Chart)ctrl;
            chart.Series[0].Points.Clear();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart[] charts = new Chart[] { chart_B, chart_add };
            clearCharts(charts);
        }

        private void checkBox_save_log_CheckedChanged(object sender, EventArgs e)
        {
            saveLog = checkBox_save_log.Checked;
        }

        private void button_brovse_Click(object sender, EventArgs e)
        {
            if(saveFileDialog_log.ShowDialog() == DialogResult.OK)
            {
                // Check for file exist
                if(File.Exists(saveFileDialog_log.FileName))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "Selected file exist!\nDo You want overwrite it?\n'Yes' - overwrite file\n'No' - append data to the existing file",
                        "File Exist message",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Asterisk
                        );

                    if(dialogResult == DialogResult.Yes)
                    {
                        fileLog = saveFileDialog_log.FileName;
                        delExistFile = true;
                        checkBox_save_log.Checked = true;
                    }
                    else if(dialogResult == DialogResult.No)
                    {
                        fileLog = saveFileDialog_log.FileName;
                        checkBox_save_log.Checked = true;
                    }
                    else
                    {
                        fileLog = null;
                        checkBox_save_log.Checked = false;
                    }
                }
                else
                {
                    fileLog = saveFileDialog_log.FileName;
                    checkBox_save_log.Checked = true;
                }

                label_file.Text = $"File: {fileLog}";
            }
        }
    }
}
