using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace _3DMAG_v1
{
    public partial class Form4_Calibration : Form
    {
        /* Variables */
        Settings settings;
        string fileSettings;
        bool doMeasure = false;
        /**/

        public Form4_Calibration(Settings settings, string fileSettings)
        {
            InitializeComponent();

            this.settings = settings;
            this.fileSettings = fileSettings;
        }

        /* Functions */
        bool checkEmptyTable(DataGridView table)
        {
            foreach(DataGridViewRow row in table.Rows)
            {
                for(int i = 0; i < table.ColumnCount; i++)
                {
                    if(row.Cells[i].Value != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /*
         * Function measure selected sensor
         * Use spinning current technique
         */
        double measureSensor(int sensorNumber, Control[] controls)
        {
            double V = 0;
            double statV = settings.measureSettings.statCountV;
            Device device = new Device(settings.measureSettings.deviceID, settings.deviceSettings);
            Measure measure = new Measure(device, settings.measureSettings);

            this.Invoke(new ThreadStart(() => {
                ControlsBlockUnblock.BlockIface(controls);
            }));

            device.openDevice();
            device.selectSensor(sensorNumber);

            for (int i = 0; i < settings.measureSettings.statCountV; i++)
            {
                if (doMeasure)
                {
                    V += measure.measureV();
                    statV = i + 1;
                }
                else
                {
                    break;
                }
            }

            device.closeDevice();
            doMeasure = false;
            V = V / statV;

            this.Invoke(new ThreadStart(() => {
                ControlsBlockUnblock.UnblockIface(controls);
            }));

            return V;
        }

        double[] calculateSensor(DataGridView table, string type, Chart chart)
        {
            double[] result = new double[6];

            List<double> X = new List<double>();
            List<double> Y = new List<double>();
            string separ = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            // Create arrays for calculate regression
            for (int i = 0; i < table.Rows.Count; i++)
            {
                double valX;
                double valY;

                if (table.Rows[i].Cells[0].Value != null && table.Rows[i].Cells[1].Value != null && double.TryParse(table.Rows[i].Cells[0].Value.ToString().Replace(".",separ).Replace(",", separ), out valX) && double.TryParse(table.Rows[i].Cells[1].Value.ToString().Replace(".", separ).Replace(",", separ), out valY))
                {
                    X.Add(valX);
                    Y.Add(valY * 1E-3);
                }
            }

            // Calculate regression
            Regress regress = new Regress(X.ToArray(), Y.ToArray());

            if (type == "Linear")
            {
                regress.linearRegression();
            }
            else
            {
                regress.polynomRegression();
            }

            result[0] = regress.A0;
            result[1] = regress.A1;
            result[2] = regress.A2;
            result[3] = regress.A3;
            result[4] = regress.R2;
            result[5] = regress.Err;

            // Show results
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();

            for(int i = 0; i < X.Count; i++)
            {
                chart.Series[0].Points.AddXY(X[i], Y[i]);
            }

            double stepX = (X.Last() - X[0]) / 100;

            for (int i = 0; i < 100; i++)
            {
                double x = X[0] + stepX * i;
                chart.Series[1].Points.AddXY(x, regress.A0 + regress.A1 * x + regress.A2 * Math.Pow(x, 2) + regress.A3 * Math.Pow(x,3));
            }

            return result;
        }

        /*
         * Event for KeyDown for tables
         */
        void tableAction(object sender, KeyEventArgs e)
        {
            DataGridView table = (DataGridView)sender;

            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell cell in table.SelectedCells)
                {
                    table.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = null;
                }
            }
            else if(e.KeyCode == Keys.C && e.Control)
            {
                Clipboard.SetText(table.SelectedCells.ToString());
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                string[] lines = Clipboard.GetText().Split('\n');

                if(lines.Length > 0 && table.CurrentCell != null)
                {
                    // check needed rows and add them if it needs
                    int neededRows = (table.Rows.Count - table.CurrentCell.RowIndex) - lines.Length;

                    if (neededRows < 0)
                    {
                        for(int i = 0; i < Math.Abs(neededRows); i++)
                        {
                            table.Rows.Add();
                        }
                    }

                    // paste data
                    int pastIndex = 0;
                    foreach (string line in lines)
                    {
                        string[] cell = line.Split('\t');

                        if(cell.Length > 0)
                        {
                            for (int j = 0; j < cell.Length; j++)
                            {
                                if ((j + table.CurrentCell.ColumnIndex) < table.ColumnCount && cell[j] != "")
                                {
                                    table.Rows[table.CurrentCell.RowIndex + pastIndex].Cells[j + table.CurrentCell.ColumnIndex].Value = cell[j];
                                }
                            }
                        }

                        pastIndex++;
                    }
                }
                
            }
        }
        /**/

        private void Form4_Calibration_Load(object sender, EventArgs e)
        {
            // set interface
            comboBox_method_x.SelectedItem = settings.measureSettings.B_MethodX;
            comboBox_method_y.SelectedItem = settings.measureSettings.B_MethodY;
            comboBox_method_z.SelectedItem = settings.measureSettings.B_MethodZ;

            label_r2x.Text = "R\xB2";  label_r2y.Text = "R\xB2";  label_r2z.Text = "R\xB2";
            label_a0x_val.Text = "0";  label_a0y_val.Text = "0";  label_a0z_val.Text = "0";
            label_a1x_val.Text = "0";  label_a1y_val.Text = "0";  label_a1z_val.Text = "0";
            label_a2x_val.Text = "0";  label_a2y_val.Text = "0";  label_a2z_val.Text = "0";
            label_a3x_val.Text = "0";  label_a3y_val.Text = "0";  label_a3z_val.Text = "0";
            label_r2x_val.Text = "0";  label_r2y_val.Text = "0";  label_r2z_val.Text = "0";
            label_errx_val.Text = "0"; label_erry_val.Text = "0"; label_errz_val.Text = "0";

            dataGridView_x.KeyDown += tableAction;
            dataGridView_y.KeyDown += tableAction;
            dataGridView_z.KeyDown += tableAction;
        }

        private void dataGridView_x_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_x.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_x.Rows[index].HeaderCell.Value = indexStr;
        }

        private void dataGridView_y_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_y.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_y.Rows[index].HeaderCell.Value = indexStr;
        }

        private void dataGridView_z_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_z.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_z.Rows[index].HeaderCell.Value = indexStr;
        }

        private void button_add_x_Click(object sender, EventArgs e)
        {
            dataGridView_x.Rows.Add();
        }

        private void button_add_y_Click(object sender, EventArgs e)
        {
            dataGridView_y.Rows.Add();
        }

        private void button_add_z_Click(object sender, EventArgs e)
        {
            dataGridView_z.Rows.Add();
        }

        private void button_del_x_Click(object sender, EventArgs e)
        {
            if(dataGridView_x.Rows.Count > 0)
            {
                dataGridView_x.Rows.RemoveAt(dataGridView_x.Rows.Count - 1);
            }
        }

        private void button_del_y_Click(object sender, EventArgs e)
        {
            if (dataGridView_y.Rows.Count > 0)
            {
                dataGridView_y.Rows.RemoveAt(dataGridView_y.Rows.Count - 1);
            }
        }

        private void button_del_z_Click(object sender, EventArgs e)
        {
            if (dataGridView_z.Rows.Count > 0)
            {
                dataGridView_z.Rows.RemoveAt(dataGridView_z.Rows.Count - 1);
            }
        }

        private void button_clear_x_Click(object sender, EventArgs e)
        {
            if(!checkEmptyTable(dataGridView_x))
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Do you really want to delete all data from this table?",
                    "Clear table",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView_x.Rows.Clear();
                }
            }
            else
            {
                dataGridView_x.Rows.Clear();
            }  
        }

        private void button_clear_y_Click(object sender, EventArgs e)
        {
            if (!checkEmptyTable(dataGridView_y))
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Do you really want to delete all data from this table?",
                    "Clear table",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView_y.Rows.Clear();
                }
            }
            else
            {
                dataGridView_y.Rows.Clear();
            }
        }

        private void button_clear_z_Click(object sender, EventArgs e)
        {
            if (!checkEmptyTable(dataGridView_z))
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Do you really want to delete all data from this table?",
                    "Clear table",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView_z.Rows.Clear();
                }
            }
            else
            {
                dataGridView_z.Rows.Clear();
            }
        }

        private void addRowBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = contextMenuStrip_table.SourceControl;
            DataGridView table = (DataGridView)ctrl;

            if(table.CurrentRow != null)
            {
                table.Rows.Insert(table.CurrentRow.Index);
            }
        }

        private void addRowAfterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = contextMenuStrip_table.SourceControl;
            DataGridView table = (DataGridView)ctrl;

            if(table.CurrentRow != null)
            {
                table.Rows.Insert(table.CurrentRow.Index + 1);
            }
        }

        private void delSelectedRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = contextMenuStrip_table.SourceControl;
            DataGridView table = (DataGridView)ctrl;
            
            foreach(DataGridViewRow rows in table.SelectedRows)
            {
                table.Rows.RemoveAt(rows.Index);
            }
        }

        private void delSelectedDataDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = contextMenuStrip_table.SourceControl;
            DataGridView table = (DataGridView)ctrl;

            foreach(DataGridViewCell cell in table.SelectedCells)
            {
                table.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = null;
            }
        }

        private void comboBox_method_x_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_method_x.Text == "Linear")
            {
                pictureBox_x.Image = Properties.Resources.v_b_formula_linear;
            }
            else
            {
                pictureBox_x.Image = Properties.Resources.v_b_formula;
            }
        }

        private void comboBox_method_y_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_method_y.Text == "Linear")
            {
                pictureBox_y.Image = Properties.Resources.v_b_formula_linear;
            }
            else
            {
                pictureBox_y.Image = Properties.Resources.v_b_formula;
            }
        }

        private void comboBox_method_z_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_method_z.Text == "Linear")
            {
                pictureBox_z.Image = Properties.Resources.v_b_formula_linear;
            }
            else
            {
                pictureBox_z.Image = Properties.Resources.v_b_formula;
            }
        }

        private void button_measure_x_Click(object sender, EventArgs e)
        {
            Control[] controls = new Control[] { button_calculate_x, button_measure_x, button_calculate_y, button_measure_y, button_calculate_z, button_measure_z };
            doMeasure = true;

            Thread th = new Thread(() => {

                double voltage = measureSensor(1, controls);
                int i;

                this.Invoke(new ThreadStart(() => {
                    if(dataGridView_x.CurrentCell != null)
                    {
                        i = dataGridView_x.CurrentCell.RowIndex;
                        
                    }
                    else
                    {
                        i = dataGridView_x.Rows.Add();
                    }

                    dataGridView_x.Rows[i].Cells[0].Value = voltage;
                }));

            }); th.IsBackground = true; th.Start();
        }

        private void button_measure_y_Click(object sender, EventArgs e)
        {
            Control[] controls = new Control[] { button_calculate_x, button_measure_x, button_calculate_y, button_measure_y, button_calculate_z, button_measure_z };
            doMeasure = true;

            Thread th = new Thread(() => {

                double voltage = measureSensor(2, controls);
                int i;

                this.Invoke(new ThreadStart(() => {
                    if (dataGridView_y.CurrentCell != null)
                    {
                        i = dataGridView_y.CurrentCell.RowIndex;

                    }
                    else
                    {
                        i = dataGridView_y.Rows.Add();
                    }

                    dataGridView_y.Rows[i].Cells[0].Value = voltage;
                }));

            }); th.IsBackground = true; th.Start();
        }

        private void button_measure_z_Click(object sender, EventArgs e)
        {
            Control[] controls = new Control[] { button_calculate_x, button_measure_x, button_calculate_y, button_measure_y, button_calculate_z, button_measure_z };
            doMeasure = true;

            Thread th = new Thread(() => {

                double voltage = measureSensor(3, controls);
                int i;

                this.Invoke(new ThreadStart(() => {
                    if (dataGridView_z.CurrentCell != null)
                    {
                        i = dataGridView_z.CurrentCell.RowIndex;

                    }
                    else
                    {
                        i = dataGridView_z.Rows.Add();
                    }

                    dataGridView_z.Rows[i].Cells[0].Value = voltage;
                }));

            }); th.IsBackground = true; th.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            doMeasure = false;
        }

        private void button_stop_y_Click(object sender, EventArgs e)
        {
            doMeasure = false;
        }

        private void button_stop_z_Click(object sender, EventArgs e)
        {
            doMeasure = false;
        }

        private void button_calculate_x_Click(object sender, EventArgs e)
        {
            double[] result = calculateSensor(dataGridView_x, comboBox_method_x.Text, chart_x);

            label_a0x_val.Text = result[0].ToString();
            label_a1x_val.Text = result[1].ToString();
            label_a2x_val.Text = result[2].ToString();
            label_a3x_val.Text = result[3].ToString();
            label_r2x_val.Text = result[4].ToString();
            label_errx_val.Text = result[5].ToString("F3");

        }

        private void button_calculate_y_Click(object sender, EventArgs e)
        {
            double[] result = calculateSensor(dataGridView_y, comboBox_method_y.Text, chart_y);

            label_a0y_val.Text = result[0].ToString();
            label_a1y_val.Text = result[1].ToString();
            label_a2y_val.Text = result[2].ToString();
            label_a3y_val.Text = result[3].ToString();
            label_r2y_val.Text = result[4].ToString();
            label_erry_val.Text = result[5].ToString("F3");
        }

        private void button_calculate_z_Click(object sender, EventArgs e)
        {
            double[] result = calculateSensor(dataGridView_z, comboBox_method_z.Text, chart_z);

            label_a0z_val.Text = result[0].ToString();
            label_a1z_val.Text = result[1].ToString();
            label_a2z_val.Text = result[2].ToString();
            label_a3z_val.Text = result[3].ToString();
            label_r2z_val.Text = result[4].ToString();
            label_errz_val.Text = result[5].ToString("F3");
        }

        private void button_save_x_Click(object sender, EventArgs e)
        {
            settings.measureSettings.B_MethodX = comboBox_method_x.Text;
            settings.measureSettings.A0x = double.Parse(label_a0x_val.Text);
            settings.measureSettings.A1x = double.Parse(label_a1x_val.Text);
            settings.measureSettings.A2x = double.Parse(label_a2x_val.Text);
            settings.measureSettings.A3x = double.Parse(label_a3x_val.Text);

            Serializator serializator = new Serializator();
            serializator.setSerialize(settings, fileSettings);
        }

        private void button_save_y_Click(object sender, EventArgs e)
        {
            settings.measureSettings.B_MethodY = comboBox_method_y.Text;
            settings.measureSettings.A0y = double.Parse(label_a0y_val.Text);
            settings.measureSettings.A1y = double.Parse(label_a1y_val.Text);
            settings.measureSettings.A2y = double.Parse(label_a2y_val.Text);
            settings.measureSettings.A3y = double.Parse(label_a3y_val.Text);

            Serializator serializator = new Serializator();
            serializator.setSerialize(settings, fileSettings);
        }

        private void button_save_z_Click(object sender, EventArgs e)
        {
            settings.measureSettings.B_MethodZ = comboBox_method_z.Text;
            settings.measureSettings.A0z = double.Parse(label_a0z_val.Text);
            settings.measureSettings.A1z = double.Parse(label_a1z_val.Text);
            settings.measureSettings.A2z = double.Parse(label_a2z_val.Text);
            settings.measureSettings.A3z = double.Parse(label_a3z_val.Text);

            Serializator serializator = new Serializator();
            serializator.setSerialize(settings, fileSettings);
        }

        private void button_save_all_Click(object sender, EventArgs e)
        {
            settings.measureSettings.B_MethodX = comboBox_method_x.Text;
            settings.measureSettings.A0x = double.Parse(label_a0x_val.Text);
            settings.measureSettings.A1x = double.Parse(label_a1x_val.Text);
            settings.measureSettings.A2x = double.Parse(label_a2x_val.Text);
            settings.measureSettings.A3x = double.Parse(label_a3x_val.Text);

            settings.measureSettings.B_MethodY = comboBox_method_y.Text;
            settings.measureSettings.A0y = double.Parse(label_a0y_val.Text);
            settings.measureSettings.A1y = double.Parse(label_a1y_val.Text);
            settings.measureSettings.A2y = double.Parse(label_a2y_val.Text);
            settings.measureSettings.A3y = double.Parse(label_a3y_val.Text);

            settings.measureSettings.B_MethodZ = comboBox_method_z.Text;
            settings.measureSettings.A0z = double.Parse(label_a0z_val.Text);
            settings.measureSettings.A1z = double.Parse(label_a1z_val.Text);
            settings.measureSettings.A2z = double.Parse(label_a2z_val.Text);
            settings.measureSettings.A3z = double.Parse(label_a3z_val.Text);

            Serializator serializator = new Serializator();
            serializator.setSerialize(settings, fileSettings);
        }
    }
}
