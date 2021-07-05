namespace _3DMAG_v1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox_manage = new System.Windows.Forms.GroupBox();
            this.button_brovse = new System.Windows.Forms.Button();
            this.checkBox_save_log = new System.Windows.Forms.CheckBox();
            this.panel_file = new System.Windows.Forms.Panel();
            this.label_file = new System.Windows.Forms.Label();
            this.label_cycle_time = new System.Windows.Forms.Label();
            this.label_t = new System.Windows.Forms.Label();
            this.label_bz = new System.Windows.Forms.Label();
            this.label_by = new System.Windows.Forms.Label();
            this.label_bx = new System.Windows.Forms.Label();
            this.label_b = new System.Windows.Forms.Label();
            this.comboBox_units = new System.Windows.Forms.ComboBox();
            this.label_units = new System.Windows.Forms.Label();
            this.textBox_cycle_delay = new System.Windows.Forms.TextBox();
            this.textBox_chart_points = new System.Windows.Forms.TextBox();
            this.label_cycle_delay = new System.Windows.Forms.Label();
            this.label_chart_points = new System.Windows.Forms.Label();
            this.comboBox_carts = new System.Windows.Forms.ComboBox();
            this.label_charts = new System.Windows.Forms.Label();
            this.comboBox_mode = new System.Windows.Forms.ComboBox();
            this.label_mode = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chart_B = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip_charts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart_add = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_log = new System.Windows.Forms.Label();
            this.saveFileDialog_log = new System.Windows.Forms.SaveFileDialog();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measureSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox_manage.SuspendLayout();
            this.panel_file.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_B)).BeginInit();
            this.contextMenuStrip_charts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_add)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.calibrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1060, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_manage);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1060, 410);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox_manage
            // 
            this.groupBox_manage.Controls.Add(this.button_brovse);
            this.groupBox_manage.Controls.Add(this.checkBox_save_log);
            this.groupBox_manage.Controls.Add(this.panel_file);
            this.groupBox_manage.Controls.Add(this.label_cycle_time);
            this.groupBox_manage.Controls.Add(this.label_t);
            this.groupBox_manage.Controls.Add(this.label_bz);
            this.groupBox_manage.Controls.Add(this.label_by);
            this.groupBox_manage.Controls.Add(this.label_bx);
            this.groupBox_manage.Controls.Add(this.label_b);
            this.groupBox_manage.Controls.Add(this.comboBox_units);
            this.groupBox_manage.Controls.Add(this.label_units);
            this.groupBox_manage.Controls.Add(this.textBox_cycle_delay);
            this.groupBox_manage.Controls.Add(this.textBox_chart_points);
            this.groupBox_manage.Controls.Add(this.label_cycle_delay);
            this.groupBox_manage.Controls.Add(this.label_chart_points);
            this.groupBox_manage.Controls.Add(this.comboBox_carts);
            this.groupBox_manage.Controls.Add(this.label_charts);
            this.groupBox_manage.Controls.Add(this.comboBox_mode);
            this.groupBox_manage.Controls.Add(this.label_mode);
            this.groupBox_manage.Controls.Add(this.button_start);
            this.groupBox_manage.Controls.Add(this.button_stop);
            this.groupBox_manage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_manage.Location = new System.Drawing.Point(5, 0);
            this.groupBox_manage.Name = "groupBox_manage";
            this.groupBox_manage.Size = new System.Drawing.Size(183, 410);
            this.groupBox_manage.TabIndex = 2;
            this.groupBox_manage.TabStop = false;
            this.groupBox_manage.Text = "Manage: ";
            // 
            // button_brovse
            // 
            this.button_brovse.Location = new System.Drawing.Point(81, 194);
            this.button_brovse.Name = "button_brovse";
            this.button_brovse.Size = new System.Drawing.Size(75, 23);
            this.button_brovse.TabIndex = 20;
            this.button_brovse.Text = "... browse";
            this.button_brovse.UseVisualStyleBackColor = true;
            this.button_brovse.Click += new System.EventHandler(this.button_brovse_Click);
            // 
            // checkBox_save_log
            // 
            this.checkBox_save_log.AutoSize = true;
            this.checkBox_save_log.Location = new System.Drawing.Point(6, 197);
            this.checkBox_save_log.Name = "checkBox_save_log";
            this.checkBox_save_log.Size = new System.Drawing.Size(68, 17);
            this.checkBox_save_log.TabIndex = 19;
            this.checkBox_save_log.Text = "Save log";
            this.checkBox_save_log.UseVisualStyleBackColor = true;
            this.checkBox_save_log.CheckedChanged += new System.EventHandler(this.checkBox_save_log_CheckedChanged);
            // 
            // panel_file
            // 
            this.panel_file.AutoScroll = true;
            this.panel_file.Controls.Add(this.label_file);
            this.panel_file.Location = new System.Drawing.Point(3, 220);
            this.panel_file.Name = "panel_file";
            this.panel_file.Size = new System.Drawing.Size(177, 41);
            this.panel_file.TabIndex = 18;
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(3, 3);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(29, 13);
            this.label_file.TabIndex = 0;
            this.label_file.Text = "File: ";
            // 
            // label_cycle_time
            // 
            this.label_cycle_time.AutoSize = true;
            this.label_cycle_time.Location = new System.Drawing.Point(11, 385);
            this.label_cycle_time.Name = "label_cycle_time";
            this.label_cycle_time.Size = new System.Drawing.Size(84, 13);
            this.label_cycle_time.TabIndex = 17;
            this.label_cycle_time.Text = "Cycle time [sec]:";
            // 
            // label_t
            // 
            this.label_t.AutoSize = true;
            this.label_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label_t.Location = new System.Drawing.Point(11, 360);
            this.label_t.Name = "label_t";
            this.label_t.Size = new System.Drawing.Size(26, 13);
            this.label_t.TabIndex = 16;
            this.label_t.Text = "T = ";
            // 
            // label_bz
            // 
            this.label_bz.AutoSize = true;
            this.label_bz.ForeColor = System.Drawing.Color.Blue;
            this.label_bz.Location = new System.Drawing.Point(11, 338);
            this.label_bz.Name = "label_bz";
            this.label_bz.Size = new System.Drawing.Size(31, 13);
            this.label_bz.TabIndex = 15;
            this.label_bz.Text = "Bz = ";
            // 
            // label_by
            // 
            this.label_by.AutoSize = true;
            this.label_by.ForeColor = System.Drawing.Color.Green;
            this.label_by.Location = new System.Drawing.Point(11, 316);
            this.label_by.Name = "label_by";
            this.label_by.Size = new System.Drawing.Size(31, 13);
            this.label_by.TabIndex = 14;
            this.label_by.Text = "By = ";
            // 
            // label_bx
            // 
            this.label_bx.AutoSize = true;
            this.label_bx.ForeColor = System.Drawing.Color.Red;
            this.label_bx.Location = new System.Drawing.Point(11, 294);
            this.label_bx.Name = "label_bx";
            this.label_bx.Size = new System.Drawing.Size(31, 13);
            this.label_bx.TabIndex = 13;
            this.label_bx.Text = "Bx = ";
            // 
            // label_b
            // 
            this.label_b.AutoSize = true;
            this.label_b.Location = new System.Drawing.Point(11, 270);
            this.label_b.Name = "label_b";
            this.label_b.Size = new System.Drawing.Size(26, 13);
            this.label_b.TabIndex = 12;
            this.label_b.Text = "B = ";
            // 
            // comboBox_units
            // 
            this.comboBox_units.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_units.FormattingEnabled = true;
            this.comboBox_units.Items.AddRange(new object[] {
            "T",
            "mT",
            "µT"});
            this.comboBox_units.Location = new System.Drawing.Point(81, 85);
            this.comboBox_units.Name = "comboBox_units";
            this.comboBox_units.Size = new System.Drawing.Size(97, 21);
            this.comboBox_units.TabIndex = 11;
            // 
            // label_units
            // 
            this.label_units.AutoSize = true;
            this.label_units.Location = new System.Drawing.Point(6, 89);
            this.label_units.Name = "label_units";
            this.label_units.Size = new System.Drawing.Size(34, 13);
            this.label_units.TabIndex = 10;
            this.label_units.Text = "Units:";
            // 
            // textBox_cycle_delay
            // 
            this.textBox_cycle_delay.Location = new System.Drawing.Point(106, 166);
            this.textBox_cycle_delay.Name = "textBox_cycle_delay";
            this.textBox_cycle_delay.Size = new System.Drawing.Size(72, 20);
            this.textBox_cycle_delay.TabIndex = 9;
            // 
            // textBox_chart_points
            // 
            this.textBox_chart_points.Location = new System.Drawing.Point(106, 142);
            this.textBox_chart_points.Name = "textBox_chart_points";
            this.textBox_chart_points.Size = new System.Drawing.Size(72, 20);
            this.textBox_chart_points.TabIndex = 8;
            // 
            // label_cycle_delay
            // 
            this.label_cycle_delay.AutoSize = true;
            this.label_cycle_delay.Location = new System.Drawing.Point(6, 170);
            this.label_cycle_delay.Name = "label_cycle_delay";
            this.label_cycle_delay.Size = new System.Drawing.Size(90, 13);
            this.label_cycle_delay.TabIndex = 7;
            this.label_cycle_delay.Text = "Cycle delay [sec]:";
            // 
            // label_chart_points
            // 
            this.label_chart_points.AutoSize = true;
            this.label_chart_points.Location = new System.Drawing.Point(6, 146);
            this.label_chart_points.Name = "label_chart_points";
            this.label_chart_points.Size = new System.Drawing.Size(66, 13);
            this.label_chart_points.TabIndex = 6;
            this.label_chart_points.Text = "Chart points:";
            // 
            // comboBox_carts
            // 
            this.comboBox_carts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_carts.FormattingEnabled = true;
            this.comboBox_carts.Location = new System.Drawing.Point(81, 113);
            this.comboBox_carts.Name = "comboBox_carts";
            this.comboBox_carts.Size = new System.Drawing.Size(97, 21);
            this.comboBox_carts.TabIndex = 5;
            // 
            // label_charts
            // 
            this.label_charts.AutoSize = true;
            this.label_charts.Location = new System.Drawing.Point(6, 117);
            this.label_charts.Name = "label_charts";
            this.label_charts.Size = new System.Drawing.Size(40, 13);
            this.label_charts.TabIndex = 4;
            this.label_charts.Text = "Charts:";
            // 
            // comboBox_mode
            // 
            this.comboBox_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mode.FormattingEnabled = true;
            this.comboBox_mode.Items.AddRange(new object[] {
            "1D",
            "2D",
            "3D"});
            this.comboBox_mode.Location = new System.Drawing.Point(81, 58);
            this.comboBox_mode.Name = "comboBox_mode";
            this.comboBox_mode.Size = new System.Drawing.Size(97, 21);
            this.comboBox_mode.TabIndex = 3;
            this.comboBox_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_mode_SelectedIndexChanged);
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Location = new System.Drawing.Point(6, 61);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(69, 13);
            this.label_mode.TabIndex = 2;
            this.label_mode.Text = "Select mode:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chart_B);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chart_add);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(858, 410);
            this.splitContainer2.SplitterDistance = 189;
            this.splitContainer2.TabIndex = 0;
            // 
            // chart_B
            // 
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.Title = "B [mT]";
            chartArea1.Name = "ChartArea1";
            this.chart_B.ChartAreas.Add(chartArea1);
            this.chart_B.ContextMenuStrip = this.contextMenuStrip_charts;
            this.chart_B.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_B.Legends.Add(legend1);
            this.chart_B.Location = new System.Drawing.Point(0, 0);
            this.chart_B.Name = "chart_B";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chart_B.Series.Add(series1);
            this.chart_B.Size = new System.Drawing.Size(856, 187);
            this.chart_B.TabIndex = 0;
            this.chart_B.Text = "chart1";
            // 
            // contextMenuStrip_charts
            // 
            this.contextMenuStrip_charts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.contextMenuStrip_charts.Name = "contextMenuStrip_charts";
            this.contextMenuStrip_charts.Size = new System.Drawing.Size(119, 48);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // chart_add
            // 
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.Title = "T [°C]";
            chartArea2.Name = "ChartArea1";
            this.chart_add.ChartAreas.Add(chartArea2);
            this.chart_add.ContextMenuStrip = this.contextMenuStrip_charts;
            this.chart_add.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_add.Legends.Add(legend2);
            this.chart_add.Location = new System.Drawing.Point(0, 0);
            this.chart_add.Name = "chart_add";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.SaddleBrown;
            series2.MarkerSize = 8;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series_T";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.Red;
            series3.MarkerSize = 8;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Series_Bx";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.MarkerColor = System.Drawing.Color.Green;
            series4.MarkerSize = 8;
            series4.Name = "Series_By";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.MarkerColor = System.Drawing.Color.Blue;
            series5.MarkerSize = 8;
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series5.Name = "Series_Bz";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chart_add.Series.Add(series2);
            this.chart_add.Series.Add(series3);
            this.chart_add.Series.Add(series4);
            this.chart_add.Series.Add(series5);
            this.chart_add.Size = new System.Drawing.Size(856, 215);
            this.chart_add.TabIndex = 1;
            this.chart_add.Text = "chart1";
            // 
            // label_log
            // 
            this.label_log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(3, 437);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(28, 13);
            this.label_log.TabIndex = 2;
            this.label_log.Text = "Log:";
            // 
            // saveFileDialog_log
            // 
            this.saveFileDialog_log.DefaultExt = "txt";
            this.saveFileDialog_log.Filter = "Text files (*.txt)|*.txt";
            this.saveFileDialog_log.OverwritePrompt = false;
            // 
            // button_start
            // 
            this.button_start.Image = global::_3DMAG_v1.Properties.Resources.start_black_24x24;
            this.button_start.Location = new System.Drawing.Point(3, 17);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(50, 35);
            this.button_start.TabIndex = 0;
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Image = global::_3DMAG_v1.Properties.Resources.stop_black_24x24;
            this.button_stop.Location = new System.Drawing.Point(59, 17);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(50, 35);
            this.button_stop.TabIndex = 1;
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionSettingsToolStripMenuItem,
            this.measureSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Image = global::_3DMAG_v1.Properties.Resources.settings_2_24x24;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // connectionSettingsToolStripMenuItem
            // 
            this.connectionSettingsToolStripMenuItem.Image = global::_3DMAG_v1.Properties.Resources.connect_16x16;
            this.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
            this.connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectionSettingsToolStripMenuItem.Text = "Connection settings";
            this.connectionSettingsToolStripMenuItem.Click += new System.EventHandler(this.connectionSettingsToolStripMenuItem_Click);
            // 
            // measureSettingsToolStripMenuItem
            // 
            this.measureSettingsToolStripMenuItem.Image = global::_3DMAG_v1.Properties.Resources.measure_settings_16x16;
            this.measureSettingsToolStripMenuItem.Name = "measureSettingsToolStripMenuItem";
            this.measureSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.measureSettingsToolStripMenuItem.Text = "Measure settings";
            this.measureSettingsToolStripMenuItem.Click += new System.EventHandler(this.measureSettingsToolStripMenuItem_Click);
            // 
            // calibrationToolStripMenuItem
            // 
            this.calibrationToolStripMenuItem.Image = global::_3DMAG_v1.Properties.Resources.calibration_24x24;
            this.calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            this.calibrationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.calibrationToolStripMenuItem.Text = "Calibration";
            this.calibrationToolStripMenuItem.Click += new System.EventHandler(this.calibrationToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 453);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3DMAG-v1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox_manage.ResumeLayout(false);
            this.groupBox_manage.PerformLayout();
            this.panel_file.ResumeLayout(false);
            this.panel_file.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_B)).EndInit();
            this.contextMenuStrip_charts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_add)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.GroupBox groupBox_manage;
        private System.Windows.Forms.ToolStripMenuItem connectionSettingsToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_mode;
        private System.Windows.Forms.Label label_mode;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox comboBox_carts;
        private System.Windows.Forms.Label label_charts;
        private System.Windows.Forms.TextBox textBox_cycle_delay;
        private System.Windows.Forms.TextBox textBox_chart_points;
        private System.Windows.Forms.Label label_cycle_delay;
        private System.Windows.Forms.Label label_chart_points;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_B;
        private System.Windows.Forms.ComboBox comboBox_units;
        private System.Windows.Forms.Label label_units;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_add;
        private System.Windows.Forms.Label label_t;
        private System.Windows.Forms.Label label_bz;
        private System.Windows.Forms.Label label_by;
        private System.Windows.Forms.Label label_bx;
        private System.Windows.Forms.Label label_b;
        private System.Windows.Forms.Label label_cycle_time;
        private System.Windows.Forms.ToolStripMenuItem measureSettingsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_charts;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.Button button_brovse;
        private System.Windows.Forms.CheckBox checkBox_save_log;
        private System.Windows.Forms.Panel panel_file;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_log;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem;
    }
}

