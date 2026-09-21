namespace GiaoDien
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            groupBox1 = new GroupBox();
            label7 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            serialPort1 = new System.IO.Ports.SerialPort(components);
            textBox4 = new TextBox();
            groupBox5 = new GroupBox();
            checkBox1 = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            textBox5 = new TextBox();
            button7 = new Button();
            button8 = new Button();
            groupBox2 = new GroupBox();
            pictureBox3 = new PictureBox();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            groupBox3 = new GroupBox();
            textBox7 = new TextBox();
            textBox3 = new TextBox();
            groupBox4 = new GroupBox();
            textBox8 = new TextBox();
            textBox6 = new TextBox();
            pictureBox2 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(66, 11);
            label1.Name = "label1";
            label1.Size = new Size(416, 32);
            label1.TabIndex = 0;
            label1.Text = "RS232(COM) Comucation-lab";
            // 
            // button1
            // 
            button1.Location = new Point(3, 136);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 29);
            button1.TabIndex = 1;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.MediumSeaGreen;
            label2.Location = new Point(28, 486);
            label2.Name = "label2";
            label2.Size = new Size(281, 29);
            label2.TabIndex = 2;
            label2.Text = "Designed by LeGiaBao";
            // 
            // button2
            // 
            button2.Location = new Point(132, 136);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(98, 29);
            button2.TabIndex = 3;
            button2.Text = "Disconnect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(27, 78);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(244, 172);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Communicate setup";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 69);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 14;
            label7.Text = "Baud Rate";
            label7.Click += label7_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(79, 65);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 28);
            comboBox2.TabIndex = 7;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 29);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 6;
            label3.Text = "COM Port";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Red;
            textBox1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(53, 102);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 22);
            textBox1.TabIndex = 5;
            textBox1.Text = "Disconnected";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(79, 26);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // serialPort1
            // 
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.DiscardNull = false;
            serialPort1.DtrEnable = false;
            serialPort1.Handshake = System.IO.Ports.Handshake.None;
            serialPort1.NewLine = "\n";
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.ParityReplace = 63;
            serialPort1.PortName = "COM1";
            serialPort1.ReadBufferSize = 4096;
            serialPort1.ReadTimeout = -1;
            serialPort1.ReceivedBytesThreshold = 1;
            serialPort1.RtsEnable = false;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.WriteTimeout = -1;
            serialPort1.DataReceived += serialPort1_DataReceived;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(100, 75);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(130, 27);
            textBox4.TabIndex = 10;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(checkBox1);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(textBox5);
            groupBox5.Controls.Add(textBox4);
            groupBox5.Location = new Point(27, 271);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(244, 125);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Data Send/Receive";
            groupBox5.Enter += groupBox5_Enter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(67, 26);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 14;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 78);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 13;
            label6.Text = "Receive";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 26);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 12;
            label5.Text = "Send";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(100, 24);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(130, 27);
            textBox5.TabIndex = 11;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(33, 424);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(72, 41);
            button7.TabIndex = 7;
            button7.Text = "Send";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(114, 424);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(143, 41);
            button8.TabIndex = 13;
            button8.Text = "Exit Program";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBox3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(321, 280);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(490, 185);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "KHÍ GA";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.save;
            pictureBox3.Location = new Point(9, 24);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(81, 99);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(96, 34);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(322, 27);
            textBox2.TabIndex = 0;
            textBox2.Text = "AN TOÀN";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.save;
            pictureBox1.Location = new Point(9, 29);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(81, 101);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox7);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(pictureBox1);
            groupBox3.Location = new Point(312, 78);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(247, 144);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "NHIỆT ĐỘ";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(96, 89);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(145, 27);
            textBox7.TabIndex = 8;
            textBox7.Text = "AN TOÀN";
            textBox7.TextAlign = HorizontalAlignment.Center;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(96, 36);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(145, 27);
            textBox3.TabIndex = 7;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox8);
            groupBox4.Controls.Add(textBox6);
            groupBox4.Controls.Add(pictureBox2);
            groupBox4.Location = new Point(565, 78);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(261, 144);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "ĐỘ ẨM";
            groupBox4.Enter += groupBox4_Enter;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(107, 89);
            textBox8.Margin = new Padding(3, 4, 3, 4);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(148, 27);
            textBox8.TabIndex = 9;
            textBox8.Text = "AN TOÀN";
            textBox8.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(107, 36);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(148, 27);
            textBox6.TabIndex = 8;
            textBox6.TextAlign = HorizontalAlignment.Center;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.save;
            pictureBox2.Location = new Point(6, 29);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(79, 101);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 530);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Samplpe-interface";
            TopMost = true;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
    }
}

