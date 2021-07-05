namespace _3DMAG_v1
{
    partial class Form2_ConnectionSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2_ConnectionSettings));
            this.tableLayoutPanel_port = new System.Windows.Forms.TableLayoutPanel();
            this.label_portname = new System.Windows.Forms.Label();
            this.label_baudrate = new System.Windows.Forms.Label();
            this.label_parity = new System.Windows.Forms.Label();
            this.label_databits = new System.Windows.Forms.Label();
            this.label_stopbits = new System.Windows.Forms.Label();
            this.label_handshake = new System.Windows.Forms.Label();
            this.label_read_timeout = new System.Windows.Forms.Label();
            this.label_write_timeout = new System.Windows.Forms.Label();
            this.comboBox_portname = new System.Windows.Forms.ComboBox();
            this.comboBox_baudrate = new System.Windows.Forms.ComboBox();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.comboBox_stopbits = new System.Windows.Forms.ComboBox();
            this.comboBox_handshake = new System.Windows.Forms.ComboBox();
            this.textBox_databits = new System.Windows.Forms.TextBox();
            this.textBox_read_timeout = new System.Windows.Forms.TextBox();
            this.textBox_write_timeout = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_set_default = new System.Windows.Forms.Button();
            this.tableLayoutPanel_port.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_port
            // 
            this.tableLayoutPanel_port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_port.ColumnCount = 2;
            this.tableLayoutPanel_port.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel_port.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_port.Controls.Add(this.label_portname, 0, 0);
            this.tableLayoutPanel_port.Controls.Add(this.label_baudrate, 0, 1);
            this.tableLayoutPanel_port.Controls.Add(this.label_parity, 0, 2);
            this.tableLayoutPanel_port.Controls.Add(this.label_databits, 0, 3);
            this.tableLayoutPanel_port.Controls.Add(this.label_stopbits, 0, 4);
            this.tableLayoutPanel_port.Controls.Add(this.label_handshake, 0, 5);
            this.tableLayoutPanel_port.Controls.Add(this.label_read_timeout, 0, 6);
            this.tableLayoutPanel_port.Controls.Add(this.label_write_timeout, 0, 7);
            this.tableLayoutPanel_port.Controls.Add(this.comboBox_portname, 1, 0);
            this.tableLayoutPanel_port.Controls.Add(this.comboBox_baudrate, 1, 1);
            this.tableLayoutPanel_port.Controls.Add(this.comboBox_parity, 1, 2);
            this.tableLayoutPanel_port.Controls.Add(this.comboBox_stopbits, 1, 4);
            this.tableLayoutPanel_port.Controls.Add(this.comboBox_handshake, 1, 5);
            this.tableLayoutPanel_port.Controls.Add(this.textBox_databits, 1, 3);
            this.tableLayoutPanel_port.Controls.Add(this.textBox_read_timeout, 1, 6);
            this.tableLayoutPanel_port.Controls.Add(this.textBox_write_timeout, 1, 7);
            this.tableLayoutPanel_port.Location = new System.Drawing.Point(6, 7);
            this.tableLayoutPanel_port.Name = "tableLayoutPanel_port";
            this.tableLayoutPanel_port.RowCount = 9;
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_port.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_port.Size = new System.Drawing.Size(259, 222);
            this.tableLayoutPanel_port.TabIndex = 0;
            // 
            // label_portname
            // 
            this.label_portname.AutoSize = true;
            this.label_portname.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_portname.Location = new System.Drawing.Point(3, 0);
            this.label_portname.Name = "label_portname";
            this.label_portname.Size = new System.Drawing.Size(58, 27);
            this.label_portname.TabIndex = 0;
            this.label_portname.Text = "Port name:";
            this.label_portname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_baudrate
            // 
            this.label_baudrate.AutoSize = true;
            this.label_baudrate.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_baudrate.Location = new System.Drawing.Point(3, 27);
            this.label_baudrate.Name = "label_baudrate";
            this.label_baudrate.Size = new System.Drawing.Size(53, 27);
            this.label_baudrate.TabIndex = 1;
            this.label_baudrate.Text = "Baudrate:";
            this.label_baudrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_parity
            // 
            this.label_parity.AutoSize = true;
            this.label_parity.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_parity.Location = new System.Drawing.Point(3, 54);
            this.label_parity.Name = "label_parity";
            this.label_parity.Size = new System.Drawing.Size(36, 27);
            this.label_parity.TabIndex = 2;
            this.label_parity.Text = "Parity:";
            this.label_parity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_databits
            // 
            this.label_databits.AutoSize = true;
            this.label_databits.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_databits.Location = new System.Drawing.Point(3, 81);
            this.label_databits.Name = "label_databits";
            this.label_databits.Size = new System.Drawing.Size(49, 26);
            this.label_databits.TabIndex = 3;
            this.label_databits.Text = "Databits:";
            this.label_databits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_stopbits
            // 
            this.label_stopbits.AutoSize = true;
            this.label_stopbits.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_stopbits.Location = new System.Drawing.Point(3, 107);
            this.label_stopbits.Name = "label_stopbits";
            this.label_stopbits.Size = new System.Drawing.Size(48, 27);
            this.label_stopbits.TabIndex = 4;
            this.label_stopbits.Text = "Stopbits:";
            this.label_stopbits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_handshake
            // 
            this.label_handshake.AutoSize = true;
            this.label_handshake.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_handshake.Location = new System.Drawing.Point(3, 134);
            this.label_handshake.Name = "label_handshake";
            this.label_handshake.Size = new System.Drawing.Size(65, 27);
            this.label_handshake.TabIndex = 5;
            this.label_handshake.Text = "Handshake:";
            this.label_handshake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_read_timeout
            // 
            this.label_read_timeout.AutoSize = true;
            this.label_read_timeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_read_timeout.Location = new System.Drawing.Point(3, 161);
            this.label_read_timeout.Name = "label_read_timeout";
            this.label_read_timeout.Size = new System.Drawing.Size(95, 26);
            this.label_read_timeout.TabIndex = 6;
            this.label_read_timeout.Text = "Read timeout [ms]:";
            this.label_read_timeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_write_timeout
            // 
            this.label_write_timeout.AutoSize = true;
            this.label_write_timeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_write_timeout.Location = new System.Drawing.Point(3, 187);
            this.label_write_timeout.Name = "label_write_timeout";
            this.label_write_timeout.Size = new System.Drawing.Size(94, 26);
            this.label_write_timeout.TabIndex = 7;
            this.label_write_timeout.Text = "Write timeout [ms]:";
            this.label_write_timeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_portname
            // 
            this.comboBox_portname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_portname.FormattingEnabled = true;
            this.comboBox_portname.Location = new System.Drawing.Point(113, 3);
            this.comboBox_portname.Name = "comboBox_portname";
            this.comboBox_portname.Size = new System.Drawing.Size(143, 21);
            this.comboBox_portname.TabIndex = 8;
            // 
            // comboBox_baudrate
            // 
            this.comboBox_baudrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_baudrate.FormattingEnabled = true;
            this.comboBox_baudrate.Location = new System.Drawing.Point(113, 30);
            this.comboBox_baudrate.Name = "comboBox_baudrate";
            this.comboBox_baudrate.Size = new System.Drawing.Size(143, 21);
            this.comboBox_baudrate.TabIndex = 9;
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_parity.FormattingEnabled = true;
            this.comboBox_parity.Location = new System.Drawing.Point(113, 57);
            this.comboBox_parity.Name = "comboBox_parity";
            this.comboBox_parity.Size = new System.Drawing.Size(143, 21);
            this.comboBox_parity.TabIndex = 10;
            // 
            // comboBox_stopbits
            // 
            this.comboBox_stopbits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_stopbits.FormattingEnabled = true;
            this.comboBox_stopbits.Location = new System.Drawing.Point(113, 110);
            this.comboBox_stopbits.Name = "comboBox_stopbits";
            this.comboBox_stopbits.Size = new System.Drawing.Size(143, 21);
            this.comboBox_stopbits.TabIndex = 11;
            // 
            // comboBox_handshake
            // 
            this.comboBox_handshake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_handshake.FormattingEnabled = true;
            this.comboBox_handshake.Location = new System.Drawing.Point(113, 137);
            this.comboBox_handshake.Name = "comboBox_handshake";
            this.comboBox_handshake.Size = new System.Drawing.Size(143, 21);
            this.comboBox_handshake.TabIndex = 12;
            // 
            // textBox_databits
            // 
            this.textBox_databits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_databits.Location = new System.Drawing.Point(113, 84);
            this.textBox_databits.Name = "textBox_databits";
            this.textBox_databits.Size = new System.Drawing.Size(143, 20);
            this.textBox_databits.TabIndex = 13;
            // 
            // textBox_read_timeout
            // 
            this.textBox_read_timeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_read_timeout.Location = new System.Drawing.Point(113, 164);
            this.textBox_read_timeout.Name = "textBox_read_timeout";
            this.textBox_read_timeout.Size = new System.Drawing.Size(143, 20);
            this.textBox_read_timeout.TabIndex = 14;
            // 
            // textBox_write_timeout
            // 
            this.textBox_write_timeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_write_timeout.Location = new System.Drawing.Point(113, 190);
            this.textBox_write_timeout.Name = "textBox_write_timeout";
            this.textBox_write_timeout.Size = new System.Drawing.Size(143, 20);
            this.textBox_write_timeout.TabIndex = 15;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_save.Image = global::_3DMAG_v1.Properties.Resources.save_2_24x24;
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(6, 235);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(70, 30);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "SAVE";
            this.button_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_set_default
            // 
            this.button_set_default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_set_default.Image = global::_3DMAG_v1.Properties.Resources.default_settings_24x24;
            this.button_set_default.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_set_default.Location = new System.Drawing.Point(150, 235);
            this.button_set_default.Name = "button_set_default";
            this.button_set_default.Size = new System.Drawing.Size(115, 30);
            this.button_set_default.TabIndex = 7;
            this.button_set_default.Text = "SET DEFAULT";
            this.button_set_default.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_set_default.UseVisualStyleBackColor = true;
            this.button_set_default.Click += new System.EventHandler(this.button_set_default_Click);
            // 
            // Form2_ConnectionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 272);
            this.Controls.Add(this.button_set_default);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.tableLayoutPanel_port);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2_ConnectionSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "3DMAG-v1 (port setting)";
            this.Load += new System.EventHandler(this.Form2_ConnectionSettings_Load);
            this.tableLayoutPanel_port.ResumeLayout(false);
            this.tableLayoutPanel_port.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_port;
        private System.Windows.Forms.Label label_portname;
        private System.Windows.Forms.Label label_baudrate;
        private System.Windows.Forms.Label label_parity;
        private System.Windows.Forms.Label label_databits;
        private System.Windows.Forms.Label label_stopbits;
        private System.Windows.Forms.Label label_handshake;
        private System.Windows.Forms.Label label_read_timeout;
        private System.Windows.Forms.Label label_write_timeout;
        private System.Windows.Forms.ComboBox comboBox_portname;
        private System.Windows.Forms.ComboBox comboBox_baudrate;
        private System.Windows.Forms.ComboBox comboBox_parity;
        private System.Windows.Forms.ComboBox comboBox_stopbits;
        private System.Windows.Forms.ComboBox comboBox_handshake;
        private System.Windows.Forms.TextBox textBox_databits;
        private System.Windows.Forms.TextBox textBox_read_timeout;
        private System.Windows.Forms.TextBox textBox_write_timeout;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_set_default;
    }
}